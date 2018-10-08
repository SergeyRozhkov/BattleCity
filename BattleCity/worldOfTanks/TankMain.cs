using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BattleCity.worldOfTanks
{
    public class TankMain
    {
        // СДЕЛАЙ ПО СВОЕМУ ПУТЬ, ИБО Я НЕ ХОТЕЛ СИЛЬНО ЗАЦИКЛИВАТЬСЯ С МЕТОДОМ, КОТОРЫЙ ВЫТАСКИВАЕТ ПУТЬ ДО ПРОЕКТА.)))
        static string pathImage = @"C:\Users\litotes\source\repos\BattleCity\BattleCity\image\TankMain\";
        // словарь соотвествия направление - картинка
        Dictionary<TankDirection, Image> dictDirection;

        // свойсво напраление объекта
        public TankDirection Direction { get; private set; }
        public bool Life { get; }

        // функциональное свойство, выдает текущее фото
        public Image GetImage 
        {
            get { return dictDirection[Direction]; }
        }

        public TankMain()
        {
            Direction = TankDirection.Up;
            Life = true;
            dictDirection = new Dictionary<TankDirection, Image>
            {
                [TankDirection.Up] = Image.FromFile(pathImage + @"TankUp.jpg"),
                [TankDirection.Right] = Image.FromFile(pathImage + @"TankRight.jpg"),
                [TankDirection.Down] = Image.FromFile(pathImage + @"TankDown.jpg"),
                [TankDirection.Left] = Image.FromFile(pathImage + @"TankLeft.jpg")
            };
        }
        // меняет картинку в соотвествие клавиши
        public void InputKeybord(object sender, KeyEventArgs args)
        {
            if (!(37 <= args.KeyValue && args.KeyValue <= 40)) return; // если не стрелки, то ничего не меняем
            Direction = (TankDirection)args.KeyValue; // преобразовываем цифру в перечисление и записывает в Direction
        }
    }
}
