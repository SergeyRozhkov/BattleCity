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

		// Проверяет путь на препятствия
        protected bool CheckWay(TankDirection direction, List<IGameObject> gameObjects)
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
