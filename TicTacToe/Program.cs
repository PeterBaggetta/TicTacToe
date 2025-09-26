namespace TicTacToe
{
    internal class Program
    {
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
                    int playerRow = UI.AskForPlayerRow();
                    int playerCol = UI.AskForPlayerCol();
                    while (!Logic.InsertPlayerMove(playerRow, playerCol, tictactoeBoard))
                    {
                        UI.DisplayInvalidMove();
                        playerRow = UI.AskForPlayerRow();
                        playerCol = UI.AskForPlayerCol();
                    }

                    // Check if the board has a winner
                    if (Logic.HasWinner(tictactoeBoard))
                    {
                        UI.DisplayBoard(tictactoeBoard);
                        UI.DisplayWinner("YOU");
                        gameOver = true;
                        break;
                    }

                    //gameOver = true;
                }
            } while (UI.AskToPlayGameAgain());
        }
    }
}
