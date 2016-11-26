using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

public class Mover
{
    private List<List<Enemy>> es;
    private Image enmy;
    private int put;
    private Panel pnl;
    Graphics g;
    public Mover(List<List<Enemy>> es, Image enmy, int putted, Panel pnl)
    {
        this.pnl = pnl;
        g = this.pnl.CreateGraphics();
        this.put = putted;
        this.es = es;
        this.enmy = enmy;
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
            g.DrawImage(enmy, ens[i].x, ens[i].y, 30, 30);
        }
    }
}
