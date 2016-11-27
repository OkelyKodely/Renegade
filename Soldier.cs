using System.Windows.Forms;
using System.Drawing;
using System;

class Soldier
{
    public Image image;
    public int life = 150000;
    public int One_X = 1280;
    public int One_Y = 0;
    public int Two_X = 1280;
    public int Two_Y = 200;
    public int Three_X = 780;
    public int Three_Y = 50;
    public int Four_X = 780;
    public int Four_Y = 200;
    private Panel pnl;
    private Graphics g;
    private bool isDead;

    public Soldier(Panel p, Image image)
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
            Application.Exit();
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
                g = pnl.CreateGraphics();
                g.DrawImage(image, Four_X, Four_Y, 98, 98);
            }
        }
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