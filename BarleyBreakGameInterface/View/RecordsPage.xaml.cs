using BarleyBreakGameInterface.Model.Style;
using BarleyBreakGameInterface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarleyBreakGameInterface.View
{
    /// <summary>
    /// Interaction logic for RecordsPage.xaml
    /// </summary>
    public partial class RecordsPage : Page
    {
        public RecordsPage()
        {
            InitializeComponent();
            ApplyStyles(StyleStratgyHolder.Instance.CurrentStyleStrategy);
            StyleStratgyHolder.Instance.OnCurrentStyleStrategyChanged += (sender, args) =>
            {
                var styler = StyleStratgyHolder.Instance.CurrentStyleStrategy;
                ApplyStyles(styler);
            };
        }

        private void ApplyStyles(StyleImplementation styler)
        {
            styler.ApplyStyleOnPageBackground(this);
            styler.ApplyBackgroudStyleOnControls(new Control[]
                {
                    ToMainMenuButton,
                    ExportJsonButton,
                    ExportXmlButton
                });
            styler.ApplyBorderStyleOnContorls(new Control[]
                {
                    ToMainMenuButton,
                    ExportJsonButton,
                    ExportXmlButton
                });
            styler.ApplyFontStyleOnContorls(new Control[]
                {
                    ToMainMenuButton,
                    ExportJsonButton,
                    ExportXmlButton
                });
            styler.ApplyForegroudStyleOnContorls(new Control[]
                {
                    ToMainMenuButton,
                    ExportJsonButton,
                    ExportXmlButton
                });
        }
    }
}
