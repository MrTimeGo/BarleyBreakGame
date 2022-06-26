using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BarleyBreakGameInterface.Model.Style
{
    public class RubitStyle : StyleImplementation
    {
        public override Color PrimaryColor { get; } = Color.FromRgb(255, 89, 89);

        public override Color SecondaryColor { get; } = Color.FromRgb(173, 109, 5);

        public override Color BorderColor { get; } = Color.FromRgb(247, 213, 109);

        public override Color FontColor { get; } = Color.FromRgb(238, 245, 47);

        public override FontFamily FontFamily { get; } = new FontFamily("Arial");
    }
}