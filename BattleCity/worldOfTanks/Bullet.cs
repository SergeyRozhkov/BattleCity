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


		private Point location;
		private Size TankSize;
		public Point Location { get => location; set => location = value; }
		public Size  Size { get; set; }
		public Image Image { get; set; }
		private TankDirection Direction { get; set; }

		// конструктор принимает направление танка, координаты и его размер
		public Bullet(TankDirection direction, Point location, Size SizeTank)
		{
			Direction = direction;
			this.Location = location;
			TankSize = SizeTank;
			FlyDirection(direction);  
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
		
	}
}
