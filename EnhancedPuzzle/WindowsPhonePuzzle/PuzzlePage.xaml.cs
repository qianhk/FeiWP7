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
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using Microsoft.Phone.Controls;

namespace WindowsPhonePuzzle
{
    public partial class PuzzlePage : PhoneApplicationPage
    {
        private const double DoubleTapSpeed = 500;
        private const int ImageSize = 435;
        private PuzzleGame game;
        private Canvas[] puzzlePieces;
        private Stream imageStream;

        private long lastTapTicks;
        private int movingPieceId = -1;
        private int movingPieceDirection;
        private double movingPieceStartingPosition;

        public Stream ImageStream
        {
            get
            {
                return this.imageStream;
            }

            set
            {
                this.imageStream = value;

                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(value);
                //this.PreviewImage.Source = bitmap;

                int i = 0;
                int pieceSize = ImageSize / this.game.ColsAndRows;
                for (int ix = 0; ix < this.game.ColsAndRows; ix++)
                {
                    for (int iy = 0; iy < this.game.ColsAndRows; iy++)
                    {
                        //Image pieceImage = this.puzzlePieces[i].Children[0] as Image;
                        PuzzleTile tile = this.puzzlePieces[i].Children[0] as PuzzleTile;
                        tile.Source = bitmap;
                        i++;

                    }
                }
            }
        }

        public PuzzlePage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;

            // Puzzle Game
            this.game = new PuzzleGame(3);

            this.game.GameStarted += delegate
            {
                this.ResetWinTransition.Begin();
                this.StatusPanel.Visibility = Visibility.Visible;
                this.TapToContinueTextBlock.Opacity = 0;
                this.TapToContinueTextBlockFront.Opacity = 0;
                this.TotalMovesTextBlock.Text = this.game.TotalMoves.ToString();
            };

            this.game.GameOver += delegate
            {
                this.WinTransition.Begin();
                this.StatusPanel.Visibility = Visibility.Visible;
                this.TotalMovesTextBlock.Text = this.game.TotalMoves.ToString();

                foreach (Canvas c in this.puzzlePieces)
                {
                    PuzzleTile tile = c.Children[0] as PuzzleTile;
                    tile.HideNumberLabel();
                }
            };

            this.game.PieceUpdated += delegate(object sender, PieceUpdatedEventArgs args)
            {
                int pieceSize = ImageSize / this.game.ColsAndRows;
                this.AnimatePiece(this.puzzlePieces[args.PieceId], Canvas.LeftProperty, (int)args.NewPosition.X * pieceSize);
                this.AnimatePiece(this.puzzlePieces[args.PieceId], Canvas.TopProperty, (int)args.NewPosition.Y * pieceSize);
                this.TotalMovesTextBlock.Text = this.game.TotalMoves.ToString();
            };

            this.InitBoard();
        }

        private void InitBoard()
        {
            int totalPieces = this.game.ColsAndRows * this.game.ColsAndRows;
            int pieceSize = ImageSize / this.game.ColsAndRows;

            this.puzzlePieces = new Canvas[totalPieces];
            int nx = 0;
            for (int ix = 0; ix < this.game.ColsAndRows; ix++)
            {
                for (int iy = 0; iy < this.game.ColsAndRows; iy++)
                {
                    nx = (ix * this.game.ColsAndRows) + iy;

                    PuzzleTile tile = new PuzzleTile();
                    tile.SetValue(FrameworkElement.NameProperty, "PuzzleImage_" + nx);
                    tile.Height = pieceSize;
                    tile.Width = pieceSize;
                    tile.Tag = nx;

                    tile.ImageSize = ImageSize;
                    tile.PieceSize = pieceSize;
                    tile.XLocation = ix;
                    tile.YLocation = iy;

                    tile.LabelNumber = ((iy * this.game.ColsAndRows) + ix) + 1;

                    tile.SetValue(Canvas.TopProperty, 0.0);
                    tile.SetValue(Canvas.LeftProperty, 0.0);

                    this.puzzlePieces[nx] = new Canvas();
                    this.puzzlePieces[nx].SetValue(FrameworkElement.NameProperty, "PuzzlePiece_" + nx);
                    this.puzzlePieces[nx].Width = pieceSize;
                    this.puzzlePieces[nx].Height = pieceSize;
                    this.puzzlePieces[nx].Children.Add(tile);
                    this.puzzlePieces[nx].MouseLeftButtonDown += this.PuzzlePiece_MouseLeftButtonDown;
                    if (nx < totalPieces - 1)
                    {
                        this.GameContainer.Children.Add(this.puzzlePieces[nx]);
                    }
                }
            }

            // Retrieve image
            StreamResourceInfo imageResource = Application.GetResourceStream(new Uri("WindowsPhonePuzzle;component/Assets/Tulips.jpg", UriKind.Relative));
            this.ImageStream = imageResource.Stream;

            this.game.Reset();
        }

        private void AnimatePiece(DependencyObject piece, DependencyProperty dp, double newValue)
        {
            Storyboard storyBoard = new Storyboard();
            Storyboard.SetTarget(storyBoard, piece);
            Storyboard.SetTargetProperty(storyBoard, new PropertyPath(dp));
            storyBoard.Children.Add(new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(200)),
                From = Convert.ToInt32(piece.GetValue(dp)),
                To = Convert.ToDouble(newValue),
                EasingFunction = new SineEase()
            });
            storyBoard.Begin();
        }

        private void PuzzlePiece_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.game.IsPlaying)
            {

                foreach (Canvas c in this.puzzlePieces)
                {
                    PuzzleTile tile = c.Children[0] as PuzzleTile;
                    tile.ShowNumberLabel();
                }

                this.game.NewGame();
            }
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            this.game.Reset();
            this.game.CheckWinner();

            foreach (Canvas c in this.puzzlePieces)
            {
                PuzzleTile tile = c.Children[0] as PuzzleTile;
                tile.HideNumberLabel();
            }
        }

        private void PhoneApplicationPage_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            if (this.game.IsPlaying)
            {
                // walk the up the tree to find the puzzle piece

                FrameworkElement parent = VisualTreeHelper.GetParent(e.ManipulationContainer) as FrameworkElement;
                while (parent as PuzzleTile == null)
                {
                    if (parent == null) return;
                    parent = VisualTreeHelper.GetParent(parent) as FrameworkElement;
                }

                if (parent.GetValue(FrameworkElement.NameProperty).ToString().StartsWith("PuzzleImage_"))
                {
                    int pieceIx = Convert.ToInt32(parent.GetValue(FrameworkElement.NameProperty).ToString().Substring(12));
                    Canvas piece = this.FindName("PuzzlePiece_" + pieceIx) as Canvas;
                    if (piece != null)
                    {
                        int totalPieces = this.game.ColsAndRows * this.game.ColsAndRows;
                        for (int i = 0; i < totalPieces; i++)
                        {
                            if (piece == this.puzzlePieces[i] && this.game.CanMovePiece(i) > 0)
                            {
                                int direction = this.game.CanMovePiece(i);
                                DependencyProperty axisProperty = (direction % 2 == 0) ? Canvas.LeftProperty : Canvas.TopProperty;
                                this.movingPieceDirection = direction;
                                this.movingPieceStartingPosition = Convert.ToDouble(piece.GetValue(axisProperty));
                                this.movingPieceId = i;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void PhoneApplicationPage_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (this.movingPieceId > -1)
            {
                int pieceSize = ImageSize / this.game.ColsAndRows;
                Canvas movingPiece = this.puzzlePieces[this.movingPieceId];

                // validate direction
                DependencyProperty axisProperty;
                double normalizedValue;

                if (this.movingPieceDirection % 2 == 0)
                {
                    axisProperty = Canvas.LeftProperty;
                    normalizedValue = e.CumulativeManipulation.Translation.X;
                }
                else
                {

                    axisProperty = Canvas.TopProperty;
                    normalizedValue = e.CumulativeManipulation.Translation.Y;
                }

                // enforce drag constraints
                // (top or left)
                if (this.movingPieceDirection == 1 || this.movingPieceDirection == 4)
                {
                    if (normalizedValue < -pieceSize)
                    {
                        normalizedValue = -pieceSize;
                    }
                    else if (normalizedValue > 0)
                    {
                        normalizedValue = 0;
                    }
                }
                // (bottom or right)
                else if (this.movingPieceDirection == 3 || this.movingPieceDirection == 2)
                {
                    if (normalizedValue > pieceSize)
                    {
                        normalizedValue = pieceSize;
                    }
                    else if (normalizedValue < 0)
                    {
                        normalizedValue = 0;
                    }
                }

                // set position
                movingPiece.SetValue(axisProperty, normalizedValue + this.movingPieceStartingPosition);
            }

        }

        private void PhoneApplicationPage_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (this.movingPieceId > -1)
            {
                int pieceSize = ImageSize / this.game.ColsAndRows;
                Canvas piece = this.puzzlePieces[this.movingPieceId];

                // check for double tapping
                if (TimeSpan.FromTicks(DateTime.Now.Ticks - this.lastTapTicks).TotalMilliseconds < DoubleTapSpeed)
                {
                    // force move
                    this.game.MovePiece(this.movingPieceId);
                    this.lastTapTicks = int.MinValue;
                }
                else
                {
                    // calculate moved distance
                    DependencyProperty axisProperty = (this.movingPieceDirection % 2 == 0) ? Canvas.LeftProperty : Canvas.TopProperty;
                    double minRequiredDisplacement = pieceSize / 3;
                    double diff = Math.Abs(Convert.ToDouble(piece.GetValue(axisProperty)) - this.movingPieceStartingPosition);

                    // did it get halfway across?
                    if (diff > minRequiredDisplacement)
                    {
                        // move piece
                        this.game.MovePiece(this.movingPieceId);
                    }
                    else
                    {
                        // restore piece
                        this.AnimatePiece(piece, axisProperty, this.movingPieceStartingPosition);
                    }
                }

                this.movingPieceId = -1;
                this.movingPieceStartingPosition = 0;
                this.movingPieceDirection = 0;
                this.lastTapTicks = DateTime.Now.Ticks;
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var gameState = IsolatedStorageHelper.GetObject<PuzzleState>("PuzzleState");
            if (gameState == null)
            {
                MessageBox.Show("Sorry, no game state found.", "Oops!", MessageBoxButton.OK);
            }
            else
            {
                // set game state
                this.game.SetState(gameState);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // save game state
            PuzzleState gameState = this.game.GetState();
            IsolatedStorageHelper.SaveObject("PuzzleState", gameState);
        }

        private void ClearStorageButton_Click(object sender, RoutedEventArgs e)
        {
            // remove state and image
            IsolatedStorageHelper.DeleteObject("PuzzleState");
        }
    }
}