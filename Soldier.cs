using System.Windows.Forms;
using System.Drawing;
using System;

public class Soldier
{
    private bool isDead;
    public int life = 150000;
    public int One_X = 1280;
    public int One_Y = 0;
    public int Two_X = 1280;
    public int Two_Y = 200;
    public int Three_X = 780;
    public int Three_Y = 50;
    public int Four_X = 780;
    public int Four_Y = 200;
    [System.Xml.Serialization.XmlIgnore]
    private Panel pnl;
    [System.Xml.Serialization.XmlIgnore]
    private Graphics g;
    [System.Xml.Serialization.XmlIgnore]
    public Image image;
    [System.Xml.Serialization.XmlIgnore]
    private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    [System.Xml.Serialization.XmlIgnore]
    private System.Windows.Forms.Timer timerstop = new System.Windows.Forms.Timer();

    public void Setup(Panel p, Image image)
    {
        this.image = image;
        pnl = p; 
        g = pnl.CreateGraphics();
    }

    public int Life()
    {
        return this.life;
    }

    public bool experiencePain()
    {
        life = life -1;
        if (life < 0)
        {
            isDead = true;
        }
        return isDead;
    }

    public void Draw()
    {
        if (!isDead)
        {
            try
            {
                g.DrawImage(image, Four_X, Four_Y, 98, 98);
            } catch(Exception e)
            {
            }
        }
    }

    public void DrawWon()
    {
        timer1.Interval = 1000;
        timer1.Tick += new EventHandler(DrawWonGo);
        timer1.Start();

        timerstop.Interval = 60 * 1000;
        timerstop.Tick += new EventHandler(DrawWonStop);
        timerstop.Start();
    }

    private void DrawWonGo(object sender, EventArgs e)
    {
        try
        {
            g.DrawImage(image, 150, 210, 980, 780);
        }
        catch (Exception ex)
        {
        }
    }

    private void DrawWonStop(object sender, EventArgs e)
    {
        timerstop.Stop();
        timerstop.Dispose();
        timer1.Stop();
        timer1.Dispose();
    }

    public void SetLocation(int x, int y)
    {
        One_X = x + 98;
        Two_X = x + 98;
        Three_X = x;
        Four_X = x;
        One_Y = y;
        Two_Y = y + 98;
        Three_Y = y + 98;
        Four_Y = y;
    }

    public void MoveLeft()
    {
        One_X -= 32;
        Two_X -= 32;
        Three_X -= 32;
        Four_X -= 32;
    }

    public void MoveRight()
    {
        One_X += 32;
        Two_X += 32;
        Three_X += 32;
        Four_X += 32;
    }

    public void MoveUp()
    {
        One_Y -= 32;
        Two_Y -= 32;
        Three_Y -= 32;
        Four_Y -= 32;
    }

    public void MoveDown()
    {
        One_Y += 32;
        Two_Y += 32;
        Three_Y += 32;
        Four_Y += 32;
    }
}