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
        public Size Size { get; private set; }
        public Tank tankMain { get; private set; }
        public List<Tank> tankEmenies;
        public List<IWall> wall;
        private List<IGameObject> listGameObjects;
        public Map()
        {
            Size = new Size(700, 600);
            tankMain = new TankMain();
            wall = CreateWall();
            tankEmenies = CreateEnemies();
            listGameObjects = CreatelistGameObjects();
        }
        public Map(Size size) : base()
        {
            Size = size;
        }
        // контроль над всеми врагами
        public void ControlEventEnemyTanks(object sender, EventArgs args)
        {
            foreach (var tank in tankEmenies)
                tank.Control(sender, args, listGameObjects);
        }
		// передает контроль в tankMain
        public void Control(object sender, KeyEventArgs args)
        {
            tankMain.Control(sender, args, listGameObjects);
        }

		// создание стен
		List<IWall> CreateWall()
		{
			var result = new List<IWall>();
			int x = 0;
			int y = 0;
			for(int horizont = (Size.Width/50)-1; horizont>0; horizont--, x+=50)
                result.Add(new WallBrick(new Point(x, y)));

			for(int vertical = (Size.Height/50)-1; vertical>0; vertical--, y+=50)
                result.Add(new WallBrick(new Point(x, y)));

			for (int horizont = (Size.Width / 50)-1; horizont > 0; horizont--,x-=50)
                result.Add(new WallBrick(new Point(x, y)));

			for (int vertical = (Size.Height / 50)-1; vertical > 0; vertical--,y-=50)
                result.Add(new WallBrick(new Point(x, y)));
            return result;
		}
        // создание врагов
        List<Tank> CreateEnemies()
        {
            var result = new List<Tank>();
            result.Add(new TankEnemy());
            result.Add(new TankEnemy());
            result.Add(new TankEnemy());
            return result;
        }
		// создание списка всех объектов
		public List<IGameObject> CreatelistGameObjects()
		{
			var result = new List<IGameObject>() { tankMain };
            foreach (var item in tankEmenies)
                result.Add(item);
            foreach (var item in wall)
				result.Add(item);
			return result;
		}

	}
}
