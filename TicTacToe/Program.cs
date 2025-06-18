using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int choice;
    static int scoreP1 = 0;
    static int scoreP2 = 0;
    static int flag = 0; // 0: playing, 1: win, -1: draw

    static void Main()
    {
            do
            {
                Console.Clear();
                Console.WriteLine("TIC TAC TOE GAME");
                Console.WriteLine($"Player 1: {scoreP1}  Player 2: {scoreP2}");
                Console.WriteLine("Player 1: X  Player 2: O\n");
                PrintBoard();

                player = (player % 2 == 0) ? 2 : 1;
                Console.Write($"Player {player}, enter a number (1-9): ");
                bool validInput = int.TryParse(Console.ReadLine(), out choice);

                if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                {
                    Console.WriteLine("Invalid move! Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                board[choice - 1] = (player == 1) ? 'X' : 'O';
                flag = CheckWin();
                player++;
            }
            while (flag == 0);

            Console.Clear();
            PrintBoard();

            if (flag == 1)
            {
                if (player % 2 == 0)
                {
                    scoreP1 += 1;
                }
                else
                {
                    scoreP2 += 1;
                }
                Console.WriteLine($"\nPlayer {(player % 2) + 1} wins!");
        }
        else
            Console.WriteLine("\nIt's a draw!");
        nextGame();
            


        static void PrintBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]} ");
            Console.WriteLine("     |     |      ");
        }

        static int CheckWin()
        {
            // Horizontal
            if (board[0] == board[1] && board[1] == board[2]) return 1;
            if (board[3] == board[4] && board[4] == board[5]) return 1;
            if (board[6] == board[7] && board[7] == board[8]) return 1;
            // Vertical
            if (board[0] == board[3] && board[3] == board[6]) return 1;
            if (board[1] == board[4] && board[4] == board[7]) return 1;
            if (board[2] == board[5] && board[5] == board[8]) return 1;
            // Diagonal
            if (board[0] == board[4] && board[4] == board[8]) return 1;
            if (board[2] == board[4] && board[4] == board[6]) return 1;

            // Check for draw
            foreach (char c in board)
                if (c != 'X' && c != 'O')
                    return 0;

            return -1;
        }
        static void nextGame()
        {
            Console.WriteLine("\nDo you want to playe another one ?");
            string playAgian = Console.ReadLine();
            switch (playAgian?.ToLower() ?? "")
            {
                case "yes":
                    board = [ '1', '2', '3', '4', '5', '6', '7', '8', '9' ];
                    Main();
                    break;
                case "no":
                    return;
                default:
                    nextGame();
                    break;
            }
        }
    }
}
