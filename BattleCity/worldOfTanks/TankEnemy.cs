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
        Random random = new Random();

		public TankEnemy(Point location, TankDirection direction	)
		{
			dictDirection = new Dictionary<TankDirection, Image>
			{
				[TankDirection.Up] = Image.FromFile(pathImage + @"\TankEnemy\TankUp.png"),
				[TankDirection.Right] = Image.FromFile(pathImage + @"\TankEnemy\TankRight.png"),
				[TankDirection.Down] = Image.FromFile(pathImage + @"\TankEnemy\TankDown.png"),
				[TankDirection.Left] = Image.FromFile(pathImage + @"\TankEnemy\TankLeft.png")
			};
			Direction = direction;
			Location = location;
			Size = Image.Size;
		}

        public override void Control(object sender, EventArgs args, List<IGameObject> gameObjects)
        {
            var wayChecked = CheckWay(Direction, gameObjects);
            if (wayChecked)
                Move();
            else
                Direction = (TankDirection)random.Next(37, 41);
        }

        protected override void Move()
        {
            switch (Direction)
            {
                case TankDirection.Left:
                    location.X -= Step;
                    break;
                case TankDirection.Up:
                    location.Y -= Step;
                    break;
                case TankDirection.Right:
                    location.X += Step;
                    break;
                case TankDirection.Down:
                    location.Y += Step;
                    break;
            }
        }
    }
}
