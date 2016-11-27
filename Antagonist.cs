using System.Windows.Forms;
using System.Drawing;
using System;

class Antagonist
{
    public int One_X = 1280;
    public int One_Y = 0;
    public int Two_X = 1280;
    public int Two_Y = 200;
    public int Three_X = 780;
    public int Three_Y = 50;
    public int Four_X = 780;
    public int Four_Y = 200;
    private Scroller scroller;
    public Image image;
    private Graphics g;
    private bool isDead;
    private int life = 500;

    public Antagonist(Scroller scroller, Graphics g, Image image)
    {
        this.image = image;
        this.scroller = scroller;
        this.g = g;
    }

    public bool experiencePain()
    {
        life--;
        if (life <= 0)
        {
            isDead = true;
            scroller.StartEnemies();
        }
        return isDead;
    }

    public void Draw()
    {
        if (!isDead)
        {
            try
            {
                g.DrawImage(image, Four_X, Four_Y, 250, 120);
            }
            catch (Exception e)
            {
            }
        }
    }

    public void SetLocation(int x, int y)
    {
        One_X = x + 250;
        Two_X = x + 250;
        Three_X = x;
        Four_X = x;
        One_Y = y;
        Two_Y = y + 120;
        Three_Y = y + 120;
        Four_Y = y;
    }

    public void MoveLeft()
    {
        One_X -= 6;
        Two_X -= 6;
        Three_X -= 6;
        Four_X -= 6;
    }

    public void MoveRight()
    {
        One_X += 3;
        Two_X += 3;
        Three_X += 3;
        Four_X += 3;
    }

    public void MoveUp()
    {
        One_Y -= 4;
        Two_Y -= 4;
        Three_Y -= 4;
        Four_Y -= 4;
    }

    public void MoveDown()
    {
        One_Y += 5;
        Two_Y += 5;
        Three_Y += 5;
        Four_Y += 5;
    }
}