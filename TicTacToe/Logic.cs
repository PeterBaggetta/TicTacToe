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
    }
}
