using BarleyBreakGameInterface.Model;
using BarleyBreakGameInterface.Model.Style;
using System.Windows.Controls;
using BarleyBreakGameInterface.Service;

namespace BarleyBreakGameInterface.View
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
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
                    StartButton,
                    RecordsButton,
                    ExitButton,
                    ChangeStyleButton
                });
            styler.ApplyBorderStyleOnContorls(new Control[]
                {
                    StartButton,
                    RecordsButton,
                    ExitButton,
                    ChangeStyleButton
                });
            styler.ApplyFontStyleOnContorls(new Control[]
                {
                    StartButton,
                    RecordsButton,
                    ExitButton,
                    ChangeStyleButton,
                    TitleLabel
                });
            styler.ApplyForegroudStyleOnContorls(new Control[]
                {
                    StartButton,
                    RecordsButton,
                    ExitButton,
                    ChangeStyleButton,
                    TitleLabel
                });
        }
    }
}
