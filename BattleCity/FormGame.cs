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
		private int Counter = 20; // этот счетчик сделал, чтоб пикчер боксы перебирать для стен, начиная с 20.
		// до 20 идет для танков, с запасиком)

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
			Map.listGameObjects = Map.CreatelistGameObjects(Map.Tank, Map.tankEmenies, Map.wall);  // create ListGameObject in Map
			
			//пикчер бокс для TankMain
			pictureBox[0] = new PictureBox
			{
				Size = Map.Tank.Size,
				Image = Map.Tank.Image,
				Location = Map.Tank.Location,
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
				Map.Tank.Control(sender, args, Map.listGameObjects);
				pictureBox[0].Image = Map.Tank.Image;
				pictureBox[0].Location = Map.Tank.Location;
			};
		}
	}
}
