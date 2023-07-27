using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RectangleMVVMBusinessLogic.BusinessLogic.Models
{
    public class RectangleModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public SolidColorBrush Color { get; set; }
        public bool IsMarkedForDeletion { get; set; }
    }
}
