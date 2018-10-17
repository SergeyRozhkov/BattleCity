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
        public List<Tank> tankEnemies;
        public List<IWall> wall;
        private List<IGameObject> listGameObjects;
        public Map()
        {
            Size = new Size(700, 600);											// Задание размера карты
			tankMain = new TankMain(new Point(300, 500), TankDirection.Up);		// Создание Main танка
            wall = CreateWall();								// Создание стен и занесение их в лист wall
			tankEnemies = CreateEnemies();						// Создание врагов и занесение их в лист tankEnemies
            listGameObjects = CreatelistGameObjects();			// Создание листа всех объектов
        }
        public Map(Size size) : base()
        {
            Size = size;
        }

        // Метод активируемый таймером, для контроля всех врагов
        public void ControlEventEnemyTanks(object sender, EventArgs args)
        {
            foreach (var tank in tankEnemies)
                tank.Control(sender, args, listGameObjects);
        }

		// Передает контроль Main танку
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
			for (int i = 1; i < 13; i++)
				result.Add(new TankEnemy(new Point(i*50, 50), TankDirection.Down));
			//result.Add(new TankEnemy(new Point(100, 50), TankDirection.Down));
			//result.Add(new TankEnemy(new Point(600, 50), TankDirection.Down));
			return result;
        }

		// создание списка всех объектов
		public List<IGameObject> CreatelistGameObjects()
		{
			var result = new List<IGameObject>() { tankMain };
           foreach (var item in tankEnemies)
               result.Add(item);
            foreach (var item in wall)
				result.Add(item);
			return result;
		}

	}
}
