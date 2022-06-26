using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BarleyBreakGameInterface.Model.Style
{
    public class PeridotStyle : StyleImplementation
    {
        public override Color PrimaryColor { get; } = Color.FromRgb(144, 3, 252);

        public override Color SecondaryColor { get; } = Color.FromRgb(252, 186, 3);

        public override Color BorderColor { get; } = Color.FromRgb(230, 230, 250);

        public override Color FontColor { get; } = Color.FromRgb(255, 255, 255);

        public override FontFamily FontFamily { get; } = new FontFamily("Arial");
    }
}
