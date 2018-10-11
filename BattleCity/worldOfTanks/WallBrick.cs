using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BattleCity.worldOfTanks
{
	class WallBrick : IWall
	{
		public Size Size { get; set; }
		public Point Location { get; set; }
		public WallBrick(Point location)
		{
			this.Location = location;
			Size = new Size(50, 50);
		}
		public Image Image = Image.FromFile(Application.StartupPath + @"\image\Wall\Wall.png");
	}
}
