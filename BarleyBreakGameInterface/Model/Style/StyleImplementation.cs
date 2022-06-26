using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BarleyBreakGameInterface.Model.Style
{
    public abstract class StyleImplementation
    {
        public abstract Color PrimaryColor { get; }
        public abstract Color SecondaryColor { get; }
        public abstract Color BorderColor { get; }
        public abstract Color FontColor { get; }
        public abstract FontFamily FontFamily { get; }

        public void ApplyBackgroudStyleOnControls(IEnumerable<Control> controls)
        {
            ArgumentNullException.ThrowIfNull(controls, nameof(controls));
            
            foreach (var control in controls)
            {
                control.Background = new SolidColorBrush(SecondaryColor);
            }
        }

        public void ApplyForegroudStyleOnContorls(IEnumerable<Control> controls)
        {
            ArgumentNullException.ThrowIfNull(controls, nameof(controls));

            foreach(var control in controls)
            {
                control.Foreground = new SolidColorBrush(FontColor);
            }
        }

        public void ApplyFontStyleOnContorls(IEnumerable<Control> controls)
        {
            ArgumentNullException.ThrowIfNull(controls, nameof(controls));

            foreach (var control in controls)
            {
                control.FontFamily = FontFamily;
            }
        }

        public void ApplyBorderStyleOnContorls(IEnumerable<Control> controls)
        {
            ArgumentNullException.ThrowIfNull(controls, nameof(controls));

            foreach (var control in controls)
            {
                control.BorderBrush = new SolidColorBrush(BorderColor);
            }
        }

        public void ApplyStyleOnPageBackground(Page page)
        {
            ArgumentNullException.ThrowIfNull(page, nameof(page));

            page.Background = new SolidColorBrush(PrimaryColor);
        }
    }
}
