using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BattleCity.worldOfTanks;

namespace BattleCity
{
    public partial class FormGame : Form
    {
        Map Map { get; set; }
        PictureBox TankMajor { get; set; }
        List<PictureBox> PictureWalls { get; set; }
        List<PictureBox> PuctureEnemies { get; set; }
        Timer Timer { get; set; }
		

		public FormGame(Map map)
        {
            Map = map; // Обязательно перед любой доп. инициализацией
            InitializeComponent(); // что-то там создает
            ClientSize = Map.Size; // размер окна
            TankMajor = CreateTankMain(); // Создает основной крутой танк
            PictureWalls = CreateBoxForWalls(); // Создает боксы для стен
            PuctureEnemies = CreateBoxForEnemies(); // враги
            // событие при нажатии на кнопки
            KeyDown += (sender, args) => {
                Map.Control(sender, args);
                TankMajor.Image = Map.tankMain.Image;
                TankMajor.Location = Map.tankMain.Location;
            };

            Timer = new Timer();
            Timer.Interval = 40;
			Timer.Tick += (sender, args) =>
			{
				Map.ControlEventEnemyTanks(sender, args);
				for (int i = 0; i < PuctureEnemies.Count; i++)
				{
					PuctureEnemies[i].Image = Map.tankEnemies[i].Image;
					PuctureEnemies[i].Location = Map.tankEnemies[i].Location;
				}
			};
			Timer.Start();
        }

        PictureBox CreateTankMain()
        {
            return new PictureBox
            {
                Size = Map.tankMain.Size,
                Image = Map.tankMain.Image,
                Location = Map.tankMain.Location,
                Parent = this
            };
        }
        List<PictureBox> CreateBoxForWalls()
        {
            var result = new List<PictureBox>();
            for (int i = 0; i < Map.wall.Count; i++)
                result.Add(new PictureBox
                {
                    Size = Map.wall[i].Size,
                    Image = Map.wall[i].Image,
                    Location = Map.wall[i].Location,
                    Parent = this
                });
            return result;
        }
        List<PictureBox> CreateBoxForEnemies()
        {
            var result = new List<PictureBox>();
            for (int i = 0; i < Map.tankEnemies.Count; i++)
                result.Add(new PictureBox
                {
                    Size = Map.tankEnemies[i].Size,
                    Image = Map.tankEnemies[i].Image,
                    Location = Map.tankEnemies[i].Location,
                    Parent = this
                });
            return result;
        }
        private void FormGame_Load(object sender, EventArgs e)
        {

        }
    }
}
