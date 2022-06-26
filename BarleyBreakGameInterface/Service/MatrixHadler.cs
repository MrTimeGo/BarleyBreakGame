using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BarleyBreakGameInterface.Service
{
    public class MatrixHadler
    {
        Button[,] buttonsMatrix;

        public EventHandler OnGameWon { get; set; }

        private bool CanMove((int, int) indexes)
        {
            return (indexes.Item1 != -1 && indexes.Item2 != -1) && (
                (indexes.Item1 - 1 >= 0 && buttonsMatrix[indexes.Item1 - 1, indexes.Item2] == null) ||
                (indexes.Item1 + 1 <= 3 && buttonsMatrix[indexes.Item1 + 1, indexes.Item2] == null) ||
                (indexes.Item2 - 1 >= 0 && buttonsMatrix[indexes.Item1, indexes.Item2 - 1] == null) ||
                (indexes.Item2 + 1 <= 3 && buttonsMatrix[indexes.Item1, indexes.Item2 + 1] == null)
                );
        }

        private (int, int) FindIndexes(string content)
        {
            for (int i = 0; i < buttonsMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < buttonsMatrix.GetLength(1); j++)
                {
                    if (buttonsMatrix[i, j] != null && buttonsMatrix[i, j].Content.ToString() == content)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        private (int, int) FindNullButtonIndexes()
        {
            for (int i = 0; i < buttonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < buttonsMatrix.GetLength(1); j++)
                {
                    if (buttonsMatrix[i, j] == null)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        private void SwapInMatrix((int, int) target, (int, int) destination)
        {
            Button temp = buttonsMatrix[target.Item1, target.Item2];
            buttonsMatrix[target.Item1, target.Item2] = buttonsMatrix[destination.Item1, destination.Item2];
            buttonsMatrix[destination.Item1, destination.Item2] = temp;
        }

        private void SwapInDisplay((int, int) indexes)
        {
            Grid.SetColumn(buttonsMatrix[indexes.Item1, indexes.Item2], indexes.Item1);
            Grid.SetRow(buttonsMatrix[indexes.Item1, indexes.Item2], indexes.Item2);
        }

        public bool Handle(string content)
        {
            (int, int) indexes = FindIndexes(content);

            if (!CanMove(indexes))
            {
                return false;
            }

            (int, int) nullIndexes = FindNullButtonIndexes();
            SwapInMatrix(indexes, nullIndexes);
            SwapInDisplay(nullIndexes);
            if (CheckWinningScenario())
            {
                OnGameWon?.Invoke(this, EventArgs.Empty);
            }
            return true;
        }

        private Button[,] GenerateCompletedButtonMatrix()
        {
            int size = 4;
            Button[,] buttons = new Button[size, size];
            for (int i = 0, h = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++, h++)
                {
                    if (h == 15)
                    {
                        continue;
                    }
                    buttons[i, j] = new Button()
                    {
                        Content = (h+1).ToString(),
                        FontSize = 52,
                        Width = 100,
                        Height = 100,
                        Padding = new Thickness(10),
                        Margin = new Thickness(20),
                        BorderThickness = new Thickness(3),
                    };
                }
            }
            return buttons;
        }

        private (int, int) GetRandomNeighbourCell((int,int) indexes, Random rnd)
        {
            List<(int, int)> availableNeighbours = new List<(int, int)>();

            if (indexes.Item1 + 1 <= 3)
            {
                availableNeighbours.Add((indexes.Item1 + 1, indexes.Item2));
            }
            if(indexes.Item2 + 1 <= 3)
            {
                availableNeighbours.Add((indexes.Item1, indexes.Item2 + 1));
            }
            if(indexes.Item1 - 1 >= 0)
            {
                availableNeighbours.Add((indexes.Item1 - 1, indexes.Item2));
            }
            if(indexes.Item2 - 1 >= 0)
            {
                availableNeighbours.Add((indexes.Item1, indexes.Item2 - 1));
            }

            return availableNeighbours[rnd.Next(0, availableNeighbours.Count)];
        }

        private void ShuffleMatrix(Button[,] buttons)
        {
            Random rnd = new Random();
            int numberOfShuffles = rnd.Next(100, 150);

            for(int i = 0; i < numberOfShuffles; i++)
            {
                (int,int) nullButton = FindNullButtonIndexes();
                (int, int) swapFrom = GetRandomNeighbourCell(nullButton, rnd);
                if (CanMove(swapFrom))
                {
                    SwapInMatrix(swapFrom, nullButton);
                }
            }
        }

        public Button[,] GenerateButtonMatrix()
        {
            buttonsMatrix = GenerateCompletedButtonMatrix();
            ShuffleMatrix(buttonsMatrix);

            return buttonsMatrix;
        }

        private bool CheckWinningScenario()
        {
            for(int i = 0, h = 0; i < buttonsMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < buttonsMatrix.GetLength(0); j++, h++) 
                {
                    if (buttonsMatrix[j,i] != null && buttonsMatrix[j,i].Content.ToString() != (h + 1).ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
