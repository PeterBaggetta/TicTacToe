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

                    // Players Turn
                    int playerRow = UI.AskForPlayerRow();
                    int playerCol = UI.AskForPlayerCol();

                    gameOver = true;
                }
            } while (UI.AskToPlayGameAgain());
        }
    }
}
