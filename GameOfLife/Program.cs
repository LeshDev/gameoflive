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
                getRandom getRandomGrid = new getRandom();
                bool end = false;

                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Console.WriteLine("Welcome to GAME OF LIFE - Version " + version);
                Console.WriteLine("Choose a Gridsize:");
                int gridSize = int.Parse(Console.ReadLine());
                bool[,] grid = getRandom.getRandomGrid(gridSize);
                Console.WriteLine("You've choosed this Gridsize: " + gridSize + "\nYour Game of Life will start now ...");
                Console.ReadKey();

                ConsoleKeyInfo key = Console.ReadKey();
                grid2 gameoflive = new grid2();

                while (end == false)                                                        // Grid "sollte" geladen werdén
                {
                    getRandom.getRandomGrid(gridSize);
                }

            //int[,] gridpattern = new int[,]
            //    {
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
            //    { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
            //    { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
            //    { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
            //    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
            //    { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
            //    { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
            //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
            //    { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
            //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
            //    { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
            //    { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
            //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}
            //    };
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

        class colors
        {
            public void red()
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    
        class grid2
        {
            int gen = 0;
            int[,] oldgrid;                             // old Grid
            int[,] newgrid;                             // new Grid   
            public void currentgrid(int[,] grid)
            {
                newgrid = (int[,])grid.Clone();

                int rowCount = grid.GetLength(0);                                                   // Build Breite
                int colCount = grid.GetLength(1);                                                   // Build die Höhe

                for (int i = 0; i < rowCount; i++)
                {
                    for(int j = 0; j < colCount; j++)
                    {
                        int checkzelle = zelle(i,j);                                                // Testing for cell

                        if(newgrid[i,j] == 1)
                        {
                            if (checkzelle == 2 || checkzelle == 3)
                            {
                                newgrid[i, j] = 1;
                            }
                            else
                            {
                                newgrid[i, j] = 0;
                            }
                        }
                        else
                        {
                            if(checkzelle == 3)
                            {
                                newgrid[i, j] = 1;
                            }else
                            {
                                newgrid[i, j] = 0;
                            }
                        }
                    }
                }
                Thread.Sleep(500);

                oldgrid = (int[,])newgrid.Clone();
                displaygrid(newgrid);
                currentgrid(oldgrid);
            }
            private void displaygrid(int[,] grid)                // Output for the Grid
            {
                int hoehe = newgrid.GetLength(0);
                int breite = newgrid.GetLength(1);

                for (int i = 0; i < hoehe; i++)
                {
                    for(int j = 0; j < breite; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0}", newgrid[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                gen++;
                Console.WriteLine();
                Console.WriteLine("Next Generation - Load Grid Nr: " + gen);
            }
            public int zelle(int x, int y)                          // Code will change later - Not that nice right now
            {
                int checkzelle = 0;

                if(x < 9 && y < 9)                  // Testet 1 RECHTS OBEN
                {
                    if(newgrid[x + 1, y + 1] == 1)  // +1 x && y 
                    {
                        checkzelle++;
                    }
                }
                if(x < 9)                           // Testet 1 RECHTS
                {
                    if(newgrid[x + 1, y] == 1)      // +1 x
                    {
                        checkzelle++;
                    }
                }
                if(x > 9)                           // Testet 1 LINKS
                {
                    if(newgrid[x - 1, y] == 1)
                    {
                        checkzelle++;               // -1 x
                    }
                }
                if(y < 9)                           // Testet 1 OBEN
                {
                    if(newgrid[x, y + 1] == 1)      // +1 y
                    {
                        checkzelle++;
                    }
                }
                if(y > 9)                           // Testet 1 UNTEN
                {
                    if(newgrid[x, y - 1] == 1)      // -1 y
                    {
                        checkzelle++;
                    }
                }
                if(x > 0 && y > 0)                  // Testet 1 UNTEN LINKS
                {
                    if(newgrid[x - 1, y - 1] == 1)  // -1 x && y
                    {
                        checkzelle++;
                    }
                }
                if(x < 9 && y > 0)                  // Testet 1 UNTEN RECHTS
                {
                    if(newgrid[x + 1, y - 1] == 1)  // +1 x && -1 y
                    {
                        checkzelle++;
                    }
                }
                if(x > 0 && y < 0)                  // Testet 1 OBEN LINKS
                {
                    if(newgrid[x - 1, y + 1] == 1)  // -1 x && +1 y
                    {
                        checkzelle++;
                    }
                }
                return checkzelle;
            }
    }  // ENDE
}
// Unused random things

        //int[,] grid = new int[,]
        //    {
        //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
        //    { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
        //    { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
        //    { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
        //    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
        //    { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
        //    { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
        //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
        //    { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
        //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},
        //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
        //    { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
        //    { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
        //    { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
        //    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
        //    { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
        //    { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
        //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
        //    { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
        //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},
        //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
        //    { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
        //    { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
        //    { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
        //    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
        //    { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
        //    { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
        //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
        //    { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
        //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}
        //    };