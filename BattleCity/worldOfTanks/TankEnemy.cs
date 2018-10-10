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
            location = new Point(0, 0);
            Size = new Size(50, 50);
            dictDirection = new Dictionary<TankDirection, Image>
            {
                [TankDirection.Up] = Image.FromFile(pathImage + @"\TankUp.png"),
                [TankDirection.Right] = Image.FromFile(pathImage + @"\TankRight.png"),
                [TankDirection.Down] = Image.FromFile(pathImage + @"\TankDown.png"),
                [TankDirection.Left] = Image.FromFile(pathImage + @"\TankLeft.png")
            };
        }
        public override void Control(object sender, KeyEventArgs args, List<IGameObject> gameObjects)
        {
        }
    }
}
