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
        public Lead(Panel p, int X, int Y, Soldier soldier)
        {
            try
            {
                wmp = new WMPLib.WindowsMediaPlayer();
                wmp.URL = "ak.wav";
            }
            catch (Exception e)
            {
            }
            this.soldier = soldier;
            x = X; y = Y;
            pee = p; g = pee.CreateGraphics();
            try
            {
                myBullet = Image.FromFile(Environment.CurrentDirectory + "\\bull.png");
            }
            catch (Exception e)
            {
            }
        }
        public System.Collections.Generic.List<LeadBullies> Sheut()
        {
            System.Collections.Generic.List<LeadBullies> bBs = new System.Collections.Generic.List<LeadBullies>();
            if (x < 1000)
            {
                countBulleties += 5;
                for (int i = 0; i < countBulleties; i++)
                {
                    try
                    {
                        wmp.controls.play();
                    }
                    catch (Exception e)
                    {
                    }
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
                int xrand = -1*rnd.Next(5) + xr;
                int yrand = rnd.Next(3) - rnd.Next(3) + yr;
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
                        g.DrawImage(myBullet, B[k].whereami.X, B[k].whereami.Y, 16, 16);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (B[k].whereami.X < 0)
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
            whereami.X += this.movex;
            whereami.Y += this.movey;
        }
    }
}