using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeWorkshop
{
    internal class Cell
    {
        public bool IsAlive { get; set; }
        public bool AliveNextRound { get; set; }
        public bool LastGenerationStatus { get; set; }
        public int AmountOfNeighbours { get; set; }
        
        public Cell(bool alive)
        {
            IsAlive = alive;
        }

        public void CheckNextCellStatus()
        {
            LastGenerationStatus = IsAlive;

            if(!IsAlive)
            {
                //Eine tote Zelle mit genau 3 Nachbarn wird nächste Runde wiederbelebt
                if(AmountOfNeighbours == 3)
                    AliveNextRound = true;
            }
            else
            {
                //Eine lebende Zelle mit weniger als zwei lebenden Nachbarn stirbt an Einsamkeit
                //Eine lebende Zelle mit mehr als drei Nachbarn stirbt an Überbevölkerung
                if (AmountOfNeighbours < 2 || AmountOfNeighbours > 3)
                    AliveNextRound = false;
                //Eine lebende Zelle mit zwei oder drei Nachbarn überlebt
                else if (AmountOfNeighbours == 2 || AmountOfNeighbours == 3)
                    AliveNextRound = true;
            }
        }

        public void Update()
        {
            IsAlive = AliveNextRound;
        }
    }
}
