using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BattleCity.worldOfTanks
{
	public class TankEnemy : Tank
	{
		public TankEnemy()
		{
			Direction = TankDirection.Up;
			Location = new Point(0, 0);
			Size = new Size(50, 50);
			dictDirection = new Dictionary<TankDirection, Image>
			{
				[TankDirection.Up] = Image.FromFile(pathImage + @"\TankEnemy\TankUp.png"),
				[TankDirection.Right] = Image.FromFile(pathImage + @"\TankEnemy\TankRight.png"),
				[TankDirection.Down] = Image.FromFile(pathImage + @"\TankEnemy\TankDown.png"),
				[TankDirection.Left] = Image.FromFile(pathImage + @"\TankEnemy\TankLeft.png")
			};
		}

		public void AutoControl(object sender, KeyEventArgs args, List<IGameObject> gameObjects)
		{
			// ТУТ АВТОПИЛОТ
		}
	}
}
