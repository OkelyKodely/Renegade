using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace WindowsFormsApplication4
{
    class Glock
    {
        Thread t = null;
        public int x, y;
        int countBulleties = -1;
        Panel pee;
        Graphics g;
        Image myBullet, myExplosion;
        System.Collections.Generic.List<GlockBullies> B = null;
        System.Collections.Generic.List<Antagonist> ant = null;
        WMPLib.WindowsMediaPlayer wmp;
        Soldier soldier;
        Scroller scroller;
        List<List<Enemy>> es;
        public Glock(List<List<Enemy>> es, Panel pnl, Image explosion, Scroller scroller, Graphics g, int X, int Y, System.Collections.Generic.List<Antagonist> ant, Soldier soldier, Image image)
        {
            this.es = es;
            this.pee = pnl;
            this.myExplosion = explosion;
            this.scroller = scroller;
            this.soldier = soldier;
            this.ant = ant;
            x = X; y = Y;
            this.g = g;
            myBullet = image;
        }
        public System.Collections.Generic.List<GlockBullies> Sheut()
        {
            countBulleties += 14;
            System.Collections.Generic.List<GlockBullies> bBs = new System.Collections.Generic.List<GlockBullies>();
            for (int i = 0; i < countBulleties; i++)
            {
                scroller.playSound("ak.wav");
                bBs.Add(new GlockBullies(x, y));
            }
            return bBs;
        }
        public System.Collections.Generic.List<GlockBullies> randomizeShiets(System.Collections.Generic.List<GlockBullies> bullies)
        {
            Random rnd = new Random();
            for (int j = 0; j < bullies.Count; j++)
            {
                int xrand = rnd.Next(184);
                int yrand = rnd.Next(19) - rnd.Next(19);
                bullies[j].messWithYa();
                bullies[j].moveittoit(xrand, yrand);
            }
            return bullies;
        }
        public void checkDeadness()
        {
            new Thread(() =>
            {
                try
                {
                    for (int i = 0; i < es.Count; i++)
                    {
                        for (int j = 0; j < es[i].Count; j++)
                        {
                            List<Enemy> e = es[i];
                            for (int m = 0; m < B.Count; m++)
                            {
                                if (e[j].x >= B[m].whereami.X - 10 && e[j].x <= B[m].whereami.X + 10 && e[j].y >= B[m].whereami.Y - 10 && e[j].y <= B[m].whereami.Y + 10)
                                {
                                    /// //MessageBox.Show(e[j].x + ", " + e[j].y);
                                    e.Remove(e[j]);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }).Start();
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
                                    soldier.life += 20000;
                                    int cnt = 0;
                                    int x = ant[l].Four_X + 41;
                                    int y = ant[l].Four_Y + 41;
                                    new Thread(() =>
                                    {
                                        scroller.playSound("explosion.wav");
                                        while(true)
                                        {
                                            cnt += 150;
                                            new System.Threading.ManualResetEvent(false).WaitOne(150);
                                            try
                                            {
                                                this.pee.CreateGraphics().DrawImage(myExplosion, x, y, 100, 100);
                                            }
                                            catch (Exception e)
                                            {
                                            }
                                            if (cnt >= 1500)
                                            {
                                                break;
                                            }
                                        }
                                    }).Start();
                                    ant.Remove(ant[l]);
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
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(moveTheBullets);
            try
            {
                timer1.Start();
            }
            catch (Exception e)
            {
            }
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
                        g.DrawImage(myBullet, B[k].whereami.X, B[k].whereami.Y, 83, 83);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (B[k].whereami.X > 1220 || B[k].timetolive <= 0)
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
        public int timetolive = 5;
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
            timetolive--;
            whereami.X += this.movex;
            whereami.Y += this.movey;
        }
    }
}