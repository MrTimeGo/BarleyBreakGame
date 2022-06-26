using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BarleyBreakGameInterface.Model
{
    public class Record : INotifyPropertyChanged
    {
        string personName;
        TimeSpan time;
        int stepsCounter;

        public string PlayerName
        {
            get { return personName; }
            set 
            { 
                personName = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Time
        {
            get { return time; }
            set 
            { 
                time = value;
                OnPropertyChanged();
            }
        }

        public int StepsConter
        {
            get { return stepsCounter; }
            set 
            { 
                stepsCounter = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
