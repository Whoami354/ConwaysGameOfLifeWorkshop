using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeWorkshop
{
    internal class Cell
    {
        public bool isAlive { get; set; }
        public bool AliveNextRound { get; set; }
        public bool LastGenerationStatus { get; set; }
        public int AmountOfNeighbours { get; set; }
        
        public Cell(bool alive)
        {
            isAlive = alive;
        }
    }
}
