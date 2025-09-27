namespace TicTacToe
{
    public static class UI
    {
        /// <summary>
        /// Display the Welcome message for the player
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("-----------------------------------------------------------\n");
            Console.WriteLine("                  Welcome to Tic-Tac-Toe!!!                  ");
            Console.WriteLine("You will be facing off against the best AI ever! Good luck!");
            Console.WriteLine("\n-----------------------------------------------------------\n");
        }

        /// <summary>
        /// Displays the instructions for how to play the game
        /// </summary>
        public static void DisplayHowToPlay()
        {
            Console.WriteLine("\n-------------- How to play --------------\n");
            Console.WriteLine("You will be X | The AI is O");
            Console.WriteLine("Enter a row and column as numbers 1, 2, 3, etc.");
            Console.WriteLine("\n-----------------------------------------\n");
        }

        /// <summary>
        /// Asks the player if they would like to continue playing or if they would like to exit the game
        /// </summary>
        /// <returns>False - Player does not want to play, True - Player wants to keep playing the game</returns>
        public static bool AskToPlayGameAgain(char playAgainChar)
        {
            Console.WriteLine();
            Console.WriteLine("Want to play again? (Y/N): ");
            ConsoleKeyInfo playAgainInput = Console.ReadKey();
            char playAgain = char.ToLower(playAgainInput.KeyChar);
            if (playAgain != playAgainChar)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Displays the tic tac toe board
        /// </summary>
        /// <param name="board">This is the Tic-Tac-Toe game board which will be displayed on the console.</param>
        public static bool firstPrint = true;
        public static void DisplayBoard(char[,] board)
        {
            if (!firstPrint)
            {
                Console.Clear();
            }
            else
            {
                firstPrint = false;
            }

            int boardLength = board.GetLength(0);

            Console.Write("   ");
            for (int c = 0; c < boardLength; c++)
            {
                Console.Write($"{c + 1}   ");
            }
            Console.WriteLine();

            for (int r = 0; r < boardLength; r++)
            {
                Console.Write($" {r + 1} ");
                for (int c = 0; c < boardLength; c++)
                {
                    // If the spot is empty -> keep a \0 (which is nothing), If the spot is not empty -> display X or O
                    char cell = board[r, c];
                    if (cell == '\0')
                    {
                        cell = ' ';
                    }
                    Console.Write(cell);
                    if (c < boardLength - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (r < boardLength - 1)
                {
                    Console.Write("   ");
                    for (int c = 0; c < boardLength - 1; c++)
                    {
                        Console.Write("---+");
                    }
                    Console.WriteLine("---");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Asks the player which row they would like to play on
        /// </summary>
        /// <returns>Row number that the player chose</returns>
        public static int AskForPlayerRow(char[,] board)
        {
            int boardLength = board.GetLength(0);
            int row = AskForPlayerInput($"Choose a Row (1-{boardLength}): ", boardLength);

            return row - 1;
        }

        /// <summary>
        /// Asks the player which column they would like to play on
        /// </summary>
        /// <returns>Column number that the player chose</returns>
        public static int AskForPlayerCol(char[,] board)
        {
            int boardLength = board.GetLength(0);
            int col = AskForPlayerInput($"Choose a Column (1-{boardLength}): ", boardLength);

            return col - 1;
        }

        /// <summary>
        /// Asks for the player input (row or column) based on the prompt that is given
        /// </summary>
        /// <param name="prompt">This is the question asked before allowing the player to input something.</param>
        /// <returns>The value which the player has entered in the console.</returns>
        public static int AskForPlayerInput(string prompt, int maxSize)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int num) && num >= 1 && num <= maxSize)
                {
                    return num;
                }

                Console.WriteLine($"Please enter a number between 1 and {maxSize}.");
            }
        }

        /// <summary>
        /// Tell the player that there was an invalid move made
        /// </summary>
        public static void DisplayInvalidMove()
        {
            Console.WriteLine("The chosen cell is not available to play. Please try again.");
        }

        /// <summary>
        /// Announces the winner of the game
        /// </summary>
        /// <param name="winner">This is the winner of the game (either YOU or AI)</param>
        public static void DisplayWinner(string winner)
        {
            Console.WriteLine();
            Console.WriteLine($"The winner is {winner}");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays that the game is a tie and is over
        /// </summary>
        public static void DisplayTie()
        {
            Console.WriteLine();
            Console.WriteLine("It is a tie game!");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the AI move on the console for the player to see
        /// </summary>
        /// <param name="row">This is the row which the AI has made a move.</param>
        /// <param name="col">This is the column which the AI has made a move.</param>
        public static void DisplayAIMove(int row, int col)
        {
            Console.WriteLine($"The AI has played at ({row + 1}, {col + 1}).");
        }

        /// <summary>
        /// Displays the ending message before exiting the game
        /// </summary>
        public static void ThankYouForPlaying()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("      Thank you for playing!     ");
            Console.WriteLine("---------------------------------");

        }
    }
}
