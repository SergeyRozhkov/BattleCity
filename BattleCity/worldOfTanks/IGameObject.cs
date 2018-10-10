using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity.worldOfTanks
{
    public interface IGameObject
    {
        Size Size { get; set; }
        Point Location { get; set; }
    }
}
