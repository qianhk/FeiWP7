using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text;

namespace Njnu.KaiKaiEdit
{
    /// <summary>
    /// 
    /// Written by flying#devdiv.com
    /// 
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidKaiKaiEditPkgString)]
    public sealed class KaiKaiEditPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public KaiKaiEditPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

		private MenuCommand menuItemSwapLinesDown;
		private MenuCommand menuItemSwapLinesUp;
		private MenuCommand menuItemCopyLinesDown;
		private MenuCommand menuItemCopyLinesUp;
		private MenuCommand menuItemCommentOrNo;

        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidKaiKaiEditCmdSet, (int)PkgCmdIDList.cmdidSwapLinesDown);
				menuItemSwapLinesDown = new MenuCommand(MenuItemCallback, menuCommandID);
				mcs.AddCommand(menuItemSwapLinesDown);

				menuCommandID = new CommandID(GuidList.guidKaiKaiEditCmdSet, (int)PkgCmdIDList.cmdidSwapLinesUp);
				menuItemSwapLinesUp = new MenuCommand(MenuItemCallback, menuCommandID);
				mcs.AddCommand(menuItemSwapLinesUp);

				menuCommandID = new CommandID(GuidList.guidKaiKaiEditCmdSet, (int)PkgCmdIDList.cmdidCopyLinesDown);
				menuItemCopyLinesDown = new MenuCommand(MenuItemCallback, menuCommandID);
				mcs.AddCommand(menuItemCopyLinesDown);

				menuCommandID = new CommandID(GuidList.guidKaiKaiEditCmdSet, (int)PkgCmdIDList.cmdidCopyLinesUp);
				menuItemCopyLinesUp = new MenuCommand(MenuItemCallback, menuCommandID);
				mcs.AddCommand(menuItemCopyLinesUp);

				menuCommandID = new CommandID(GuidList.guidKaiKaiEditCmdSet, (int)PkgCmdIDList.cmdidCommentOrNo);
				menuItemCommentOrNo = new MenuCommand(MenuItemCallbackCommentOrNo, menuCommandID);
				mcs.AddCommand(menuItemCommentOrNo);
            }
        }
        #endregion

		///rootsuffix Exp
		private void MenuItemCallbackCommentOrNo(object sender, EventArgs e)
		{
			IVsTextManager txtMgr = (IVsTextManager)Package.GetGlobalService(typeof(SVsTextManager));
			if (txtMgr == null) return;

			IVsTextView view = null;
			int errorValue = txtMgr.GetActiveView(0, null, out view);
			if (view == null) return;

			IComponentModel componentModel = Package.GetGlobalService(typeof(SComponentModel)) as IComponentModel;
			IVsEditorAdaptersFactoryService editorFactory = componentModel.GetService<IVsEditorAdaptersFactoryService>();
			IWpfTextView wpfTextView = editorFactory.GetWpfTextView(view);
			if (wpfTextView == null) return;

			ITextSnapshot snapshot = wpfTextView.TextSnapshot;

			if (snapshot != snapshot.TextBuffer.CurrentSnapshot) return;

			bool bAllHaveComment = IsAllSelectedLinesHaveComment(wpfTextView);
			ProcessComments(!bAllHaveComment);
		}

		bool IsAllSelectedLinesHaveComment(IWpfTextView wpfTextView)
		{
			ITextSnapshot snapshot = wpfTextView.TextSnapshot;

			int lineNumberFirstSelected = 0;
			int lineNumberLastSelected = 0;
			if (wpfTextView.Selection.IsEmpty)
			{
				lineNumberLastSelected = lineNumberFirstSelected = snapshot.GetLineNumberFromPosition(wpfTextView.Caret.Position.BufferPosition);
			}
			else
			{
				ITextSelection textSelection = wpfTextView.Selection;
				lineNumberFirstSelected = snapshot.GetLineNumberFromPosition(textSelection.Start.Position);
				lineNumberLastSelected = snapshot.GetLineNumberFromPosition(textSelection.End.Position - 1);
			}
			string selectedText = "";
			ITextSnapshotLine textSnapshotLine;
			for (int i = lineNumberFirstSelected; i <= lineNumberLastSelected; ++i)
			{
				textSnapshotLine = snapshot.GetLineFromLineNumber(i);
				selectedText = textSnapshotLine.GetText().Trim();
				if (selectedText.Length < 2 || selectedText.Substring(0, 2) != "//")
				{
					return false;
				}
			}
			return true;
		}

		void ProcessComments(bool comment)
		{
			IVsUIShell shell = Package.GetGlobalService(typeof(IVsUIShell)) as IVsUIShell;
			if (shell != null)
			{
				Guid std2k = VSConstants.VSStd2K;
				uint cmdId = comment ? (uint)VSConstants.VSStd2KCmdID.COMMENT_BLOCK : (uint)VSConstants.VSStd2KCmdID.UNCOMMENT_BLOCK;
				object arg = null;
				shell.PostExecCommand(ref std2k, cmdId, 0, ref arg);
			}
		}

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
		private void MenuItemCallback(object sender, EventArgs e)
		{
			// Show a Message Box to prove we were here
			//IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
			IVsTextManager txtMgr = (IVsTextManager)Package.GetGlobalService(typeof(SVsTextManager));
			if (txtMgr == null) return;
			
			IVsTextView view = null;
			int errorValue = txtMgr.GetActiveView(0, null, out view);
			if (view == null) return;

			IComponentModel componentModel = Package.GetGlobalService(typeof(SComponentModel)) as IComponentModel;
			IVsEditorAdaptersFactoryService editorFactory = componentModel.GetService<IVsEditorAdaptersFactoryService>();
			IWpfTextView wpfTextView = editorFactory.GetWpfTextView(view);
			if (wpfTextView == null) return;

			ITextSnapshot snapshot = wpfTextView.TextSnapshot;

			if (snapshot != snapshot.TextBuffer.CurrentSnapshot) return;

			if (sender == menuItemSwapLinesDown)
			{
				SwapLines(wpfTextView, true);
			}
			else if (sender == menuItemSwapLinesUp)
			{
				SwapLines(wpfTextView, false);
			}
			else if (sender == menuItemCopyLinesDown)
			{
				CopyLines(wpfTextView, true);
			}
			else if (sender == menuItemCopyLinesUp)
			{
				CopyLines(wpfTextView, false);
			}
		}

		private void CopyLines(IWpfTextView wpfTextView, bool bDirectionDown)
		{
			ITextSnapshot snapshot = wpfTextView.TextSnapshot;

			int lineNumberFirstSelected = 0;
			int lineNumberLastSelected = 0;
			if (wpfTextView.Selection.IsEmpty)
			{
				lineNumberLastSelected = lineNumberFirstSelected = snapshot.GetLineNumberFromPosition(wpfTextView.Caret.Position.BufferPosition);
			}
			else
			{
				ITextSelection textSelection = wpfTextView.Selection;
				lineNumberFirstSelected = snapshot.GetLineNumberFromPosition(textSelection.Start.Position);
				lineNumberLastSelected = snapshot.GetLineNumberFromPosition(textSelection.End.Position - 1);
			}
			string selectedText = "";
			ITextSnapshotLine textSnapshotLine;
			for (int i = lineNumberFirstSelected; i <= lineNumberLastSelected; ++i)
			{
				textSnapshotLine = snapshot.GetLineFromLineNumber(i);
				selectedText += textSnapshotLine.GetTextIncludingLineBreak();
			}

			int newPosSelected = 0;
			ITextEdit edit = snapshot.TextBuffer.CreateEdit();
			if (bDirectionDown)
			{
				textSnapshotLine = snapshot.GetLineFromLineNumber(lineNumberLastSelected);
				newPosSelected = textSnapshotLine.EndIncludingLineBreak;
				edit.Insert(newPosSelected, selectedText);
			}
			else
			{
				textSnapshotLine = snapshot.GetLineFromLineNumber(lineNumberFirstSelected);
				newPosSelected = textSnapshotLine.Start;
				edit.Insert(newPosSelected, selectedText);
			}
			edit.Apply();

			SnapshotPoint newSnapshotPoint = new SnapshotPoint(wpfTextView.TextSnapshot, newPosSelected);
			SnapshotSpan newSnapshotSpan = new SnapshotSpan(newSnapshotPoint, selectedText.Length);
			wpfTextView.Selection.Select(newSnapshotSpan, false);
			wpfTextView.Caret.MoveTo(newSnapshotPoint);
		}

		private void SwapLines(IWpfTextView wpfTextView, bool bDirectionDown)
		{
			ITextSnapshot snapshot = wpfTextView.TextSnapshot;
			int lineNumberFirstSelected = 0;
			int lineNumberLastSelected = 0;
			if (wpfTextView.Selection.IsEmpty)
			{
				lineNumberLastSelected = lineNumberFirstSelected = snapshot.GetLineNumberFromPosition(wpfTextView.Caret.Position.BufferPosition);
			}
			else
			{
				ITextSelection textSelection = wpfTextView.Selection;
				lineNumberFirstSelected = snapshot.GetLineNumberFromPosition(textSelection.Start.Position);
				lineNumberLastSelected = snapshot.GetLineNumberFromPosition(textSelection.End.Position - 1);
			}
			if ( (bDirectionDown && snapshot.LineCount <= lineNumberLastSelected + 1)
				|| (!bDirectionDown && lineNumberFirstSelected == 0))
			{
				return;
			}

			int posBeginSelected = snapshot.GetLineFromLineNumber(lineNumberFirstSelected).Start;
			string selectedText = "";
			ITextSnapshotLine textSnapshotLine;
			for (int i = lineNumberFirstSelected; i < lineNumberLastSelected; ++i)
			{
				textSnapshotLine = snapshot.GetLineFromLineNumber(i);
				selectedText += textSnapshotLine.GetTextIncludingLineBreak();
			}
			textSnapshotLine = snapshot.GetLineFromLineNumber(lineNumberLastSelected);
			selectedText += textSnapshotLine.GetText();
			int newPosSelected = textSnapshotLine.LineBreakLength;

			int outSelectedLineNumber = bDirectionDown ? (lineNumberLastSelected + 1) : (lineNumberFirstSelected - 1);
			textSnapshotLine = snapshot.GetLineFromLineNumber(outSelectedLineNumber);
			string outSelectedText = textSnapshotLine.GetText();
			int posOutSelected = textSnapshotLine.Start;
		
			ITextEdit edit = snapshot.TextBuffer.CreateEdit();
			edit.Replace(posBeginSelected, selectedText.Length, outSelectedText);
			edit.Replace(posOutSelected, outSelectedText.Length, selectedText);
			edit.Apply();

			if (bDirectionDown)
			{
				newPosSelected += posBeginSelected + outSelectedText.Length;
			}
			else
			{
				newPosSelected = posOutSelected;
			}
			SnapshotPoint newSnapshotPoint = new SnapshotPoint(wpfTextView.TextSnapshot, newPosSelected);
			SnapshotSpan newSnapshotSpan = new SnapshotSpan(newSnapshotPoint, selectedText.Length);
			wpfTextView.Selection.Select(newSnapshotSpan, false);
			wpfTextView.Caret.MoveTo(newSnapshotPoint);
		}

    }
}
