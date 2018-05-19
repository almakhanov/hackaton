using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Player
    {
        public int id;
        public int x;
        public int y;
        public string dir;
        public int xp;
        public ArrayList bs = new ArrayList();

        public Player(int id_, int x_, int y_, string dir_, int xp_)
        {
            id = id_;
            x = x_;
            y = y_;
            dir = dir_;
            xp = xp_;
        }

        public void shoot()
        {
            Bullet b = new Bullet(x+40/2-10, y+40/2-10, this);
            bs.Add(b);
        }

    }

}
