using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleCity.worldOfTanks;

namespace BattleCity
{
    public partial class FormGame : Form
    {
        PictureBox BoxForTank;
        TankMain tank; // объекта танка для манипуляции с ним

        // я оставил, чтобы показать, как можно самому 
        // создавать объекты, посмтреть их свойства
        public FormGame(TankMain tankMain)
        {
            tank = tankMain;
            BoxForTank = new PictureBox
            {
                Size = tank.GetImage.Size,
                Image = tank.GetImage,
                Parent = this,
                // почему-то форм больше своих размеров, чем появляется при запуске
                Location = new Point(Width / 2 , Height / 2)
            };
            var textBox = new TextBox
            {
                Parent = this,
                Size = new Size(0, 0),
                Location = new Point(100, 100)

            };
            // а на этот есть фокус, но кнопку я задал невидимою для обработчика
            textBox.KeyDown += (sender, args) =>
            {
                tank.InputKeybord(sender, args);
                BoxForTank.Image = tank.GetImage;
            };
            // это сука хуйня не работает, типо нет фокуса на этот объект
            BoxForTank.KeyDown += (sender, args) => {
                tank.InputKeybord(sender, args);
            };

        }
    }
}
