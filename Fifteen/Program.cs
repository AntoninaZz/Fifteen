using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Program
    {
        // constants
        const int DIM_MIN = 3;
        const int DIM_MAX = 9;

        // board
        static int[,] board = new int[DIM_MAX, DIM_MAX];

        // dimensions
        static int d;

        static void Main(string[] args)
        {
            // ensure valid dimensions
            Console.Write("Enter dimensions ");
            d = int.Parse(Console.ReadLine());
            while (d < DIM_MIN || d > DIM_MAX)
            {
                Console.WriteLine("Board must be between {0} x {0} and {1} x {1}, inclusive.",
                    DIM_MIN, DIM_MAX);
                Console.Write("Enter dimensions again");
                d = int.Parse(Console.ReadLine());
            }

            // greet user with instructions
            greet();

            // initialize the board
            init();

            // accept moves until game is won
            while (true)
            {
                // clear the screen
                clear();

                // draw the current state of the board
                draw();

                // check for win
                if (won())
                {
                    Console.WriteLine("Congrats!\n");
                    System.Threading.Thread.Sleep(5000);
                    break;
                }

                // prompt for move
                Console.WriteLine("Tile to move: ");
                int tile = int.Parse(Console.ReadLine());

                // quit if user inputs 0 (for testing)
                if (tile == 0)
                {
                    break;
                }

                // move if possible, else report illegality
                if (!move(tile))
                {
                    Console.WriteLine("\nIllegal move.");
                    System.Threading.Thread.Sleep(1000);
                }

                // sleep thread for animation's sake
                System.Threading.Thread.Sleep(500);
            }
        }

        /**
         * Clears screen using ANSI escape sequences.
         */
        static void clear()
        {
            Console.Clear();
        }

        /**
         * Greets player.
         */
        static void greet()
        {
            clear();
            Console.WriteLine("WELCOME TO GAME OF FIFTEEN\n");
            System.Threading.Thread.Sleep(2000);
        }

        /**
         * Initializes the game's board with tiles numbered 1 through d*d - 1
         * (i.e., fills 2D array with values but does not actually print them).  
         */
        static void init()
        {
            int numb = d * d - 1;
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    board[i, j] = numb--;
                }
            }
            if (d % 2 == 0)
            {
                board[d - 1, d - 2] = 2;
                board[d - 1, d - 3] = 1;
            }
        }

        /**
         * Prints the board in its current state.
         */
        static void draw()
        {
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (board[i, j] != 0)
                    {
                        Console.Write("{0,3}", board[i, j]);
                    }
                    else
                    {
                        Console.Write("  _");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /**
         * If tile borders empty space, moves tile and returns true, else
         * returns false.
         */
        static bool move(int tile)
        {
            if (tile > d * d - 1 || tile < 1)
            {
                return false;
            }
            int row = 0, col = 0;
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (board[i, j] == tile)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }
            if (row != 0 && board[row - 1, col] == 0)
            {
                board[row - 1, col] = tile;
                board[row, col] = 0;
                return true;
            }
            if (row != d - 1 && board[row + 1, col] == 0)
            {
                board[row + 1, col] = tile;
                board[row, col] = 0;
                return true;
            }
            if (col != 0 && board[row, col - 1] == 0)
            {
                board[row, col - 1] = tile;
                board[row, col] = 0;
                return true;
            }
            if (col != d - 1 && board[row, col + 1] == 0)
            {
                board[row, col + 1] = tile;
                board[row, col] = 0;
                return true;
            }
            return false;
        }

        /**
         * Returns true if game is won (i.e., board is in winning configuration),
         * else false.
         */
        static bool won()
        {
            int k = 1;
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (k != d * d && board[i, j] != k++)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}