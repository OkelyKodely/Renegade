using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

class Mover
{
    private List<List<Enemy>> es;
    private Image enmy, mylead;
    private Soldier soldier;
    private Panel pnl;
    private Graphics g;
    private Scroller scroller;
    private int put;

    public Mover(List<List<Enemy>> es, Image enmy, int putted, Panel pnl, Soldier soldier, Image mylead, Scroller scroller)
    {
        this.scroller = scroller;
        this.pnl = pnl;
        this.put = putted;
        this.es = es;
        this.enmy = enmy;
        this.soldier = soldier;
        this.mylead = mylead;
        g = this.pnl.CreateGraphics();
    }

    public void moveEnemiesLeft(object sender, EventArgs e)
    {
        Random r = new Random();
        List<Enemy> ens = es[this.put];
        for (int i = 0; i < ens.Count; i++)
        {
            ens[i].moveLeft();
            int v = r.Next(6);
            if (v == 3)
                ens[i].moveUp();
            else if (v == 4)
                ens[i].moveDown();
            g.DrawImage(enmy, ens[i].x, ens[i].y, 31, 31);
            int xr = r.Next(50) * -1 + 30;
            int yr = r.Next(50) - r.Next(50);
            int y = r.Next(10);
            if (y == 0)
            {
                Lead lead = new Lead(scroller, g, ens[i].x, ens[i].y, soldier, mylead);
                lead.ShootLittle();
                lead.HurtLots();
                lead.DrawBig();
                lead.exe(lead.randomizeShiets(lead.Sheut(), xr, yr));
            }
        }
    }
}
