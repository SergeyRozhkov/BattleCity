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
        TankMain tank; 

        public FormGame(TankMain tankMain)
        {
            StartPosition = FormStartPosition.CenterScreen;
            tank = tankMain;
            BoxForTank = new PictureBox
            {
                Size = tank.GetImage.Size,
                Image = tank.GetImage,
                Parent = this,
                // почему-то форм больше своих размеров, чем появляется при запуске
                Location = tank.Location
            };
            // теперь это работает. Заебись.
            KeyDown += (sender, args) => {
                tank.InputKeybord(sender, args);
                BoxForTank.Image = tank.GetImage;
                BoxForTank.Location = tank.Location;
            };

        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }
    }
}
