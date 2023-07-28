using RectangleMVVMBusinessLogic.BusinessLogic.ViewModel;
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
        public double CanvasLeft { get; set; }
        public double CanvasTop { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public SolidColorBrush Color { get; set; }
        public bool IsVisible { get; set; } = true;
        public int RemoveAfterCycles { get; set; }
        public bool MarkedForDeletion { get; set; }
        public int CyclesLeft { get; set; }
    }
}
