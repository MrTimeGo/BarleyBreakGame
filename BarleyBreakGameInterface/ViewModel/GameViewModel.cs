using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using BarleyBreakGameInterface.ViewModel.Command;
using BarleyBreakGameInterface.Model;
using BarleyBreakGameInterface.View;
using BarleyBreakGameInterface.Service;
using BarleyBreakGameInterface.Dao;

namespace BarleyBreakGameInterface.ViewModel
{
    public class GameViewModel
    {
        Grid gameGrid;
        DispatcherTimer gameTimer;

        public Record Record { get; set; }

        public GameViewModel(Grid gameGrid)
        {
            this.gameGrid = gameGrid;
            InitializeButtons();
            InitializePlayer();
            InitializeTimer();
            InitializeStepCounter();
        }

        private void InitializeStepCounter()
        {
            moveTile.Record = Record;
        }

        private void InitializeTimer()
        {
            gameTimer = new DispatcherTimer();
            var interval = new TimeSpan(0, 0, 0, 1);
            gameTimer.Interval = interval;
            gameTimer.Tick += (s, e) =>
            {
                Record.Time = Record.Time.Add(interval);
            };
            gameTimer.Start();
        }

        private void InitializePlayer()
        {
            var playerNameDialog = new PlayerNameDialog();
            bool? dialogResult = playerNameDialog.ShowDialog();
            if(!dialogResult.HasValue || !dialogResult.Value)
            {
                throw new ArgumentException("No player");
            }
            Record = new Record()
            {
                PlayerName = playerNameDialog.PlayerName,
                Time = new TimeSpan(),
                StepsConter = 0
            };
        }

        private void InitializeButtons()
        {
            MatrixHadler matrixHadler = new MatrixHadler();
            var buttonMatrix = matrixHadler.GenerateButtonMatrix();
            moveTile = new MoveTileCommand(matrixHadler);
            SetCommandToButtons(buttonMatrix);
            DisplayButtons(buttonMatrix);

            matrixHadler.OnGameWon += (sender, args) =>
            {
                gameTimer.Stop();
                MessageBox.Show("Congratulations, you win!", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                DataFileTemplate dataFile = new JsonDataFile("datafile.json");
                dataFile.InsertRecord(Record);
                Navigator.NavigationService.GoBack();
            };
        }

        MoveTileCommand moveTile;

        public ICommand MoveTile 
        { 
            get
            {
                return moveTile;
            }
        }

        private void SetCommandToButtons(Button[,] buttonMatrix)
        {
            for (int i = 0; i < buttonMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < buttonMatrix.GetLength(1); j++)
                {
                    if (buttonMatrix[i, j] != null)
                    {
                        buttonMatrix[i, j].Command = MoveTile;
                        buttonMatrix[i, j].CommandParameter = buttonMatrix[i, j].Content.ToString();
                    }
                }
            }
        }

        private void DisplayButtons(Button[,] buttons)
        {
            for(int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i,j] != null)
                    {
                        gameGrid.Children.Add(buttons[i, j]);
                        Grid.SetColumn(buttons[i, j], i);
                        Grid.SetRow(buttons[i, j], j);
                    }
                }
            }
        }
    }
}
