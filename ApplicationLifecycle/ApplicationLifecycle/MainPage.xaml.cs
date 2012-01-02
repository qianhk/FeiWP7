// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ApplicationLifecycle
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Date_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Invalid date value.\nPlease try again", "Invalid date value or format", MessageBoxButton.OK);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to second page
            NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Utils.ClearTravelReport(((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            //Ask userto preserve data in persistent store
            MessageBoxResult res = MessageBox.Show("Do you want to save your work before?", "You are exiting the application", MessageBoxButton.OKCancel);

            if (res == MessageBoxResult.OK)
                Utils.SaveTravelReport((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo,
                    "TravelReportInfo.dat", true);
            else
                Utils.ClearTravelReport((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            //Trace the event for debug purposes
            Utils.Trace("Navigated To MainPage");

            //Check if page state has saved focus and apply it back
            if (State.ContainsKey("FocusedElement"))
            {
                Control focusedElement = this.FindName(State["FocusedElement"] as string) as Control;

                if (null != focusedElement)
                    focusedElement.Focus();
            }

            TravelReportInfo travelReportInfo = ((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo);
            if (State.ContainsKey("txtDestination"))
                travelReportInfo.Destination = State["txtDestination"] as string;

            if (State.ContainsKey("txtJustification"))
                travelReportInfo.Justification = State["txtJustification"] as string;

            if (State.ContainsKey("txtToDate"))
                travelReportInfo.FirstDay = DateTime.Parse(State["txtToDate"] as string);

            if (State.ContainsKey("txtFromDate"))
                travelReportInfo.LastDay = DateTime.Parse(State["txtFromDate"] as string);

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            //Trace the event for debug purposes
            Utils.Trace("Navigated From MainPage");

            //Remove focused element from previous time if any
            if (State.ContainsKey("FocusedElement"))
                State.Remove("FocusedElement");

            //If some input control is in focus, save it to the page state
            object obj = FocusManager.GetFocusedElement();
            if (null != obj)
            {
                string focusedControl = (obj as FrameworkElement).Name;
                State.Add("FocusedElement", focusedControl);
            }

            if (State.ContainsKey("txtDestination"))
                State.Remove("txtDestination");

            State.Add("txtDestination", txtDestination.Text);

            if (State.ContainsKey("txtJustification"))
                State.Remove("txtJustification");

            State.Add("txtJustification", txtJustification.Text);

            if (State.ContainsKey("txtFromDate"))
                State.Remove("txtFromDate");

            State.Add("txtFromDate", txtFromDate.Text);

            if (State.ContainsKey("txtToDate"))
                State.Remove("txtToDate");

            State.Add("txtToDate", txtToDate.Text);

            base.OnNavigatedFrom(e);
        }
    }
}