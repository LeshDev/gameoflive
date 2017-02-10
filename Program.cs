using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

     *      - Beginn mit dem Projekt:
     *       9.2.2017 - 9:00
     *       
     *       - Ende des Projekts:
     *        9.2.2017 - 15:50 
     *        
     *        - Fertigstellung des Projektes:
     *         10.2.2017 - ??:??
     */
class Program
{

    static void Main(string[] args)
    {
            getRandom getRandomGrid = new getRandom();
            bool end = false;
        //Console.WriteLine("Aus technischen Gründen kann man bisher noch keine Values eingeben, um die größte des Feldes zu bestimmen. Deshalb wird dieser Part hiermit übersprungen");
        //Console.ReadKey();

        // Funktioniert - X

        //Console.WriteLine("Gebe die gewünschte Breite für das Game of Life ein");
        //breite = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Gebe die gewünschte Höhe für das Game of Life ein");
        //hoehe = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Gridsize:");
        int gridSize = int.Parse(Console.ReadLine());
        bool[,] grid = getRandomGrid(gridSize);

        Console.WriteLine("You choosed this gridSize: " + gridSize + "\nYour Game of Life will start now ...");
        Console.ReadKey();

            //int[,] grid = new int[,]
            //{ 
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
            //    { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
            //    { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
            //    { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
            //    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
            //    { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
            //    { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
            //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
            //    { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
            //    //{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},
            //{ 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
            //{ 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
            //{ 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
            //{ 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
            //{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
            //{ 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
            //{ 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
            //{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
            //{ 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
            //{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0},
            //{ 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
            //{ 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
            //{ 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
            //{ 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
            //{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
            //{ 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
            //{ 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
            //{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
            //{ 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
            //    { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}
            //};

            
        ConsoleKeyInfo key = Console.ReadKey();
        grid gameoflive = new grid();

        // GRID WIRD GELADEN

        while (!end)
        {
            gameoflive.currentgrid(grid);
        } }

            
    }
}

class getRandom
{
    public static void getRandomGrid()
    {
        bool[,] grid = new bool[1, 2];
        int rowCount = grid.GetLength(0);
        int colCount = grid.GetLength(1);

        Random rand = new Random();
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                grid[row, col] = (rand.NextDouble() > 0.5);
            }
        }
        return;
    }
}
    
class grid
{
    int gen = 0;
    int[,] oldgrid;                             // old Grid
    int[,] newgrid;                             // new Grid   
    public void currentgrid(int[,] grid)
    {
        newgrid = (int[,])grid.Clone();

        int breite = newgrid.GetLength(0);      // Build Breite
        int hoehe = newgrid.GetLength(1);       // Build die Höhe

        for (int i = 0; i < breite; i++)
        {
            for(int j = 0; j < hoehe; j++)
            {
                int checkzelle = zelle(i,j);    // Testing for cell

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
    private void displaygrid(int[,] newgrid)                // Output for the Grid - Using one color
    {
        int hoehe = newgrid.GetLength(0);
        int breite = newgrid.GetLength(1);

        for (int i = 0; i < hoehe; i++)
        {
            for(int j = 0; j < breite; j++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0,2}",newgrid[i, j]);
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