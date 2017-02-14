using System;
using System.Threading;

namespace GameOfLife
{
    //TODO:Info    
    /*
     *      1 / X = Lebende Zelle
     *      0 / O (Leere Zelle) = Tote Zelle
     * 
     *      Regeln:
     *      - eine tote Zelle mit drei lebenden Nachbarn wird wiederbelebt
     *      - lebende Zelle mit zwei oder drei lebenden Zellen darf weiter leben
     *      - eine lebende Zelle mit mehr als drei lebenden Zellen muss sterben
     *      - eine lebende Zelle mit weniger als zwei Zellen muss sterben
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[,]                                                                // Create a new 2D array
            {
               // 0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 2, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1},  // 0
                { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},  // 1
                { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},  // 2
                { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},  // 3
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},  // 4
                { 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},  // 5
                { 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},  // 6
                { 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0},  // 7
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},  // 8
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},  // 9
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},  // 10
                { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},  // 11
                { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},  // 12
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}   // 13
            };
            int row = grid.GetLength(0);                                                            // Checks the length for row
            int col = grid.GetLength(1);                                                            // Checks the length for col
            Random rdm = new Random();                                                              // New Randomizer

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    grid[i, j] = rdm.Next(2);                                                       // Generates random numbers between 0 and 1
                }
            }
            grid2 gameoflive = new grid2(grid);                                                     
            bool end = false;
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("Welcome to GAME OF LIFE - Version " + version);                      // Display welcome and version text
            Console.WriteLine("Your Game of Life will start now ...");                              // Gives the start introduction
            Console.ReadKey();                                                                      // Checks for Key
            while (end == false)                                                                    // Creates a never ending loop
            {
                gameoflive.currentgrid();                                                           // Always loads the newest grid
            }
        }
    }
    class grid2                                                             
    {
        int gen = 0;                                                                                // Sets the generation number - Standart: 0
        int[,] oldgrid;                                                                             // Creates the old Grid
        int[,] newgrid;                                                                             // Creates the new Grid

        public grid2(int[,] grid)
        {
            oldgrid = grid;
        }


        public void currentgrid()
        {
            newgrid = (int[,])oldgrid.Clone();                                                      // Clone the oldgrid
            int rowCount = oldgrid.GetLength(0);                                                    // Build Breite
            int colCount = oldgrid.GetLength(1);                                                    // Build die Höhe

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    int checkzelle = zelle(i, j);                                                   // Testing for cell
                    if (oldgrid[i, j] == 1)                                                         // Tests if there is an 1 at the current positon
                    {
                        if (checkzelle <= 1)                                                        // Checks for 1 or Less Cells
                        {
                            newgrid[i, j] = 0;                                                      // Set the current number to 0
                        }
                        else if (checkzelle == 2 || checkzelle == 3)                                // Checks for 2 or 3 Cells
                        {
                            newgrid[i, j] = 1;                                                      // Set the current number to 1
                        }
                        else if (checkzelle >= 4)                                                   // Checks for more then 3 Cells
                        {
                            newgrid[i, j] = 0;                                                      // Set the current number to 0
                        }
                    }
                    else                                                                            // Tests if there is a 0 at the current position
                    {
                        if (checkzelle == 3)                                                        // Checks for 3 cells
                        {
                            newgrid[i, j] = 1;                                                      // Set the current number to 1
                        }
                        else if (checkzelle >= 4)                                                   // Checks for 4 or higher cells
                        {
                            newgrid[i, j] = 0;                                                      // Set the current number to 0
                        }
                        else                                                                        // Checks for 0 - 2 Cells
                        {
                            newgrid[i, j] = 0;                                                      // Set the current number to 0
                        }
                    }
                }
            }
            oldgrid = (int[,])newgrid.Clone();                                                      // Clones to newgrid to the old grid
            displaygrid(newgrid);                                                                   // Send the new grid to the display grid
        }


        private void displaygrid(int[,] grid)                                                       // Output for the Grid
        {
            int hoehe = grid.GetLength(0);                                                          // Gets the high of the array
            int breite = grid.GetLength(1);                                                         // Get the col of the array
            for (int i = 0; i < hoehe; i++)
            {
                for (int j = 0; j < breite; j++)
                {
                    Console.Write("{0,2}", grid[i, j]);                                             // Display the grid
                }
                Console.WriteLine();
            }
            Console.WriteLine("     ----------------------------------------");                     // Draw the bottom line
            Thread.Sleep(400);                                                                      // Froze the programm for 0,4 sec
            Console.Clear();                                                                        // Generate a new generation
            gen++;                                                                                  // Add 1 to the generation number
            Console.WriteLine();
            Console.WriteLine("     -- Next Generation - Load Grid Nr: " + gen + " --");            // Draw the top line with current generation number
        }
        public int zelle(int x, int y)                                                              // Tests for nearby cells
        {
            int checkzelle = 0;
            if (x < 9 && y < 9)                                                                     // Testet 1 RECHTS UNTEN
            {
                if (oldgrid[x + 1, y + 1] == 1)                                                     // +1 x && +1 y 
                {
                    checkzelle++;
                }
            }
            if (x > 0 && y > 0)                                                                     // Testet 1 Oben LINKS
            {
                if (oldgrid[x - 1, y - 1] == 1)                                                     // -1 x && y
                {
                    checkzelle++;
                }
            }
            if (x < 9)                                                                              // Testet 1 RECHTS
            {
                if (oldgrid[x + 1, y] == 1)                                                         // +1 x
                {
                    checkzelle++;
                }
            }
            if (x > 0)                                                                              // Testet 1 LINKS
            {
                if (oldgrid[x - 1, y] == 1)                                                         // -1 x
                {
                    checkzelle++;                                                                   
                }
            }
            if (y < 9)                                                                              // Testet 1 unten
            {
                if (oldgrid[x, y + 1] == 1)                                                         // +1 y
                {
                    checkzelle++;
                }
            }
            if (y > 0)                                                                              // Testet 1 Óben
            {
                if (oldgrid[x, y - 1] == 1)                                                         // -1 y
                {
                    checkzelle++;
                }
            }
            if (x < 9 && y > 0)                                                                     // Testet 1 Oben RECHTS
            {
                if (oldgrid[x + 1, y - 1] == 1)                                                     // +1 x && -1 y
                {
                    checkzelle++;
                }
            }
            if (x > 0 && y < 9)                                                                     // Testet 1 Unten LINKS
            {
                if (oldgrid[x - 1, y + 1] == 1)                                                     // -1 x && +1 y
                {
                    checkzelle++;
                }
            }
            return checkzelle;
        }
    }  // ENDE
}