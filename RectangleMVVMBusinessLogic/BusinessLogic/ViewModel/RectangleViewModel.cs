using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using RectangleMVVMBusinessLogic.BusinessLogic.Models;

namespace RectangleMVVMBusinessLogic.BusinessLogic.ViewModel
    {
        public class RectangleViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<RectangleModel> rectangles = new ObservableCollection<RectangleModel>();
            private Random random = new Random();
            private DispatcherTimer addTimer;
            private DispatcherTimer removeTimer;
            private const int N = 5;

            public event PropertyChangedEventHandler PropertyChanged;

            public ObservableCollection<RectangleModel> Rectangles
            {
                get { return rectangles; }
                set
                {
                    rectangles = value;
                    OnPropertyChanged(nameof(Rectangles));
                }
            }

            public RectangleViewModel()
            {
                addTimer = new DispatcherTimer();
                addTimer.Interval = TimeSpan.FromSeconds(1);
                addTimer.Tick += AddTimer_Tick;
                addTimer.Start();

                removeTimer = new DispatcherTimer();
                removeTimer.Interval = TimeSpan.FromSeconds(1);
                removeTimer.Tick += RemoveTimer_Tick;
                removeTimer.Start();
            }

            private void AddTimer_Tick(object sender, EventArgs e)
            {
                var rectangle = new RectangleModel()
                {
                    CanvasLeft = random.Next(0, 500),
                    CanvasTop = random.Next(0, 500),
                    Width = random.Next(30, 100),
                    Height = random.Next(30, 100),
                    Color = GetRandomColor(),
                    RemoveAfterCycles = N
                };

                foreach (var existingRectangle in rectangles)
                {
                    if (RectangleIntersects(rectangle, existingRectangle))
                    {
                        existingRectangle.IsVisible = false;
                    }
                }

                rectangles.Add(rectangle);
            }

            private void RemoveTimer_Tick(object sender, EventArgs e)
            {
                foreach (var rectangle in rectangles.ToList())
                {
                    rectangle.DecreaseCycles();
                    if (rectangle.RemoveAfterCycles <= 0)
                    {
                        rectangles.Remove(rectangle);
                    }
                }
            }
            private bool RectangleIntersects(RectangleModel rectangle1, RectangleModel rectangle2)
            {
                return rectangle1.CanvasLeft < rectangle2.CanvasLeft + rectangle2.Width &&
                       rectangle1.CanvasLeft + rectangle1.Width > rectangle2.CanvasLeft &&
                       rectangle1.CanvasTop < rectangle2.CanvasTop + rectangle2.Height &&
                       rectangle1.CanvasTop + rectangle1.Height > rectangle2.CanvasTop;
            }

            private SolidColorBrush GetRandomColor()
            {
                var color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                return new SolidColorBrush(color);
            }

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }