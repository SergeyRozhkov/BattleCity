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
        PictureBox[] PictureBullets = new PictureBox[100];
        Timer Timer { get; set; }

        PictureBox box;

		public FormGame(Map map)
        {
            Map = map; // Обязательно перед любой доп. инициализацией
            InitializeComponent(); // что-то там создает
            ClientSize = Map.Size; // размер окна
            TankMajor = CreateTanksMain(); // Создает основной крутой танк
            PictureWalls = CreateBoxForWalls(); // Создает боксы для стен
            PuctureEnemies = CreateBoxForEnemies(); // враги




            for (int i = 0; i < PictureBullets.Length; i++)
                PictureBullets[i] = new PictureBox() { Parent = this };
            // событие при нажатии на кнопки
            KeyDown += (sender, args) => {
                Map.Control(sender, args);
                TankMajor.Image = Map.TanksMain[0].Image;
                TankMajor.Location = Map.TanksMain[0].Location;
            };

            Timer = new Timer();
            Timer.Interval = 31;
            Timer.Tick += (sender, args) =>
            {
                Map.ControlEventEnemyTanks(sender, args);
                Map.UpdateBullets();
                for (int i = 0; i < PuctureEnemies.Count; i++)
                {
                    PuctureEnemies[i].Size = Map.tankEnemies[i].Size;
                    PuctureEnemies[i].Image = Map.tankEnemies[i].Image;
                    PuctureEnemies[i].Location = Map.tankEnemies[i].Location;
                }
                for (int i = 0; i < Map.TanksMain[0].Gun.Bullets.Count; i++)
                {
                    PictureBullets[i].Size = Map.TanksMain[0].Gun.Bullets[i].Size;
                    PictureBullets[i].Image = Map.TanksMain[0].Gun.Bullets[i].Image;
                    PictureBullets[i].Location = Map.TanksMain[0].Gun.Bullets[i].Location;
                }
            };
            Timer.Start();
        }

        PictureBox CreateTanksMain()
        {
            return new PictureBox
            {
                Size = Map.TanksMain[0].Size,
                Image = Map.TanksMain[0].Image,
                Location = Map.TanksMain[0].Location,
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
