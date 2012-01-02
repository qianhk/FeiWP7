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
using System.ComponentModel;

namespace ApplicationLifecycle
{
  public class TravelReportInfo : INotifyPropertyChanged
  {
    #region Properties
    private string _Destination = "";
    public string Destination 
    {
      get { return _Destination; }
      set
      {
        _Destination = value;
        NotifyPropertyChanged("Destination");
      }
    }

    private DateTime _FirstDay = DateTime.Now;
    public DateTime FirstDay
    {
      get { return _FirstDay; }
      set
      {
        _FirstDay = value;
        NotifyPropertyChanged("FirstDay");
      }
    }

    private DateTime _LastDay = DateTime.Now;
    public DateTime LastDay
    {
      get { return _LastDay; }
      set
      {
        _LastDay = value;
        NotifyPropertyChanged("LastDay");
      }
    }

    private string _Justification = "";
    public string Justification
    {
      get { return _Justification; }
      set
      {
        _Justification = value;
        NotifyPropertyChanged("Justification");
      }
    }

    private string _Summary = "";
    public string Summary
    {
      get { return _Summary; }
      set
      {
        _Summary = value;
        NotifyPropertyChanged("Summary");
      }
    }
    #endregion

    #region Public Functionality
    public void Clear()
    {
      Destination = "";
      Summary = "";
      Justification = "";
      FirstDay = DateTime.Now;
      LastDay = DateTime.Now;
    }
    #endregion

    #region Private Functionality
    private void NotifyPropertyChanged(string propertyName)
    {
      if (null != PropertyChanged)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}