using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BarleyBreakGameInterface.Model.Style
{
    internal class MinimalisticStyle : StyleImplementation
    {
        public override Color PrimaryColor { get; } = Color.FromRgb(71, 68, 68);

        public override Color SecondaryColor => Color.FromRgb(71, 68, 68);

        public override Color BorderColor => Color.FromRgb(241, 241, 241);

        public override Color FontColor => Color.FromRgb(241, 241, 241);

        public override FontFamily FontFamily => new FontFamily("Arial");
    }
}
