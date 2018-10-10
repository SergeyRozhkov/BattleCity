using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
    
    public class Map
    {
        public static Size Size { get; private set; }
        public Tank Tank { get; private set; }
        public List<Tank> tankEmenies;
        public List<IWall> wall;
        private List<IGameObject> listGameObjects;
        public Map()
        {
            Size = new Size(600, 400);
            Tank = new TankMain();
        }
        public Map(Size size) : base()
        {
            Size = size;
        }
        // управление игровым проецессом
        public void Control(object sender, KeyEventArgs args)
        {
            Tank.Control(sender, args, listGameObjects);
        }
        // создание списка всех объектов
        private List<IGameObject> CreatelistGameObjects(Tank tank, List<Tank> enemies,List<IWall> walls)
        {
            var result = new List<IGameObject>() { tank } ;
            foreach (var item in enemies)
                result.Add(item);
            foreach (var item in walls)
                result.Add(item);
            return result;
        }
    }
}
