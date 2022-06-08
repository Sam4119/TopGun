using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    public interface IObject
    {
        void Update();
        Coordinate Position { get; }
        string Type { get; }
    }
}
