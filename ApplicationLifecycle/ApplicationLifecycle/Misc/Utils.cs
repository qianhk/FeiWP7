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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace ApplicationLifecycle
{
  public class Utils
  {
    public static void Trace(string msg)
    {
#if DEBUG
      Debug.WriteLine("TOMBSTONING EVENT: {0} at {1}", msg, DateTime.Now.ToLongTimeString());
#endif
    }

    public static void ClearTravelReport(TravelReportInfo travelReportInfo)
    {
      travelReportInfo.Clear();

      if (MessageBox.Show("Clear all saved reports also?", "Clead Data", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
      {

        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        {
          //Check if file exits
          if (isf.FileExists("TravelReportInfo.dat"))
            isf.DeleteFile("TravelReportInfo.dat");
        }
      }
    }

    public static void SaveTravelReport(TravelReportInfo travelReportInfo, string fileName, bool isExiting)
    {
      using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
      {
        //If user choose to save, create a new file
        using (IsolatedStorageFileStream fs = isf.CreateFile(fileName))
        {
          //and serialize data
          XmlSerializer ser = new XmlSerializer(typeof(TravelReportInfo));
          ser.Serialize(fs, travelReportInfo);
        }
      }

      if (!isExiting)
        MessageBox.Show("Travel report saved successfully", "Save Complete", MessageBoxButton.OK);
    }
  }
}