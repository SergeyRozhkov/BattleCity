using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
    
    class Map
    {
        public Size Size { get; private set; }
        public TankMain Tank { get; private set; }
        public List<TankEnemy> tankEmenies;
        public List<Wall> wall;

        public Map(Size size)
        {
            Size = size;
        }
    }
}
