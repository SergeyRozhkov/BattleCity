using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.worldOfTanks
{
    public class Gun
    {
        public List<Bullet> Bullets { get; set; }
        public int Speed { get; set; }
        public int Interval { get; set; } // принимает милисекунды
        DateTime TimeCurrent { get; set; }

        public Gun()
        {
            Bullets = new List<Bullet>();
            TimeCurrent = DateTime.Now;
            Interval = 10;
            Speed = 15;
        }
        public bool CheckShot()
        {
            var difference = (int)(DateTime.Now - TimeCurrent).TotalSeconds * 1000;
            if (difference > Interval)
            {
                TimeCurrent = DateTime.Now;
                return true;
            }
            else
                return false;
        }
        public void Shot(Tank tank) => AddShot(tank);
        public void AddShot(Tank tank)
        {
            Bullets.Add(new Bullet(tank) { Speed = this.Speed });
        }
        public void RemoteShot(int number)
        {
            Bullets.RemoveAt(number);
        }
        public void MoveAllBullets()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].CheckAroundAndRemove())
                    Bullets[i].Move();
                else
                    RemoteShot(i);
            }
        }
    }
}
