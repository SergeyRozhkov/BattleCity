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
                    var topLeftPoint = new Point(Location.X - Step, Location.Y); // танк левый верхний угол 
                    var bottomLeftPoint = new Point(Location.X - Step, Location.Y + Size.Height); // танк левый нижний угол 
                    foreach (var obj in gameObjects)
                    {
                        this.Equals(obj);
                        // проверяем, если припястивие выше - true, иначе false 
                        var top = topLeftPoint.Y >= obj.Location.Y + obj.Size.Height ? true : false;
                        // проверяем, если припяствие ниже - true, иначе false 
                        var bottom = bottomLeftPoint.Y <= obj.Location.Y ? true : false;
                        if (top || bottom) continue; // если припяствие находится вверху или внизу - начинаем заново итерацию 
                        else
                        {
                            var objTopRightPointX = obj.Location.X + obj.Size.Width;
                            if (topLeftPoint.X < objTopRightPointX) // проверяем наличие объекта в переди 
                                continue;
                            if (topLeftPoint.X - objTopRightPointX >= Step) // проверяем наличие расстояние до объекта 
                                continue;
                        }
                        return false; // если никакое условие не совпадает - false 
                    }
                    return true;
                case TankDirection.Up:
                    break;
                case TankDirection.Right:
                    break;
                case TankDirection.Down:
                    break;
                default:
                    throw new ArgumentException("Не корректный ввод");
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
