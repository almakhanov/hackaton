using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Arena
{
    public partial class Arena : Form
    {
        ArrayList ps = new ArrayList();
        Player p = new Player(0, 50, 300, "down", 100);
        int speedX;
        int speedY;
        int k = 5;


        public Arena()
        {
            InitializeComponent();
        }

        private void Arena_Load(object sender, EventArgs e)
        {
            Player p1 = new Player(1, 50, 50, "up", 100);
            Player p2 = new Player(2, 300, 300, "up", 100);

            ps.Add(p);
            ps.Add(p1);
            ps.Add(p2);
            timer1.Enabled = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            p.x += speedX;
            p.y += speedY;
            this.Refresh();
            this.Invalidate();
            panel1.Controls.Clear();
            foreach (Player i in ps){
                PictureBox p = new PictureBox();
                p.Location = new Point(i.x, i.y);
                p.Size = new Size(40,40);
                switch (i.dir)
                {
                    case "up":
                        p.BackgroundImage = Properties.Resources.right;
                        break;
                    case "down":
                        p.BackgroundImage = Properties.Resources.down;
                        break;
                    case "left":
                        p.BackgroundImage = Properties.Resources.left;
                        break;
                    case "right":
                        p.BackgroundImage = Properties.Resources.right1;
                        break;
                }
                p.BackgroundImageLayout = ImageLayout.Stretch;

                foreach(Bullet b in i.bs)
                {
                    if (b.x < panel1.Left || b.x > panel1.Right || b.y < panel1.Top || 
                        b.y > panel1.Bottom)
                    {
                        continue;
                    }

                    foreach (Player pl in ps)
                    {
                        if(pl != i)
                        {
                            if(b.x > pl.x && b.x < pl.x + 40 && b.y > pl.y && b.y < pl.y + 40)
                            {
                                pl.xp -= 60;
                                if(pl.xp <= 0)
                                {
                                    pl.x = pl.y = 0;
                                    pl.dir = "no";
                                }

                            }
                        }
                    }
                    
                    switch (b.dir)
                    {
                        case "up":
                            b.x += 0;
                            b.y += -k * 5;
                            break;
                        case "down":
                            b.x += 0;
                            b.y += k * 5;
                            break;
                        case "left":
                            b.x += -k * 5;
                            b.y += 0;
                            break;
                        case "right":
                            b.x += k * 5;
                            b.y += 0;
                            break;
                        case "no":
                            b.x = 0;
                            b.y = 0;
                            break;
                    }

                    PictureBox pb = new PictureBox();
                    pb.Location = new Point(b.x, b.y);
                    pb.Size = new Size(20, 20);
                    pb.BackgroundImage = Properties.Resources.tile019;
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    panel1.Controls.Add(pb);
                }


                panel1.Controls.Add(p);

            }
        }

        private void Arena_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    p.dir = "up";
                    speedX = 0;
                    speedY = -k;
                    break;
                case Keys.Down:
                    p.dir = "down";
                    speedX = 0;
                    speedY = k;
                    break;
                case Keys.Left:
                    p.dir = "left";
                    speedX = -k;
                    speedY = 0;
                    break;
                case Keys.Right:
                    p.dir = "right";
                    speedX = k;
                    speedY = 0;
                    break;
                case Keys.S:
                    p.shoot();                    
                    break;
            }
        }
        

       
    }
}
