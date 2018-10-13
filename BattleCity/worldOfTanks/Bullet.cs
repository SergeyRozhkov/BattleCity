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

		
		

	}
}
