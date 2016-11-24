using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System;

namespace WindowsFormsApplication4
{
    class Glock
    {
        Thread t = null;
        public int x, y;
        int countBulleties = -1;
        Panel pee;
        Graphics g;
        Image myBullet;
        System.Collections.Generic.List<GlockBullies> B = null;
        System.Collections.Generic.List<Antagonist> ant = null;
        WMPLib.WindowsMediaPlayer wmp;
        Soldier soldier;
        public Glock(Panel p, int X, int Y, System.Collections.Generic.List<Antagonist> ant, Soldier soldier)
        {
            this.soldier = soldier;
            try
            {
                wmp = new WMPLib.WindowsMediaPlayer();
                wmp.URL = "ak.wav";
            }
            catch (Exception e)
            {
            }
            this.ant = ant;
            x = X; y = Y;
            pee = p; g = pee.CreateGraphics();
            try
            {
                myBullet = Image.FromFile(Environment.CurrentDirectory + "\\bullet.png");
            }
            catch (Exception e)
            {
            }
        }
        public System.Collections.Generic.List<GlockBullies> Sheut()
        {
            countBulleties += 2;
            System.Collections.Generic.List<GlockBullies> bBs = new System.Collections.Generic.List<GlockBullies>();
            for (int i = 0; i < countBulleties; i++)
            {
                    try
                    {
                        wmp.controls.play();
                    }
                    catch (Exception e)
                    {
                    }
                bBs.Add(new GlockBullies(x, y));
            }
            return bBs;
        }
        public System.Collections.Generic.List<GlockBullies> randomizeShiets(System.Collections.Generic.List<GlockBullies> bullies)
        {
            Random rnd = new Random();
            for (int j = 0; j < bullies.Count; j++)
            {
                int xrand = rnd.Next(84);
                int yrand = rnd.Next(4) - rnd.Next(4);
                bullies[j].messWithYa();
                bullies[j].moveittoit(xrand, yrand);
            }
            return bullies;
        }
        public void checkDeadness()
        {
            for (int l = 0; l < ant.Count; l++)
            {
                for (int m = 0; m < B.Count; m++)
                {
                    if (ant[l].One_X >= B[m].whereami.X && ant[l].Four_X <= B[m].whereami.X)
                    {
                        if (ant[l].One_Y <= B[m].whereami.Y && ant[l].Two_Y >= B[m].whereami.Y)
                        {
                            if (ant[l].One_X < 900 && ant[l].One_X > 400)
                            {
                                Boolean isTankDead = ant[l].experiencePain();
                                B[m].dead = true;
                                if (isTankDead)
                                {
                                    ant.Remove(ant[l]);
                                    soldier.life += 6100;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void exe(System.Collections.Generic.List<GlockBullies> bullies)
        {
            this.B = bullies;
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(moveTheBullets);
            timer1.Start();
        }
        private void moveTheBullets(object sender, EventArgs e)
        {
            for (int k = 0; k < B.Count; k++)
            {
                if (B[k].dead != true)
                {
                    B[k].move();
                    try
                    {
                        g.DrawImage(myBullet, B[k].whereami.X, B[k].whereami.Y, 13, 13);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (B[k].whereami.X > 1220)
                {
                    B.Remove(B[k]);
                }
            }
            checkDeadness();
        }
    }
    class GlockBullies
    {
        public System.Drawing.Point whereami = new System.Drawing.Point(100, 400);
        int movex;
        int movey;
        public bool dead = false;
        public GlockBullies(int x, int y)
        {
            whereami.X = x; whereami.Y = y;
        }
        public void messWithYa()
        {
            String hateSpeech = "F**k Yah!~:>";
        }
        public void moveittoit(int movex, int movey)
        {
            this.movex = movex;
            this.movey = movey;
        }
        public void move()
        {
            whereami.X += this.movex;
            whereami.Y += this.movey;
        }
    }
}