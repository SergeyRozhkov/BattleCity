using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
	public class Bullet : IGameObject
	{

		private Point location;
		private Size TankSize;
		public Point Location { get => location; set => location = value; }
		public Size  Size { get; set; }
		public Image Image { get; set; }
        public int Speed { get; set; } // присваевается из пушки
        public TankDirection Direction { get; set; }
		// конструктор принимает направление танка, координаты и его размер
		public Bullet(Tank tank)
		{
			Direction = tank.Direction;
			Location = tank.Location;
            TankSize = tank.Size;
			FlyDirection(Direction);  
		}
		// задает размер и выбирает спрайт по направлению танка
		private void FlyDirection(TankDirection direction)
		{
			switch (direction)
			{
				case TankDirection.Left:
					Size = new Size(25, 8);
					Image = Image.FromFile(Application.StartupPath + @"\image\Bullet\BulletLeft.png");
					location.Y += (TankSize.Height-Size.Height)/2;
                    location.X -= 50;
					break;
				case TankDirection.Up:
					Size = new Size(8, 25);
					Image = Image.FromFile(Application.StartupPath + @"\image\Bullet\BulletUp.png");
					location.X += (TankSize.Width-Size.Width)/2;
					break;
				case TankDirection.Right:
					Size = new Size(25, 8);
					Image = Image.FromFile(Application.StartupPath + @"\image\Bullet\BulletRight.png");
					location.X += TankSize.Width-Size.Width;
					location.Y += (TankSize.Height-Size.Height)/2;
					break;
				case TankDirection.Down:
					Size = new Size(8, 25);
					Image = Image.FromFile(Application.StartupPath + @"\image\Bullet\BulletDown.png");
					location.X += (TankSize.Width-Size.Width)/2;
					location.Y += TankSize.Height-Size.Height;
					break;
			}
		}
        public void Move()
        {
            switch (Direction)
            {
                case TankDirection.Left:
                    location.X -= Speed;
                    break;
                case TankDirection.Up:
                    location.Y -= Speed;
                    break;
                case TankDirection.Right:
                    location.X += Speed;
                    break;
                case TankDirection.Down:
                    location.Y += Speed;
                    break;
            }
        }
        private object Check(IEnumerable<IGameObject> listGameObjects)
        {
            switch (Direction)
            {
                case TankDirection.Left:
                    {
                        var topLeftPoint = new Point(Location.X, Location.Y); // танк левый верхний угол 
                        var bottomLeftPoint = new Point(Location.X, Location.Y + Size.Height); // танк левый нижний угол 
                        foreach (var obj in listGameObjects)
                        {
                            if (this.Equals(obj)) continue;
                            var top = topLeftPoint.Y >= obj.Location.Y + obj.Size.Height;
                            var bottom = bottomLeftPoint.Y <= obj.Location.Y;
                            var left = topLeftPoint.X >= obj.Location.X + obj.Size.Width;
                            var right = topLeftPoint.X + Size.Width <= obj.Location.X;
                            if (top || bottom || left || right) continue; // если припяствие находится вверху или внизу - начинаем заново итерацию 
                            return obj; // если никакое условие не совпадает - false 
                        }
                        return null;
                    }
                case TankDirection.Up:
                    {
                        var topLeftPoint = new Point(Location.X, Location.Y);
                        var topRightPoint = new Point(Location.X + Size.Width, Location.Y);
                        foreach (var obj in listGameObjects)
                        {
                            if (this.Equals(obj)) continue;
                            var left = topLeftPoint.X >= obj.Location.X + obj.Size.Width;
                            var right = topRightPoint.X <= obj.Location.X;
                            var top = topLeftPoint.Y >= obj.Location.Y + obj.Size.Height;
                            var bottom = topLeftPoint.Y + Size.Height <= obj.Location.Y;
                            if (left || right || top || bottom) continue;
                            return obj;
                        }
                        return null;
                    }
                case TankDirection.Right:
                    {
                        var topRightPoint = new Point(Location.X + Size.Width, Location.Y);
                        var bottomRightPoint = new Point(Location.X + Size.Width, Location.Y + Size.Height);
                        foreach (var obj in listGameObjects)
                        {
                            if (this.Equals(obj)) continue;
                            var top = topRightPoint.Y >= obj.Location.Y + obj.Size.Height;
                            var bottom = bottomRightPoint.Y <= obj.Location.Y;
                            var right = topRightPoint.X <= obj.Location.X;
                            var left = topRightPoint.X >= obj.Location.X + obj.Location.X;
                            if (top || bottom || left || right) continue;
                            return obj;
                        }
                        return null;
                    }
                case TankDirection.Down:
                    {
                        var bottomLeftPoint = new Point(Location.X, Location.Y + Size.Height);
                        var bottomRightPoint = new Point(Location.X + Size.Width, Location.Y + Size.Height);
                        foreach (var obj in listGameObjects)
                        {
                            if (this.Equals(obj)) continue;
                            var left = bottomLeftPoint.X >= obj.Location.X + obj.Size.Width;
                            var right = bottomRightPoint.X <= obj.Location.X;
                            var top = bottomLeftPoint.Y - Size.Height >= obj.Location.Y + obj.Size.Height;
                            var bottom = bottomLeftPoint.Y <= obj.Location.Y;
                            if (left || right || top || bottom) continue;
                            return obj;
                        }
                        return null;
                    }
                default:
                    throw new ArgumentException("Не корректный ввод");
            }
        }
        public bool CheckAroundAndRemove()
        {
            var obj = Check(Map.TanksMain);
            if (obj != null)
            {
                Map.TanksMain.Remove((TankMain)obj);
                return false;
            }
            obj = Check(Map.tankEnemies);
            if (obj != null)
            {
                Map.tankEnemies.Remove((TankEnemy)obj);
                return false;
            }
            obj = Check(Map.wall);
            if (obj != null)
            {
                Map.wall.Remove((IWall)obj);
                return false;
            }
            foreach (var tank in Map.tankEnemies)
            {
                obj = Check(tank.Gun.Bullets);
                if (obj != null)
                {
                    tank.Gun.Bullets.Remove((Bullet)obj);
                    return false;
                }

            }
            return true;
        }
    }
}
