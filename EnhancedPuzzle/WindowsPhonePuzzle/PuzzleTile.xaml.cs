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

namespace WindowsPhonePuzzle
{
    public partial class PuzzleTile : UserControl
    {
        public PuzzleTile()
        {
            InitializeComponent();
        }

        const double imageMargin = 2; 

        public ImageSource Source
        {
            get { return this.TileImage.Source; }
            set
            {
                this.TileImage.Source = value;

                this.TileImage.Height = ImageSize;
                this.TileImage.Width = ImageSize;

                double pieceSize = PieceSize - imageMargin;

                this.TileImage.Stretch = Stretch.UniformToFill;
                RectangleGeometry r = new RectangleGeometry();
                r.Rect = new Rect((XLocation * pieceSize), (YLocation * pieceSize), pieceSize, pieceSize);
                r.RadiusX = 3;
                r.RadiusY = 3;
                this.TileImage.Clip = r;
                this.TileImage.SetValue(Canvas.TopProperty, Convert.ToDouble(YLocation * pieceSize * -1));
                this.TileImage.SetValue(Canvas.LeftProperty, Convert.ToDouble(XLocation * pieceSize * -1));

                this.Label1.Text = LabelNumber.ToString();
                this.Label2.Text = LabelNumber.ToString();

                Label.Opacity = 0;
            }
        }

        public void ShowNumberLabel()
        {
            Storyboard sb = this.Resources["ShowLabel"] as Storyboard;
            if (sb != null) sb.Begin();
        }

        public void HideNumberLabel()
        {
            Label.Opacity = 0;
        }

        public int LabelNumber { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public double PieceSize { get; set; }
        public double ImageSize { get; set; }

    }
}