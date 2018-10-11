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
		public List<IGameObject> listGameObjects;
		

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

		// управление игровым процессом
		public void Control(object sender, KeyEventArgs args)
		{
			Tank.Control(sender, args, listGameObjects);
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

		// создание списка всех объектов
		public List<IGameObject> CreatelistGameObjects(Tank tank, List<Tank> enemies, List<IWall> walls)
		{
			var result = new List<IGameObject>() { tank };
			foreach (var item in enemies)
				result.Add(item);
			foreach (var item in walls)
				result.Add(item);
			return result;
		}

	}
}
