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
			CreateWall();
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
	
		// создание стен на мапе
		// сдесь еще скорее всего будем вытягивать готовую карту и закидывать в лист
		public void CreateWall()
		{
			wall = new List<IWall>();
			int x = 0;
			int y = 0;
			for(int horizont = 11; horizont>0; horizont--, x+=50)
				wall.Add(new WallBrick(new Point(x, y)));

			for(int vertical = 7; vertical>0; vertical--, y+=50)
				wall.Add(new WallBrick(new Point(x, y)));

			for (int horizont = 11; horizont > 0; horizont--,x-=50)
				wall.Add(new WallBrick(new Point(x, y)));

			for (int vertical = 7; vertical > 0; vertical--,y-=50)
				wall.Add(new WallBrick(new Point(x, y)));
		}

	}
}
