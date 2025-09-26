using static TicTacToe.GlobalVariabes;

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
            Console.WriteLine("Enter a row and column as numbers 1-3.");
            Console.WriteLine("\n-----------------------------------------\n");
        }

        /// <summary>
        /// Asks the player if they would like to continue playing or if they would like to exit the game
        /// </summary>
        /// <returns>False - Player does not want to play, True - Player wants to keep playing the game</returns>
        public static bool AskToPlayGameAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Want to spin again? (Y/N): ");
            ConsoleKeyInfo playAgainInput = Console.ReadKey();
            char playAgain = char.ToLower(playAgainInput.KeyChar);
            if (playAgain != PLAY_AGAIN)
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

                Console.WriteLine();
            Console.WriteLine("   1   2   3");
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                Console.Write($" {r + 1} ");
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    // If the spot is empty -> keep a \0 (which is nothing), If the spot is not empty -> display X or O
                    char cell = board[r, c];
                    if (cell == '\0')
                    {
                        cell = ' ';
                    }
                    Console.Write(cell);
                    if (c < BOARD_SIZE - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (r < BOARD_SIZE - 1)
                {
                    Console.WriteLine("  ---+---+---");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Asks the player which row they would like to play on
        /// </summary>
        /// <returns>Row number that the player chose</returns>
        public static int AskForPlayerRow()
        {
            int row = AskForPlayerInput("Choose a Row (1-3): ");

            return row - 1;
        }

        /// <summary>
        /// Asks the player which column they would like to play on
        /// </summary>
        /// <returns>Column number that the player chose</returns>
        public static int AskForPlayerCol()
        {
            int col = AskForPlayerInput("Choose a Column (1-3): ");

            return col - 1;
        }

        /// <summary>
        /// Asks for the player input (row or column) based on the prompt that is given
        /// </summary>
        /// <param name="prompt">This is the question asked before allowing the player to input something.</param>
        /// <returns>The value which the player has entered in the console.</returns>
        public static int AskForPlayerInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int num) && num >= 1 && num <= BOARD_SIZE)
                {
                    return num;
                }

                Console.WriteLine("Please enter a number between 1 and 3.");
            }
        }
    }
}
