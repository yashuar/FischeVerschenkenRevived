using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FischeVerschenkenRevived
{
    class Ship
    {
        public List<Position> subShips;
        public Game.CardinalDirection direction;
        public bool isDestroyed;

        Game.ShipType type;

        internal void SetShipType(Game.ShipType st)
        {
            type = st;
        }
        internal Game.ShipType GetShipType()
        {
            return this.type;
        }

        public Ship()
        {

        }

        public void SetSubships(List<Position> positions)
        {
            this.subShips = positions;
        }
    }
}
