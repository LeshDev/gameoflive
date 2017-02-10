using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
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
             *         ???.2.2017 - ???:???
             */

            int hoehe;
            int breite;

            string bre = String.Empty;
            string hoe = String.Empty;

            bool end = false;
            bool kill = false;

            //Console.WriteLine("Aus technischen Gründen kann man bisher noch keine Values eingeben, um die größte des Feldes zu bestimmen. Deshalb wird dieser Part hiermit übersprungen");
            //Console.ReadKey();


            //{
            //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            //    { 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
            //    { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            //};

            // Funktioniert - X

            var input = Console.ReadLine();

            Console.WriteLine("Gebe die gewünschte Breite für das Game of Life ein");
            breite = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Gebe die gewünschte Höhe für das Game of Life ein");
            hoehe = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Dein Spielfeld ist nun " + /*breite +*/ " breit und " + hoehe + " Hoch. \nStarte Spiel ...");
            Console.ReadKey();

            //grid[0,1] = breite;
            //grid[1,0] = hoehe;


            // Random Generator ( 0 - 1 )
            Random rnd = new Random();


            //int[,] grid = new int[breite, hoehe];
            //for (int i = 0; i < breite; i++)
            //{
            //    for (int j = 0; j < hoehe; j++)
            //    {
            //        int u = 0;
            //        bre = breite.ToString();
            //        hoe = hoehe.ToString();
            //        grid[i, j] = rnd.Next(0,2) + Int32.Parse(hoe);
            //    }
            //}



            int[,] grid = new int[,]
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
                { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0},
                { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1},
                { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1},
                { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0},
                { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0},
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0},
                { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
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
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0}
            };

            // System.IO.File.WriteAllLines("scores.txt", grid(tb => (double.Parse(tb.Text)).ToString()));

            ConsoleKeyInfo key = Console.ReadKey();
            grid gameoflive = new grid();

            // GRID WIRD GELADEN

            while (end == false)
            {
                gameoflive.currentgrid(grid);
            }

            // ---------------------
            // BEENDET DAS PROGRAMM
            // ---------------------

            while (kill == false)
            {
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    kill = true;
                    end = true;
                    Console.WriteLine("Game of Life wird angehalten und beendet");
                    Thread.Sleep(3000);

                }
            }
        }
    }
    class grid
    {
        int[,] oldgrid;                             // Altes Grid
        int[,] newgrid;                             // Neues Grid   
        public void currentgrid(int[,] grid)
        {
            newgrid = (int[,])grid.Clone();

            int breite = newgrid.GetLength(0);      // Erstellt die Breite
            int hoehe = newgrid.GetLength(1);       // Erstellt die Höhe

            for (int i = 0; i < breite; i++)
            {
                for(int j = 0; j < hoehe; j++)
                {
                    int checkzelle = zelle(i,j);    // Testet nach den Zellen

                    if(newgrid[i,j] == 1)
                    {
                        if(checkzelle <= 1)
                        {
                            newgrid[i, j] = 1;
                        }
                        else if (checkzelle == 2 || checkzelle == 3)
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
        private void displaygrid(int[,] newgrid)                // Zeigt das Grid an
        {
            int gen = 0;
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
                gen++;
            }
            Console.WriteLine();
        }

        public int zelle(int x, int y)
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

            /*
             *      X = getestet | 0 = nicht getestet
             *                  X X X
             *                  X 0 X
             *                  X X X
             */

            return checkzelle;
        }

    }
}
