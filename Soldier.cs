using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication4
{
    class Soldier
    {
        public int life = 50000;
        private bool isDead = false;

        public int One_X = 1280;
        public int One_Y = 0;
        public int Two_X = 1280;
        public int Two_Y = 200;
        public int Three_X = 780;
        public int Three_Y = 50;
        public int Four_X = 780;
        public int Four_Y = 200;

        public Image image;
        private Panel pnl = null;

        Graphics g;

        public Soldier(Panel p)
        {
            pnl = p; 
            g = pnl.CreateGraphics();
            image = Image.FromFile(Environment.CurrentDirectory + "\\soldier.png");
        }

        public int Life()
        {
            return this.life;
        }

        public bool experiencePain()
        {
            life-=1;
            if (life < 0)
            {
                isDead = true;
                Application.Exit();
            }
            return isDead;
        }
        int isdeadfirsttime = -1;
        public void Draw()
        {
            if (!isDead)
            {
                try
                {
                    g.DrawImage(image, Four_X, Four_Y, 148, 148);
                }
                catch (Exception x)
                {
                }
            }
            else
            {
                if (1==10&&isdeadfirsttime == -1)
                {
                    Form form = new Form();
                    form.Text = "You killed a TaNk~~!";
                    form.SetBounds(500, 500, 700, 20);
                    form.Show();
                    new System.Threading.ManualResetEvent(false).WaitOne(1750);
                    form.Close();
                    isdeadfirsttime = 0;
                }
            }
        }

        public void SetLocation(int x, int y)
        {
            One_X = x + 148;
            Two_X = x + 148;
            Three_X = x;
            Four_X = x;
            One_Y = y;
            Two_Y = y + 148;
            Three_Y = y + 148;
            Four_Y = y;
        }

        public void MoveLeft()
        {
            One_X -= 40;
            Two_X -= 40;
            Three_X -= 40;
            Four_X -= 40;
        }

        public void MoveRight()
        {
            One_X += 40;
            Two_X += 40;
            Three_X += 40;
            Four_X += 40;
        }

        public void MoveUp()
        {
            One_Y -= 40;
            Two_Y -= 40;
            Three_Y -= 40;
            Four_Y -= 40;
        }

        public void MoveDown()
        {
            One_Y += 40;
            Two_Y += 40;
            Three_Y += 40;
            Four_Y += 40;
        }
    }
}
