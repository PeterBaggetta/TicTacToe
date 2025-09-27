using System.Reflection.Metadata.Ecma335;

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

        /// <summary>
        /// This method picks the AI move with some conditions:
        /// Win     -> AI is able to win the game so it moves in that spot
        /// Block   -> Player is about to win so the AI blocks
        /// Center  -> AI plays in the center of the board (most common for best move)
        /// Corners -> AI plays in the corners to setup after playing center
        /// Open    -> AI plays in any open cell if the optimal one is not available
        /// </summary>
        /// <param name="board">This is the tic tac toe board for the game</param>
        /// <param name="aiSymbol">This is the AI Symbol on the gameboard</param>
        /// <param name="playerSymbol">This is the player symbol on the gameboard</param>
        /// <returns>The row and column that the AI will play</returns>
        public static (int row, int col) GetAIMove(char[,] board, char aiSymbol, char playerSymbol)
        {
            // AI tries to win
            (int winRow, int winCol) = FindWinningMove(board, aiSymbol);
            if (winRow != -1)
            {
                return (winRow, winCol);
            }

            // AI tries to block
            (int blockRow, int blockCol) = FindWinningMove(board, playerSymbol);
            if (blockRow != -1)
            {
                return (blockRow, blockCol);
            }

            // AI plays center of board
            int centerBoard = BOARD_SIZE / 2;
            if (board[centerBoard, centerBoard] == '\0')
            {
                return (centerBoard, centerBoard);
            }

            // AI Plays the corners
            if (board[0, 0] == '\0')
            {
                return (0, 0);
            }
            if (board[0, BOARD_SIZE - 1] == '\0')
            {
                return (0, BOARD_SIZE - 1);
            }
            if (board[BOARD_SIZE - 1, 0] == '\0')
            {
                return (BOARD_SIZE - 1, 0);
            }
            if (board[BOARD_SIZE - 1, BOARD_SIZE - 1] == '\0')
            {
                return (BOARD_SIZE - 1, BOARD_SIZE - 1);
            }

            // AI plays in first open spot (corners, middle, win or block not open)
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    if (board[r, c] == '\0')
                    {
                        return (r, c);
                    }
                }
            }
            return (0, 0);
        }

        /// <summary>
        /// Finds a winning move or blocking move on the gameboard
        /// </summary>
        /// <param name="board">This is the tic tac toe board for the game</param>
        /// <param name="symbol">Symbol of either AI or player depending on what is being checked</param>
        /// <returns>A row and column which is either the win or block</returns>
        public static (int row, int col) FindWinningMove(char [,] board, char symbol)
        {
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    if (board[r,c] != '\0')
                    {
                        continue;
                    }

                    // Try placing symbol and check if its a winning move
                    board[r, c] = symbol;
                    bool win = HasWinner(board, symbol);
                    board[r, c] = '\0'; // Undo trying to place (place symbol in different method for consistency)

                    if (win)
                    {
                        return (r, c);
                    }
                }
            }
            // There is not a winning move
            return (-1, -1);
        }
    }
}
