using System;

class TicTacToe
{
    private static string?[,] board = new string?[3, 3];

    static void Main(string[] args)
    {
        InitializeBoard();

        int currentPlayer = 1;
        bool gameEnded = false;

        while (!gameEnded)
        {
            DrawBoard();

            Console.WriteLine("Player {0}, enter the row and column number (e.g., 1 2):", currentPlayer);
            string? inputString = Console.ReadLine();

            if (inputString is not null)
            {
                string[] input = inputString.Split(' ');

                if (input.Length == 2 && int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col))
                {
                    row -= 1;
                    col -= 1;

                    if (IsValidMove(row, col))
                    {
                        string marker = (currentPlayer == 1) ? "X" : "O";
                        PlaceMarker(marker, row, col);

                        if (WinCheck(marker))
                        {
                            Console.WriteLine("Player {0} wins!", currentPlayer);
                            gameEnded = true;
                        }
                        else if (IsBoardFull())
                        {
                            Console.WriteLine("It's a tie!");
                            gameEnded = true;
                        }
                        else
                        {
                            currentPlayer = (currentPlayer == 1) ? 2 : 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter the row and column numbers separated by a space.");
                }
            }
        }

        Console.ReadLine();
    }

    private static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = " ";
            }
        }
    }

    private static void DrawBoard()
    {
        Console.WriteLine("Current board:\n");

        Console.WriteLine("     1   2   3");
        Console.WriteLine("   -------------");

        for (int i = 0; i < 3; i++)
        {
            Console.Write(" {0} |", i + 1);

            for (int j = 0; j < 3; j++)
            {
                string marker = board[i, j] ?? " ";
                Console.Write(" {0} |", marker);
            }

            Console.WriteLine();
            Console.WriteLine("   -------------");
        }

        Console.WriteLine();
    }

    private static bool IsValidMove(int row, int col)
    {
        if (row < 0 || row >= 3 || col < 0 || col >= 3)
        {
            return false;
        }

        return board[row, col] == " ";
    }

    private static void PlaceMarker(string marker, int row, int col)
    {
        board[row, col] = marker;
    }

    private static bool WinCheck(string marker)
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == marker && board[i, 1] == marker && board[i, 2] == marker)
            {
                return true;
            }
        }

        // Check columns
        for (int j = 0; j < 3; j++)
        {
            if (board[0, j] == marker && board[1, j] == marker && board[2, j] == marker)
            {
                return true;
            }
        }

        // Check diagonals
        if (board[0, 0] == marker && board[1, 1] == marker && board[2, 2] == marker)
        {
            return true;
        }

        if (board[0, 2] == marker && board[1, 1] == marker && board[2, 0] == marker)
        {
            return true;
        }

        return false;
    }

    private static bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == " ")
                {
                    return false;
                }
            }
        }

        return true;
    }
}
