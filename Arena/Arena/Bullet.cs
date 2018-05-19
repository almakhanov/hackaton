using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Bullet
    {
        public int x;
        public int y;
        public int size;
        public Player player;
        public int speed;
        public string dir;

        public Bullet(int x_, int y_, Player p_)
        {
            x = x_;
            y = y_;
            player = p_;
            dir = player.dir;
            speed = 5 * 3;
            size = 5 / 3;
        }

    }
}
