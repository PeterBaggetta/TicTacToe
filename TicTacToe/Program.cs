namespace TicTacToe
{
    internal class Program
    {
        /// <summary>
        /// These are the symbols that represent either Player or AI in the Tic Tac Toe game
        /// </summary>
        public const char PLAYER_SYMBOL = 'X';
        public const char AI_SYMBOL = 'O';

        /// <summary>
        /// Play Again Character
        /// </summary>
        public const char PLAY_AGAIN = 'y';

        

        static void Main(string[] args)
        {
            UI.DisplayWelcomeMessage();
            UI.DisplayHowToPlay();

            char[,] tictactoeBoard = Logic.InitializeBoard();

            do
            {
                tictactoeBoard = Logic.ResetBoard(tictactoeBoard);
                bool gameOver = false;

                while (!gameOver)
                {

                    UI.DisplayBoard(tictactoeBoard);

                    // Players Turn (Check if valid row & col, and check if spot is already played)
                    int playerRow = UI.AskForPlayerRow(tictactoeBoard);
                    int playerCol = UI.AskForPlayerCol(tictactoeBoard);
                    while (!Logic.InsertMove(playerRow, playerCol, tictactoeBoard, PLAYER_SYMBOL))
                    {
                        UI.DisplayInvalidMove();
                        playerRow = UI.AskForPlayerRow(tictactoeBoard);
                        playerCol = UI.AskForPlayerCol(tictactoeBoard);
                    }

                    // Check if the board has a winner
                    if (Logic.HasWinner(tictactoeBoard, PLAYER_SYMBOL))
                    {
                        UI.DisplayBoard(tictactoeBoard);
                        UI.DisplayWinner("YOU");
                        gameOver = true;
                        break;
                    }

                    // Check for cats game (tie)
                    if (Logic.IsBoardFull(tictactoeBoard))
                    {
                        UI.DisplayBoard(tictactoeBoard);
                        UI.DisplayTie();
                        gameOver = true;
                        break;
                    }

                    // AIs Turn
                    int aiRow = Logic.GetAIMoveRow(tictactoeBoard, AI_SYMBOL, PLAYER_SYMBOL);
                    int aiCol = Logic.GetAIMoveCol(tictactoeBoard, AI_SYMBOL, PLAYER_SYMBOL);
                    Logic.InsertMove(aiRow, aiCol, tictactoeBoard, AI_SYMBOL);
                    UI.DisplayAIMove(aiRow, aiCol);

                    if (Logic.HasWinner(tictactoeBoard, AI_SYMBOL))
                    {
                        UI.DisplayBoard(tictactoeBoard);
                        UI.DisplayWinner("AI");
                        gameOver = true;
                        break;
                    }

                    if (Logic.IsBoardFull(tictactoeBoard))
                    {
                        UI.DisplayBoard(tictactoeBoard);
                        UI.DisplayTie();
                        gameOver = true;
                        break;
                    }
                }
            } while (UI.AskToPlayGameAgain(PLAY_AGAIN));

            UI.ThankYouForPlaying();
        }
    }
}
