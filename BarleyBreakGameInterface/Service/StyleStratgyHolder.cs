using BarleyBreakGameInterface.Model.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreakGameInterface.Service
{
    public class StyleStratgyHolder
    {
        private StyleStratgyHolder()
        {
            CurrentStyleStrategy = styles[currentIndex % styles.Length];

        }
        public static StyleStratgyHolder Instance { get; } = new StyleStratgyHolder();


        public event EventHandler OnCurrentStyleStrategyChanged;

        StyleImplementation currentStyleStrategy;
        public StyleImplementation CurrentStyleStrategy
        {
            get
            {
                return currentStyleStrategy ??= new PeridotStyle();
            }
            private set
            {
                currentStyleStrategy = value;
                OnCurrentStyleStrategyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        StyleImplementation[] styles = new StyleImplementation[] { new PeridotStyle(), new RubitStyle(), new MinimalisticStyle() };

        private int currentIndex = 0;

        public void Next()
        {
            currentIndex = (currentIndex + 1) % styles.Length;
            CurrentStyleStrategy = styles[currentIndex];
        }
    }
}
