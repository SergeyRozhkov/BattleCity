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
        public Map Map { get; set; }
        PictureBox BoxTankMain;

        public FormGame(Map map)
        {
            InitializeComponent();
            Map = map;
            Create();
        }

        void Create()
        {
            BackColor = Color.Black;
            ClientSize = Map.Size;
			BoxTankMain = new PictureBox
			{
				Size = Map.Tank.Size,
				Image = Map.Tank.Image,
				Location = Map.Tank.Location,
				Parent = this
            };
            KeyDown += (sender, args) => {
                Map.Tank.Control(sender, args);
                BoxTankMain.Image = Map.Tank.Image;
                BoxTankMain.Location = Map.Tank.Location;
            };
        }
    }
}
