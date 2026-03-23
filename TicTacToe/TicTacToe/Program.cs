using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void DrawBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        static int CheckWin()
        {
            // Горизонтальные линии
            if (board[1] == board[2] && board[2] == board[3])
                return 1;
            else if (board[4] == board[5] && board[5] == board[6])
                return 1;
            else if (board[7] == board[8] && board[8] == board[9])
                return 1;
            // Вертикальные линии
            else if (board[1] == board[4] && board[4] == board[7])
                return 1;
            else if (board[2] == board[5] && board[5] == board[8])
                return 1;
            else if (board[3] == board[6] && board[6] == board[9])
                return 1;
            // Диагонали
            else if (board[1] == board[5] && board[5] == board[9])
                return 1;
            else if (board[3] == board[5] && board[5] == board[7])
                return 1;
            // Ничья
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' &&
                     board[4] != '4' && board[5] != '5' && board[6] != '6' &&
                     board[7] != '7' && board[8] != '8' && board[9] != '9')
                return -1;
            else
                return 0;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Игрок 1: X  и  Игрок 2: O");
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Ход Игрока 2 (O)");
                }
                else
                {
                    Console.WriteLine("Ход Игрока 1 (X)");
                }

                DrawBoard();

                Console.WriteLine("\nВведите номер клетки (1-9):");
                choice = Convert.ToInt32(Console.ReadLine());

                if (board[choice] != 'X' && board[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        board[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        board[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Клетка {0} уже занята!", choice);
                    Console.WriteLine("Подождите секунду...");
                    System.Threading.Thread.Sleep(1000);
                }

                flag = CheckWin();
            } while (flag == 0);

            Console.Clear();
            DrawBoard();

            if (flag == 1)
            {
                if ((player - 1) % 2 == 0)
                {
                    Console.WriteLine("Игрок 2 (O) победил!");
                }
                else
                {
                    Console.WriteLine("Игрок 1 (X) победил!");
                }
            }
            else
            {
                Console.WriteLine("Ничья!");
            }

            Console.ReadLine();
        }
    }
}