using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        private DispatcherTimer timer;
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
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var rectangle = new RectangleModel()
            {
                X = random.Next(0, 500),
                Y = random.Next(0, 500),
                Width = random.Next(30, 100),
                Height = random.Next(30, 100),
                Color = GetRandomColor()
            };

            rectangles.Add(rectangle);
        }

        private SolidColorBrush GetRandomColor()
        {
            var color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            return new SolidColorBrush(color);
        }

        public void InitializeRectangles()
        {
            rectangles.Add(new RectangleModel() { X = 100, Y = 100, Width = 50, Height = 50, Color = Brushes.Red });
            rectangles.Add(new RectangleModel() { X = 200, Y = 200, Width = 60, Height = 40, Color = Brushes.Blue });
            rectangles.Add(new RectangleModel() { X = 300, Y = 300, Width = 70, Height = 70, Color = Brushes.Green });
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
