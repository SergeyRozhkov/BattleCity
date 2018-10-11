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
        public TankMain()
        {
            Direction = TankDirection.Up;
            location = new Point(0, 0);
            Size = new Size(50, 50);
            dictDirection = new Dictionary<TankDirection, Image>
            {
                [TankDirection.Up] = Image.FromFile(pathImage + @"\TankMain\TankUp.png"),
                [TankDirection.Right] = Image.FromFile(pathImage + @"\TankMain\TankRight.png"),
                [TankDirection.Down] = Image.FromFile(pathImage + @"\TankMain\TankDown.png"),
                [TankDirection.Left] = Image.FromFile(pathImage + @"\TankMain\TankLeft.png")
            };
        }
        public override void Control(object sender, KeyEventArgs args, List<IGameObject> gameObjects)
        {
            if (!(37 <= args.KeyValue && args.KeyValue <= 40)) return; // если не стрелки, то ничего не меняем
            bool wayChecked = CheckWay((TankDirection)args.KeyValue, gameObjects);
            if (wayChecked)
            {
                Direction = (TankDirection)args.KeyValue;
                Move();
            }
                
        }
    }
}
