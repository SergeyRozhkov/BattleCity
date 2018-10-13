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
		private PictureBox[] pictureBox = new PictureBox[100];
		private int Counter = 1; // этот счетчик сделал, чтоб пикчер боксы перебирать

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
			
			//пикчер бокс для TankMain
			pictureBox[0] = new PictureBox
			{
				Size = Map.tankMain.Size,
				Image = Map.tankMain.Image,
				Location = Map.tankMain.Location,
				Parent = this
            };
			//выдает пикчер боксы WallBrick
			foreach (IWall wall in Map.wall)
			{
				pictureBox[Counter] = new PictureBox
				{
					Size = wall.Size,
					Image = wall.Image,
					Location = wall.Location,
				    Parent = this
				};
				Counter++;
			}

			KeyDown += (sender, args) => {
				Map.Control(sender, args);
				pictureBox[0].Image = Map.tankMain.Image;
				pictureBox[0].Location = Map.tankMain.Location;
			};
		}
	}
}
