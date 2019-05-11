using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FischeVerschenkenRevived
{
    class Ship
    {
        List<Position> subShips;

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
