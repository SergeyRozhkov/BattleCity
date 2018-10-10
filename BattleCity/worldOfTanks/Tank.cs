using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
    public abstract class Tank : IGameObject
    {
        const int Step = 5;

        protected static string pathImage = Application.StartupPath + @"\image\TankMain";

        public Point location;
        public  Dictionary<TankDirection, Image> dictDirection;

        protected TankDirection Direction { get; set; }
        public Size Size { get; set; }
        public Point Location { get => location; set => location = value; }
        public Image Image
        {
            get { return dictDirection[Direction]; }
        }

        protected bool CheckWay(TankDirection direction, List<IGameObject> gameObjects)
        {
            switch (direction)
            {
                case TankDirection.Left:
                    var topLeft = new Point(Location.X - Step, Location.Y);
                    var bottomLeft = new Point(Location.X - Step, Location.Y - Size.Height);
                    foreach (var obj in gameObjects)
                    {
                        var top = topLeft.Y > obj.Location.Y + obj.Size.Height? true : false;
                        var bottom = bottomLeft.Y < obj.Location.Y ? true : false;
                        if (top || bottom)
                        {

                        }
                    }
                    break;
                case TankDirection.Up:
                    break;
                case TankDirection.Right:
                    break;
                case TankDirection.Down:
                    break;
                default:
                    break;
            }
        }
        protected void Move()
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

        public abstract void Control(object sender, KeyEventArgs args, List<IGameObject> gameObjects);
    }
}
