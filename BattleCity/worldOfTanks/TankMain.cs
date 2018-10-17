using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
// I LOVE TANKS
namespace BattleCity.worldOfTanks
{
    public class TankMain : Tank
    {
		public TankMain(Point location, TankDirection direction)
		{
			dictDirection = new Dictionary<TankDirection, Image>
			{
				[TankDirection.Up] = Image.FromFile(pathImage + @"\TanksMain\TankUp.png"),
				[TankDirection.Right] = Image.FromFile(pathImage + @"\TanksMain\TankRight.png"),
				[TankDirection.Down] = Image.FromFile(pathImage + @"\TanksMain\TankDown.png"),
				[TankDirection.Left] = Image.FromFile(pathImage + @"\TanksMain\TankLeft.png")
			};
			Direction = direction;
			Location = location;
			Size = Image.Size;
            Gun = new Gun();
		}
		public override void Control(object sender, EventArgs a)
        {
            KeyEventArgs args = a as KeyEventArgs;
            if (!(37 <= args.KeyValue && args.KeyValue <= 40 || args.KeyValue == 32)) return; // если не стрелки, то ничего не меняем
            if (37 <= args.KeyValue && args.KeyValue <= 40)
            {
                Direction = (TankDirection)args.KeyValue;
                if (CheckWay())
                    Move();
            }
            if (args.KeyValue == 32)
            {
                if (Gun.CheckShot())
                {
                    Gun.Shot(this);
                }
            }


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
