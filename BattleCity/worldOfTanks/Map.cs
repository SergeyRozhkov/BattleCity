using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
    
    public class Map
    {
        public static Size Size { get; private set; }
        public Tank Tank { get; private set; }
        public List<TankEnemy> tankEmenies;
        public List<IWall> wall;
        public Map()
        {
            Size = new Size(600, 400);
            Tank = new TankMain();
        }
        public Map(Size size) : base()
        {
            Size = size;
        }
        // управление игровым проецессом
        public void Control(object sender, KeyEventArgs args)
        {
            Tank.Control(sender, args);
        }
    }
}
