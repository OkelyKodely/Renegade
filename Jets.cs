using System;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApplication4
{
    class Jets
    {
        private Graphics g;

        private Jet[] jets = new Jet[16];

        private Image jetImage = null;

        private Scroller scroller = null;

        public Jets(Graphics g, Image jetImage, Scroller scroller)
        {
            this.scroller = scroller;
            this.jetImage = jetImage;
            this.g = g;
            Random rnd = new Random();
            for (int j = 0; j < jets.Length; j++)
            {
                int v = rnd.Next(45) * 10 + 1;
                int w = rnd.Next(100) * 10 + 1;
                jets[j] = new Jet();
                jets[j].x = v;
                jets[j].y = w;
            }
        }

        public void moveEm(System.Collections.Generic.List<Antagonist> ant, Soldier soldier)
        {
            scroller.playFile("jets.wav");
            new Thread(() =>
            {
                while (true)
                {
                    bool brek = false;
                    for (int i = 0; i < jets.Length; i++)
                    {
                        jets[i].moveRight();
                        try
                        {
                            g.DrawImage(jetImage, jets[i].x, jets[i].y, 50, 50);
                        }
                        catch (Exception e)
                        {
                        }
                        if (jets[i].x >= 1390)
                        {
                            brek = true;
                            break;
                        }
                        for (int j = 0; j < ant.Count; j++)
                        {
                            if(ant[j].Four_X <= jets[i].x && ant[j].One_X >= jets[i].x &&
                                ant[j].Four_Y <= jets[i].y && ant[j].Two_Y >= jets[i].y)
                            {
                                bool isHeDead = false;
                                for (int k = 0; k < 3; k++)
                                {
                                    isHeDead = ant[j].experiencePain();
                                }
                                if (isHeDead)
                                {
                                    soldier.life += 610;
                                }
                            }
                        }
                    }
                    if (brek)
                    {
                        break;
                    }
                }
            }).Start();
        }
    }
    class Jet
    {
        public int x, y;
        public void moveRight()
        {
            x += 200;
        }
    }
}
