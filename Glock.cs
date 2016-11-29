using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System;

class Glock
{
    public int x, y;
    private System.Collections.Generic.List<GlockBullies> B;
    private System.Collections.Generic.List<Antagonist> ant;
    private System.Collections.Generic.List<List<Enemy>> es;
    private Scroller scroller;
    private Soldier soldier;
    private Panel pee;
    private Image myBullet, myExplosion;
    private Graphics pi;
    private Graphics g;
    private int countBulleties = -1;
    private Random r = new Random();
    
    public Glock(List<List<Enemy>> es, Panel pnl, Image explosion, Scroller scroller, Graphics g, int X, int Y, System.Collections.Generic.List<Antagonist> ant, Soldier soldier, Image image)
    {
        this.pee = pnl;
        this.pi = pee.CreateGraphics();
        this.myExplosion = explosion;
        this.scroller = scroller;
        this.soldier = soldier;
        this.myBullet = image;
        this.ant = ant;
        this.es = es;
        this.g = g;
        x = X;
        y = Y;
    }

    public System.Collections.Generic.List<GlockBullies> Sheut()
    {
        countBulleties+=4;
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
            int xrand = rnd.Next(484);
            int yrand = rnd.Next(3) - rnd.Next(3);
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
                                new Thread(() =>
                                {
                                    scroller.playSound("explosion.wav");
                                    int cnt = 0;
                                    while (true)
                                    {
                                        cnt += 150;
                                        new System.Threading.ManualResetEvent(false).WaitOne(150);
                                        try
                                        {
                                            this.pi.DrawImage(myExplosion, e[j].x, e[j].y, 200, 200);
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                        if (cnt >= 1500)
                                        {
                                            break;
                                        }
                                    }
                                }).Start();
                                e.Remove(e[j]);
                                int ii = 0;
                                while (ii < 10)
                                {
                                    int v = r.Next(ant.Count);
                                    if (v >= 0 && v < ant.Count)
                                    {
                                        if (ant[v] != null)
                                        {
                                            ant.Remove(ant[v]);
                                        }
                                    }
                                    ii = ii + 1;
                                }
                                soldier.life += 1000;
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
                if (ant[l].One_X + 100 >= B[m].whereami.X && ant[l].Four_X - 100 <= B[m].whereami.X)
                {
                    if (ant[l].One_Y - 100 <= B[m].whereami.Y && ant[l].Two_Y + 100 >= B[m].whereami.Y)
                    {
                        if (ant[l].One_X < 1280 && ant[l].One_X > 0)
                        {
                            Boolean isTankDead = ant[l].experiencePain();
                            try
                            {
                                scroller.playSound("tink.mp3");
                            }
                            catch (Exception ex)
                            {
                            }
                            B[m].dead = true;
                            if (isTankDead)
                            {
                                soldier.life += 12000;
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
                                            this.pi.DrawImage(myExplosion, x, y, 70, 70);
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

    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
    
    public void exe(System.Collections.Generic.List<GlockBullies> bullies)
    {
        this.B = bullies;
        timer1.Interval = 1;
        timer1.Tick += new EventHandler(moveTheBullets);
        try
        {
            timer1.Start();
        }
        catch (Exception e)
        {
        }
        timer2.Interval = 3 * 1000;
        timer2.Tick += new EventHandler(StopMovingBullets);
        try
        {
            timer2.Start();
        }
        catch (Exception e)
        {
        }
    }

    private void StopMovingBullets(object sender, EventArgs e)
    {
        timer1.Stop();
        timer1.Dispose();
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
            if (B[k].whereami.X > 1320 || B[k].timetolive <= 0)
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
    public int timetolive = 10;
    public bool dead;
    private int movex;
    private int movey;

    public GlockBullies(int x, int y)
    {
        whereami.X = x;
        whereami.Y = y - 20;
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