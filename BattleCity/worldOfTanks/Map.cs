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
        public List<Tank> tankEmenies;
        public List<IWall> wall;
        private List<IGameObject> listGameObjects;
        public Map()
        {
            Size = new Size(700, 600);
            Tank = new TankMain();
			CreateWall();
            listGameObjects = CreatelistGameObjects();
        }
        public Map(Size size) : base()
        {
            Size = size;
        }
        
		// управление игровым проецессом
        public void Control(object sender, KeyEventArgs args)
        {
            Tank.Control(sender, args, listGameObjects);
        }

		// создание стен
		public void CreateWall()
		{
			wall = new List<IWall>();
			int x = 0;
			int y = 0;
			for(int horizont = (Size.Width/50)-1; horizont>0; horizont--, x+=50)
				wall.Add(new WallBrick(new Point(x, y)));

			for(int vertical = (Size.Height/50)-1; vertical>0; vertical--, y+=50)
				wall.Add(new WallBrick(new Point(x, y)));

			for (int horizont = (Size.Width / 50)-1; horizont > 0; horizont--,x-=50)
				wall.Add(new WallBrick(new Point(x, y)));

			for (int vertical = (Size.Height / 50)-1; vertical > 0; vertical--,y-=50)
				wall.Add(new WallBrick(new Point(x, y)));
		}

		// создание списка всех объектов
		public List<IGameObject> CreatelistGameObjects()
		{
			var result = new List<IGameObject>() { Tank };
			//foreach (var item in tankEmenies)
			//	result.Add(item);
			foreach (var item in wall)
				result.Add(item);
			return result;
		}

	}
}
