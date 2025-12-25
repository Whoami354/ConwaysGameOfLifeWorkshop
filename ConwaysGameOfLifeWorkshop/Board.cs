using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeWorkshop
{
    internal class Board
    {
        const char CHARACTER_ALIVE = '#';
        const char CHARACTER_DEAD = '.';

        public Cell[,] Fields { get; private set; }
        public int Generation { get; private set; }

        public Board(int width, int height)
        {
            Fields = new Cell[width, height];
            Generation = 1;

            for(int y = 0; y < Fields.GetLength(1); y++)
            {
                for(int x = 0; x < Fields.GetLength(0); x++)
                {
                    Fields[x, y] = new Cell(false);
                }
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while(true)
            {
                //Draw();
                Update();
                Generation++;
                Thread.Sleep(100);
            }
        }

        public void Update()
        {
            //Durchlaufe jede Zelle im Feld
            for(int y = 0; y < Fields.GetLength(1); y++)
            {
                for(int x = 0; x < Fields.GetLength(0); x++)
                {
                    //Zähle wie viele lebende Nachbarn die aktuell durchlaufende Zelle hat 
                    CountAliveNeighbourCells(x, y);

                    //Lege fest, welchen Status (tot, lebendig) die aktuell durchlaufene Zelle im nächsten Spielschritt hat
                    Fields[x, y].CheckNextCellStatus();
                }
            }
            
            //Durchlaufe nochmal alle Zellen im Feld
                //Update jede Zelle
            //foreach(Cell cell in Fields)
                //cell.Update();
        }

        private void CountAliveNeighbourCells(int xPosition, int yPosition)
        {
            int count = 0;

            //Durchlaufe nur die Nachbarn der ausgewählten Zelle
            for(int y = yPosition - 1; y < yPosition + 2; y++)
            {
                for(int x = xPosition - 1; x < xPosition + 2; x++)
                {
                    if(x == xPosition && y == yPosition)
                        continue;

                    // Prüfe ob die aktuell durchlaufene Zelle innerhalb des Arrays liegt
                    if((x >= 0 && x < Fields.GetLength(0)) && (y >= 0 && y < Fields.GetLength(1)))
                    {
                        if(Fields[x, y].IsAlive)
                            count++;
                    }
                }
            }

            Fields[xPosition, yPosition].AmountOfNeighbours = count;
        }
    }
}
