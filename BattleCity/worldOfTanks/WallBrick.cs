using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BattleCity.worldOfTanks
{
	class WallBrick
	{
		public Size size { get; private set; }
		public Point location;
		public WallBrick(Point location)
		{
			this.location = location;
			size = new Size(50, 50);
		}
		public Image Image = Image.FromFile(Application.StartupPath + @"\image\Wall\Wall.png");
	}
}
