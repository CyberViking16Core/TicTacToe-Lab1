using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = new char[10];
        static int player;
        static int choice;
        static int flag;

        // Счетчик побед
        static int player1Score = 0;
        static int player2Score = 0;

        // Кастомизация символов
        static char player1Symbol = 'X';
        static char player2Symbol = 'O';

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

        static void ResetBoard()
        {
            for (int i = 1; i <= 9; i++)
            {
                board[i] = char.Parse(i.ToString());
            }
            player = 1;
            flag = 0;
        }

        static void CustomizeSymbols()
        {
            Console.Clear();
            Console.WriteLine("=== КАСТОМИЗАЦИЯ СИМВОЛОВ ===");
            Console.WriteLine($"Текущий символ Игрока 1: {player1Symbol}");
            Console.WriteLine($"Текущий символ Игрока 2: {player2Symbol}");
            Console.WriteLine("\nВведите новый символ для Игрока 1 (один символ):");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                player1Symbol = input[0];
            }

            Console.WriteLine("Введите новый символ для Игрока 2 (один символ):");
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                player2Symbol = input[0];
            }
            Console.WriteLine("\nСимволы обновлены! Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Console.WriteLine("========== КРЕСТИКИ-НОЛИКИ v2.0 ==========");
                Console.WriteLine($"СЧЕТ: Игрок 1 ({player1Symbol}) - {player1Score} : {player2Score} - Игрок 2 ({player2Symbol})");
                Console.WriteLine("\n1. Начать игру");
                Console.WriteLine("2. Кастомизировать символы");
                Console.WriteLine("3. Выйти");
                Console.Write("\nВыберите действие: ");
                string menuChoice = Console.ReadLine();

                if (menuChoice == "2")
                {
                    CustomizeSymbols();
                    continue;
                }
                else if (menuChoice == "3")
                {
                    playAgain = false;
                    break;
                }
                else if (menuChoice != "1")
                {
                    continue;
                }

                ResetBoard();

                do
                {
                    Console.Clear();
                    Console.WriteLine($"СЧЕТ: {player1Score} : {player2Score}");
                    Console.WriteLine($"Игрок 1: {player1Symbol}  |  Игрок 2: {player2Symbol}");
                    Console.WriteLine("\n");

                    if (player % 2 == 0)
                    {
                        Console.WriteLine($"Ход Игрока 2 ({player2Symbol})");
                    }
                    else
                    {
                        Console.WriteLine($"Ход Игрока 1 ({player1Symbol})");
                    }

                    DrawBoard();
                    Console.Write("\nВведите номер клетки (1-9): ");

                    if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9)
                    {
                        Console.WriteLine("Некорректный ввод! Введите число от 1 до 9.");
                        System.Threading.Thread.Sleep(1500);
                        continue;
                    }

                    if (board[choice] != player1Symbol && board[choice] != player2Symbol)
                    {
                        if (player % 2 == 0)
                        {
                            board[choice] = player2Symbol;
                            player++;
                        }
                        else
                        {
                            board[choice] = player1Symbol;
                            player++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Клетка {choice} уже занята!");
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
                        Console.WriteLine($"\nИгрок 2 ({player2Symbol}) ПОБЕДИЛ!");
                        player2Score++;
                    }
                    else
                    {
                        Console.WriteLine($"\nИгрок 1 ({player1Symbol}) ПОБЕДИЛ!");
                        player1Score++;
                    }
                }
                else
                {
                    Console.WriteLine("\nНИЧЬЯ!");
                }

                Console.WriteLine($"\nТЕКУЩИЙ СЧЕТ: {player1Score} : {player2Score}");
                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }
    }
}