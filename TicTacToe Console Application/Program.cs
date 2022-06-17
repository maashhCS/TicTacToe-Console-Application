using System;

namespace TicTacToe_Console_Application
{
    class Program
    {
        public static string[] userGameBoard = new string[9];
        public static int players = 2;
        public static int zug = 0;
        public static bool stillPlaying = true;
        public static int playerChoice;
        public static string playerText = "X";
        public static bool userNumRight = false;
        static void Main(string[] args)
        {
            reset();
            All();
        }

        public static void GameBoard()
        {
            Console.WriteLine($"{userGameBoard[0]}|{userGameBoard[1]}|{userGameBoard[2]}");
            Console.WriteLine($"- - -");
            Console.WriteLine($"{userGameBoard[3]}|{userGameBoard[4]}|{userGameBoard[5]}");
            Console.WriteLine($"- - -");
            Console.WriteLine($"{userGameBoard[6]}|{userGameBoard[7]}|{userGameBoard[8]}");
        }

        public static bool IsWinner()
        {
            //horizontal
            if ((userGameBoard[0] == userGameBoard[1]) && (userGameBoard[1] == userGameBoard[2]) && userGameBoard[0] != " ")
                return true;
            if ((userGameBoard[3] == userGameBoard[4]) && (userGameBoard[4] == userGameBoard[5]) && userGameBoard[3] != " ")
                return true;
            if ((userGameBoard[6] == userGameBoard[7]) && (userGameBoard[7] == userGameBoard[8]) && userGameBoard[6] != " ")
                return true;

            //vertical
            if ((userGameBoard[0] == userGameBoard[3]) && (userGameBoard[3] == userGameBoard[6]) && userGameBoard[0] != " ")
                return true;
            if ((userGameBoard[1] == userGameBoard[4]) && (userGameBoard[4] == userGameBoard[7]) && userGameBoard[1] != " ")
                return true;
            if ((userGameBoard[2] == userGameBoard[5]) && (userGameBoard[5] == userGameBoard[8]) && userGameBoard[2] != " ")
                return true;

            //diagonal
            if ((userGameBoard[0] == userGameBoard[4]) && (userGameBoard[4] == userGameBoard[8]) && userGameBoard[0] != " ")
                return true;
            if ((userGameBoard[6] == userGameBoard[4]) && (userGameBoard[4] == userGameBoard[2]) && userGameBoard[6] != " ")
                return true;
            else
                return false;

        }

        public static bool IsDraw()
        {
            if ((zug == 9) && (IsWinner() == false))
                return true;
            else
                return false;
        }
        public static void reset()
        {
            zug = 0;
            userGameBoard[0] = " "; userGameBoard[1] = " "; userGameBoard[2] = " "; userGameBoard[3] = " "; userGameBoard[4] = " "; userGameBoard[5] = " "; userGameBoard[6] = " "; userGameBoard[7] = " "; userGameBoard[8] = " ";
        }
        public static void GameCheck()
        {
            if (players % 2 == 0)
            {
                playerText = "X";
                players++;
                zug++;
            }
            else
            {
                playerText = "Y";
                players++;
                zug++;
            }

            if (IsDraw() == true)
            {
                Console.WriteLine("It's a Draw!");
                stillPlaying = false;
            }

            if (IsWinner() == true)
            {
                if (playerText == "Y")
                {
                    Console.WriteLine("Player1 won!");
                    stillPlaying = false;
                }
                else
                {
                    Console.WriteLine("Player2 won!");
                    stillPlaying = false;
                }
            }
            userNumRight = false;
            if (IsWinner() == !true)
            {
                while (!userNumRight)
                {
                    playerChoice = 10;
                    Console.Write($"Player please pick a field from 1 to 9: ");
                    playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (userGameBoard[playerChoice] == " ")
                    {
                        userGameBoard[playerChoice] = playerText;
                        userNumRight = true;
                    }
                    else
                        Console.WriteLine("This field has already been picked try again.");
                }
            }

        }
        static void All()
        {
            while (stillPlaying)
            {
                GameBoard();
                GameCheck();
            }
        }
    }
}
