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
                int[,] grid = new int[,]
                {
               // 0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 2, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1},  // 0
                { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},  // 1
                { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},  // 2
                { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},  // 3
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},  // 4
                { 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},  // 5
                { 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},  // 6
                { 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},  // 7
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},  // 8
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},  // 9
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},  // 10
                { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},  // 11
                { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},  // 12
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}   // 13
                };
                getRandom getRandomGrid = new getRandom();
                bool end = false;

                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Console.WriteLine("Welcome to GAME OF LIFE - Version " + version);
                Console.WriteLine("Choose a Gridsize:");
                //int gridSize = int.Parse(Console.ReadLine());
                //bool[,] gridb = getRandom.getRandomGrid(gridSize);
                Console.WriteLine("You've choosed this Gridsize:" +  /*gridSize +*/ "\nYour Game of Life will start now ...");
                Console.ReadKey();

                grid2 gameoflive = new grid2(grid);

                while (end == false)                                                        // Grid "sollte" geladen werdén
                {
                    gameoflive.currentgrid();
                    /*getRandom.getRandomGrid(gridSize)*/
                }
        }
    }

            class getRandom
        {
            public static bool[,] getRandomGrid(int size)                                   // Generate a custom grid, 
            {
                bool[,] grid = new bool[size, size];
                int rowCount = grid.GetLength(0);
                int colCount = grid.GetLength(1);

                Random rand = new Random();
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        grid[row, col] = (rand.NextDouble() > 0.5);
                        //Console.WriteLine(grid[row, col]?"X":"O");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                return grid;
            }
        }
    
            class grid2
            {
                int gen = 0;
                int[,] oldgrid;                             // old Grid
                int[,] newgrid;                             // new Grid

                public grid2(int[,] grid)
                {
                    oldgrid = grid;
                }

                public static bool[,] getRandomGrid(int size)                                   // Generate a custom grid, 
                {
                    bool[,] grid = new bool[size, size];
                    int rowCount = grid.GetLength(0);
                    int colCount = grid.GetLength(1);

                    Random rand = new Random();
                    for (int row = 0; row < rowCount; row++)
                    {
                        for (int col = 0; col < colCount; col++)
                        {
                            grid[row, col] = (rand.NextDouble() > 0.5);
                            //Console.WriteLine(grid[row, col]?"X":"O");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    return grid;
                }
                public void currentgrid()
                    {
                        newgrid = (int[,])oldgrid.Clone();

                        int rowCount = oldgrid.GetLength(0);                                                    // Build Breite
                        int colCount = oldgrid.GetLength(1);                                                    // Build die Höhe

                        for (int i = 0; i < rowCount; i++)
                        {
                            for(int j = 0; j < colCount; j++)
                            {
                                int checkzelle = zelle(i,j);                                                    // Testing for cell

                                if(oldgrid[i,j] == 1)                                                           // Tests if there is an 1 at the current positon
                                {
                                    if(checkzelle <= 1)                                                         // 1 or Less Cells
                                    {
                                        newgrid[i, j] = 0;
                                    }
                                    else if (checkzelle == 2 || checkzelle == 3)                                // 2 or 3 Cells
                                    {
                                        newgrid[i, j] = 1;
                                    }
                                    else                                                                        // More then 3 Cells
                                    {
                                        newgrid[i, j] = 0;
                                    }
                                }
                                else                                                                            // Tests if there is a 0 at the current position
                                {
                                    if (checkzelle == 3)
                                    {
                                        newgrid[i, j] = 1;
                                    }
                                    else
                                    {
                                        newgrid[i, j] = 0;
                                    }
                                }
                            }
                        }
                        //Thread.Sleep(300);

                        oldgrid = (int[,])newgrid.Clone();
                        displaygrid(newgrid);
                        //currentgrid(oldgrid);
                    }


                    private void displaygrid(int[,] grid)                                                       // Output for the Grid
                    {
                        int hoehe = grid.GetLength(0);
                        int breite = grid.GetLength(1);

                        for (int i = 0; i < hoehe; i++)
                        {
                            for(int j = 0; j < breite; j++)
                            {
                                //Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("{0,2}", grid[i,j]);                                              // Writes the Game of Life 
                                //Console.ResetColor();
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("     ----------------------------------------");
                        Thread.Sleep(400);
                        Console.Clear();                                                                        // Generate a new generation
                        gen++;
                        Console.WriteLine();
                        Console.WriteLine("     -- Next Generation - Load Grid Nr: " + gen + " --");
                    }
                    public int zelle(int x, int y)                          // Tests for nearby cells
                    {
                        int checkzelle = 0;

                        if(x < 9 && y < 9)                  // Testet 1 RECHTS UNTEN
                        {
                            if(oldgrid[x + 1, y + 1] == 1)  // +1 x && +1 y 
                            {
                                checkzelle++;
                            }
                        }
                        if (x > 0 && y > 0)                  // Testet 1 Oben LINKS
                        {
                            if (oldgrid[x - 1, y - 1] == 1)  // -1 x && y
                            {
                                checkzelle++;
                            }
                        }

                        if (x < 9)                           // Testet 1 RECHTS
                        {
                            if(oldgrid[x + 1, y] == 1)      // +1 x
                            {
                                checkzelle++;
                            }
                        
                        }
                        if(x > 0)                           // Testet 1 LINKS
                        {
                            if(oldgrid[x - 1, y] == 1)
                            {
                                checkzelle++;               // -1 x
                            }
                        }
                        if(y < 9)                           // Testet 1 unten
                        {
                            if(oldgrid[x, y + 1] == 1)      // +1 y
                            {
                                checkzelle++;
                            }
                        }
                        if(y > 0)                           // Testet 1 Óben
                        {
                            if(oldgrid[x, y - 1] == 1)      // -1 y
                            {
                                checkzelle++;
                            }
                        }
                        if(x < 9 && y > 0)                  // Testet 1 Oben RECHTS
                        {
                            if(oldgrid[x + 1, y - 1] == 1)  // +1 x && -1 y
                            {
                                checkzelle++;
                            }
                        }
                        if(x > 0 && y < 9)                  // Testet 1 Unten LINKS
                        {
                            if(oldgrid[x - 1, y + 1] == 1)  // -1 x && +1 y
                            {
                                checkzelle++;
                            }
                        }
                        else
                        {
                            if (oldgrid[x, y] == 1)
                            {
                                checkzelle++;
                            }
                        }
                        y = 0;
                        x = 0;
                return checkzelle;
                    }
        }  // ENDE
}
// Unused random things

                //int[,] grid = new int[,]
                //{
                //{ 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 2, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1},
                //{ 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
                //{ 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
                //{ 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
                //{ 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
                //{ 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
                //{ 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
                //{ 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
                //{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
                //{ 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},
                //{ 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
                //{ 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
                //{ 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
                //{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}
                //};