using static TicTacToe.GlobalVariabes;

namespace TicTacToe
{
    public static class Logic
    {
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
        /// Insert the player move if it is valid into the gameboard
        /// </summary>
        /// <param name="row">Row number that the player wants to play</param>
        /// <param name="col">Column number that the player wants to play</param>
        /// <param name="board">This is the Tic Tac Toe gameboard</param>
        /// <returns>True -> successfully played on the board, False -> Invalid Selection</returns>
        public static bool InsertPlayerMove(int row, int col, char[,] board)
        {
            if (!IsInside(row, col))
            {
                return false;
            }
            if (board[row, col] != '\0')
            {
                return false;
            }

            board[row, col] = PLAYER_SYMBOL;
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
            if (row >= 0 && row < 3 && col >= 0 && col < 3)
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
        public static bool HasWinner(char[,] board)
        {
            // Check Rows
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                if (board[r, 0] == PLAYER_SYMBOL && board[r, 1] == PLAYER_SYMBOL && board[r, 2] == PLAYER_SYMBOL)
                {
                    return true;
                }
            }

            // Check Columns
            for (int c = 0; c < 3; c++)
            {
                if (board[0, c] == PLAYER_SYMBOL && board[1, c] == PLAYER_SYMBOL && board[2, c] == PLAYER_SYMBOL)
                {
                    return true;
                }
            }

            // Check Diagonals
            if (board[0, 0] == PLAYER_SYMBOL && board[1, 1] == PLAYER_SYMBOL && board[2, 2] == PLAYER_SYMBOL)
            {
                return true;
            }
            if (board[0, 2] == PLAYER_SYMBOL && board[1, 1] == PLAYER_SYMBOL && board[2, 0] == PLAYER_SYMBOL)
            {
                return true;
            }

            return false;
        }
    }
}
