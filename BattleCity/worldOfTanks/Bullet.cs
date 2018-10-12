using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
	class Bullet : IGameObject
	{
		private const int step = 5;

		public Size Size { get; set; }
		public Point Location { get; set; }
		public Image Image { get; set; }
		private TankDirection Direction { get; set; }
		public Bullet(TankDirection direction, Point location)
		{
			Direction = direction;
			this.Location = location;
			Size = new Size(25, 8);
			Image = Image.FromFile(Application.StartupPath + @"\image\TankMain\BulletUp.png");
		}

		protected void Move()
		{
			switch (Direction)
			{
				case TankDirection.Left:
				Location.X -= Step;
				break;
				case TankDirection.Up:
				Location.Y -= Step;
				break;
				case TankDirection.Right:
				Location.X += Step;
				break;
				case TankDirection.Down:
				Location.Y += Step;
				break;
			}

		}

		protected bool CheckWay(TankDirection direction, List<IGameObject> gameObjects)
		{
			switch (direction)
			{
				case TankDirection.Left:
					{
						var topLeftPoint = new Point(Location.X - Step, Location.Y); // танк левый верхний угол 
						var bottomLeftPoint = new Point(Location.X - Step, Location.Y + Size.Height); // танк левый нижний угол 
						foreach (var obj in gameObjects)
						{
							if (this.Equals(obj)) continue;
							var top = topLeftPoint.Y >= obj.Location.Y + obj.Size.Height;
							var bottom = bottomLeftPoint.Y <= obj.Location.Y;
							var left = topLeftPoint.X >= obj.Location.X + obj.Size.Width;
							var right = topLeftPoint.X + Size.Width <= obj.Location.X;
							if (top || bottom || left || right) continue; // если припяствие находится вверху или внизу - начинаем заново итерацию 
							return false; // если никакое условие не совпадает - false 
						}
						return true;
					}
				case TankDirection.Up:
					{
						var topLeftPoint = new Point(Location.X, Location.Y - Step);
						var topRightPoint = new Point(Location.X + Size.Width, Location.Y - Step);
						foreach (var obj in gameObjects)
						{
							if (this.Equals(obj)) continue;
							var left = topLeftPoint.X >= obj.Location.X + obj.Size.Width;
							var right = topRightPoint.X <= obj.Location.X;
							var top = topLeftPoint.Y >= obj.Location.Y + obj.Size.Height;
							var bottom = topLeftPoint.Y + Size.Height <= obj.Location.Y;
							if (left || right || top || bottom) continue;
							return false;
						}
						return true;
					}
				case TankDirection.Right:
					{
						var topRightPoint = new Point(Location.X + Size.Width + Step, Location.Y);
						var bottomRightPoint = new Point(Location.X + Size.Width + Step, Location.Y + Size.Height);
						foreach (var obj in gameObjects)
						{
							if (this.Equals(obj)) continue;
							var top = topRightPoint.Y >= obj.Location.Y + obj.Size.Height;
							var bottom = bottomRightPoint.Y <= obj.Location.Y;
							var right = topRightPoint.X <= obj.Location.X;
							var left = topRightPoint.X >= obj.Location.X + obj.Location.X;
							if (top || bottom || left || right) continue;
							return false;
						}
						return true;
					}
				case TankDirection.Down:
					{
						var bottomLeftPoint = new Point(Location.X, Location.Y + Step + Size.Height);
						var bottomRightPoint = new Point(Location.X + Size.Width, Location.Y + Step + Size.Height);
						foreach (var obj in gameObjects)
						{
							if (this.Equals(obj)) continue;
							var left = bottomLeftPoint.X >= obj.Location.X + obj.Size.Width;
							var right = bottomRightPoint.X <= obj.Location.X;
							var top = bottomLeftPoint.Y - Size.Height >= obj.Location.Y + obj.Size.Height;
							var bottom = bottomLeftPoint.Y <= obj.Location.Y;
							if (left || right || top || bottom) continue;
							return false;
						}
						return true;
					}
				default:
				throw new ArgumentException("Не корректный ввод");
			}
		}

	}
}
