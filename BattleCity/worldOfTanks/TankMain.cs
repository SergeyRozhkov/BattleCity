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
    public class TankMain
    {
        const int Step = 5;
        private Point location;
        static string pathImage = Application.StartupPath + @"\image\TankMain";
        Dictionary<TankDirection, Image> dictDirection;
        public TankDirection Direction { get; private set; }
        public Point Location { get { return location; } set { location = value; } }

        public Image GetImage 
        {
            get { return dictDirection[Direction]; }
        }

        public Point Location1 { get => location; set => location = value; }

        public TankMain()
        {
            Direction = TankDirection.Up;
            location = new Point(0, 0);
            dictDirection = new Dictionary<TankDirection, Image>
            {
                [TankDirection.Up] = Image.FromFile(pathImage + @"\TankUp.png"),
                [TankDirection.Right] = Image.FromFile(pathImage + @"\TankRight.png"),
                [TankDirection.Down] = Image.FromFile(pathImage + @"\TankDown.png"),
                [TankDirection.Left] = Image.FromFile(pathImage + @"\TankLeft.png")
            };
        }
        // меняет картинку в соотвествие клавиши
        public void InputKeybord(object sender, KeyEventArgs args)
        {
            if (!(37 <= args.KeyValue && args.KeyValue <= 40)) return; // если не стрелки, то ничего не меняем
            Direction = (TankDirection)args.KeyValue; // преобразовываем цифру в перечисление и записывает в Direction
            Move((TankDirection)args.KeyValue);
        }
        public void Move(TankDirection direction)
        {
            switch (direction)
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
