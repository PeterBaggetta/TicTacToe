namespace TicTacToe
{

    public static class Logic
    {
        /// <summary>
        /// Size of the Tic Tac Toe board. MUST BE ODD
        /// </summary>
        public const int BOARD_SIZE = 3;


        /// <summary>
        /// Initializes the tic tac toe game board
        /// </summary>
        /// <returns>An empty Tic Tac Toe gamebaord</returns>
        public static char[,] InitializeBoard()
        {
            char[,] tictactoeBoard = new char[BOARD_SIZE, BOARD_SIZE];

            return tictactoeBoard;
        }

        /// <summary>
        /// Resets the board from all of the player and AI moves that have been made
        /// </summary>
        /// <param name="board">This is the tic tac toe gameboard</param>
        /// <returns>An empty gameboard</returns>
        public static char[,] ResetBoard(char[,] board)
        {
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    board[r, c] = '\0';
                }
            }

            return board;
        }

        /// <summary>
        /// Insert the move if it is valid into the gameboard
        /// </summary>
        /// <param name="row">Row number that the player wants to play</param>
        /// <param name="col">Column number that the player wants to play</param>
        /// <param name="board">This is the Tic Tac Toe gameboard</param>
        /// <returns>True -> successfully played on the board, False -> Invalid Selection</returns>
        public static bool InsertMove(int row, int col, char[,] board, char symbol)
        {
            if (!IsInside(row, col))
            {
                return false;
            }
            if (board[row, col] != '\0')
            {
                return false;
            }

            board[row, col] = symbol;
            return true;
        }

        /// <summary>
        /// Takes in 2 numbers and checks if they are between 0 and 2 (valid for tic tac toe)
        /// </summary>
        /// <param name="row">Row number that the player has entered</param>
        /// <param name="col">Column number that the player has entered</param>
        /// <returns>True -> valid number, False -> not valid number</returns>
        public static bool IsInside(int row, int col)
        {
            if (row >= 0 && row < BOARD_SIZE && col >= 0 && col < BOARD_SIZE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the player has won the game
        /// </summary>
        /// <param name="board">This is the tic tac toe board for the game</param>
        /// <returns>True -> the player won, False -> The player has not won (yet)</returns>
        public static bool HasWinner(char[,] board, char symbol)
        {
            // Check Rows
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                bool rowWin = true;
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    if (board[r, c] != symbol)
                    {
                        rowWin = false;
                        break;
                    }
                }
                if (rowWin)
                {
                    return true;
                }
            }

            // Check Columns
            for (int c = 0; c < BOARD_SIZE; c++)
            {
                bool colWin = true;
                for (int r = 0; r < BOARD_SIZE; r++)
                {
                    if (board[r, c] != symbol)
                    {
                        colWin = false;
                        break;
                    }
                }
                if (colWin)
                {
                    return true;
                }
            }

            // Check Diagonals
            // Diagonal top-left to bottom-right
            bool diag1 = true;
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (board[i, i] != symbol)
                {
                    diag1 = false;
                    break;
                }
            }
            if (diag1)
            {
                return true;
            }

            // Diagonal top-right to bottom-left
            bool diag2 = true;
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (board[i, BOARD_SIZE - 1 - i] != symbol)
                {
                    diag2 = false;
                    break;
                }
            }
            if (diag2)
            {
                return true;
            }


            return false;
        }

        /// <summary>
        /// Returns true if all of the cells are filled (tie game)
        /// </summary>
        /// <param name="board">This is the tic tac toe board for the game</param>
        /// <returns>True -> Tie game, False -> Game is not over yet</returns>
        public static bool IsBoardFull(char[,] board)
        {
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    if (board[r, c] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static int GetAIMoveRow(char[,] board, char aiSymbol, char playerSymbol)
        {
            throw new NotImplementedException();
        }

        public static int GetAIMoveCol(char[,] board, char aiSymbol, char playerSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
