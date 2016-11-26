using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System;

namespace WindowsFormsApplication4
{
    class Lead
    {
        Thread t = null;
        public int x, y;
        int countBulleties = -1;
        Panel pee;
        Graphics g;
        Image myBullet;
        System.Collections.Generic.List<LeadBullies> B = null;
        Soldier soldier = null;
        WMPLib.WindowsMediaPlayer wmp;
        Scroller scroller;
        public Lead(Scroller scroller, Graphics g, int X, int Y, Soldier soldier, Image image)
        {
            this.scroller = scroller;
            this.soldier = soldier;
            x = X; y = Y;
            this.g = g;
            myBullet = image;
        }
        public System.Collections.Generic.List<LeadBullies> Sheut()
        {
            System.Collections.Generic.List<LeadBullies> bBs = new System.Collections.Generic.List<LeadBullies>();
            if (x < 1280 && x > 0)
            {
                countBulleties += 17;
                for (int i = 0; i < countBulleties; i++)
                {
                    scroller.playSound("ak.wav");
                    bBs.Add(new LeadBullies(x, y));
                }
            }
            return bBs;
        }
        public System.Collections.Generic.List<LeadBullies> randomizeShiets(System.Collections.Generic.List<LeadBullies> bullies, int xr, int yr)
        {
            Random rnd = new Random();
            for (int j = 0; j < bullies.Count; j++)
            {
                int xrand = -1*rnd.Next(430) + xr;
                int yrand = rnd.Next(173) - rnd.Next(173) + yr;
                bullies[j].messWithYa();
                bullies[j].moveittoit(xrand, yrand);
            }
            return bullies;
        }
        public void checkDeadness()
        {
            for (int m = 0; m < B.Count; m++)
            {
                if(B[m].whereami.X < 1280 && B[m].whereami.X > 0)
                if (soldier.One_X >= B[m].whereami.X && soldier.Four_X <= B[m].whereami.X)
                {
                    if (soldier.One_Y <= B[m].whereami.Y && soldier.Two_Y >= B[m].whereami.Y)
                    {
                        soldier.experiencePain(); 
                        Boolean isHeDead = soldier.experiencePain();
                        B[m].dead = true;
                        if (isHeDead)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
        }
        public void exe(System.Collections.Generic.List<LeadBullies> bullies)
        {
            this.B = bullies;
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1;
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
                        g.DrawImage(myBullet, B[k].whereami.X, B[k].whereami.Y, 67, 67);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (B[k].whereami.X < 0 || B[k].timetolive <= 0)
                {
                    B.Remove(B[k]);
                }
            }
            checkDeadness();
        }
    }
    class LeadBullies
    {
        public System.Drawing.Point whereami = new System.Drawing.Point(100, 400);
        int movex;
        int movey;
        public int timetolive = 5;
        public bool dead = false;
        public LeadBullies(int x, int y)
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
            timetolive-=2;
            whereami.X += this.movex;
            whereami.Y += this.movey;
        }
    }
}