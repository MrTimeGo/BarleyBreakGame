using BarleyBreakGameInterface.Model;
using BarleyBreakGameInterface.Model.Style;
using BarleyBreakGameInterface.Service;
using BarleyBreakGameInterface.ViewModel;
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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {

        public GamePage()
        {
            InitializeComponent();
            try
            {
                DataContext = new GameViewModel(ButtonsGrid);
            }
            catch (Exception ex)
            {
                this.Loaded += (s, e) =>
                Navigator.NavigationService.GoBack();
                
            }
            ApplyStyles(StyleStratgyHolder.Instance.CurrentStyleStrategy);
            StyleStratgyHolder.Instance.OnCurrentStyleStrategyChanged += (sender, args) =>
            {
                var styler = StyleStratgyHolder.Instance.CurrentStyleStrategy;
                ApplyStyles(styler);
            };
        }

        private void ApplyStyles(StyleImplementation styler)
        {
            var gameButtons = ButtonsGrid.Children.Cast<Control>();
            styler.ApplyStyleOnPageBackground(this);
            styler.ApplyBackgroudStyleOnControls(gameButtons);
            styler.ApplyBackgroudStyleOnControls(new Control[]
                {
                    GiveUpButton
                });
            styler.ApplyBorderStyleOnContorls(gameButtons);
            styler.ApplyBorderStyleOnContorls(new Control[]
                {
                    GiveUpButton,
                });
            styler.ApplyFontStyleOnContorls(gameButtons);
            styler.ApplyFontStyleOnContorls(new Control[]
                {
                    GiveUpButton,
                    StepsLabel,
                    TimerLabel,
                    UserNameLabel,
                    Timer,
                    StepsCounter
                });
            styler.ApplyForegroudStyleOnContorls(gameButtons);
            styler.ApplyForegroudStyleOnContorls(new Control[]
                {
                    GiveUpButton,
                    StepsLabel,
                    TimerLabel,
                    UserNameLabel,
                    Timer,
                    StepsCounter
                });
            GameBorder.BorderBrush = GiveUpButton.BorderBrush;
        }
    }
}
