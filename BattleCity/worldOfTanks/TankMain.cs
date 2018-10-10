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
        static string pathImage = Application.StartupPath + @"\image\TankMain";

        private Point location;
        Dictionary<TankDirection, Image> dictDirection;

        public TankDirection Direction { get; private set; }
        public Size Size { get; private set; }
        public Point Location { get { return location; } set { location = value; } }
        public Image GetImage { get { return dictDirection[Direction]; }
        }

        public Point Location1 { get => location; set => location = value; }

        public TankMain()
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
        public void Control(object sender, KeyEventArgs args)
        {
            if (!(37 <= args.KeyValue && args.KeyValue <= 40)) return; // если не стрелки, то ничего не меняем
            Direction = (TankDirection)args.KeyValue; // преобразовываем цифру в перечисление и записывает в Direction
            Move((TankDirection)args.KeyValue);
        }
        private void Move(TankDirection direction)
        {
            if (CheckWay(direction))
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
        private bool CheckWay(TankDirection direction)
        {
            switch (direction)
            {
                case TankDirection.Left:
                    return (location.X - Step >= 0) ? true : false;
                case TankDirection.Up:
                    return (location.Y - Step >= 0) ? true : false;
                case TankDirection.Right:
                    return (location.X + Step <= Map.Size.Width - Size.Width) ? true : false;
                case TankDirection.Down:
                    return (location.Y + Step <= Map.Size.Height - Size.Height) ? true : false;
            }
            throw new ArgumentException();
        }
    }
}
