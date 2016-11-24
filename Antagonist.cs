﻿using System;
using System.Drawing;
using System.Windows.Forms;

public class Antagonist
{
    private int life = 500;
    private bool isDead = false;

    public int One_X = 1280;
    public int One_Y = 0;
    public int Two_X = 1280;
    public int Two_Y = 200;
    public int Three_X = 780;
    public int Three_Y = 50;
    public int Four_X = 780;
    public int Four_Y = 200;

    public Image image;
    private Panel pnl = null;

    Graphics g;

    public Antagonist(Panel p)
    {
        try
        {
            wmp = new WMPLib.WindowsMediaPlayer();
        }
        catch (Exception e)
        {
        }
        pnl = p; 
        g = pnl.CreateGraphics();
        image = Image.FromFile(Environment.CurrentDirectory + "\\ant.png");
    }

    WMPLib.WindowsMediaPlayer wmp;

    public bool experiencePain()
    {
        life--;
        if (life < 0)
        {
            try
            {
                wmp.URL = "explosion.wav";
                wmp.controls.play();
            }
            catch (Exception e)
            {
            }
            isDead = true;
        }
        return isDead;
    }
    int isdeadfirsttime = -1;
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
        else
        {
            if (1==10&&isdeadfirsttime == -1)
            {
                Form form = new Form();
                form.Text = "You killed a TaNk~~!";
                form.SetBounds(500, 500, 700, 20);
                form.Show();
                new System.Threading.ManualResetEvent(false).WaitOne(1750);
                form.Close();
                isdeadfirsttime = 0;
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
        One_X -= 5;
        Two_X -= 5;
        Three_X -= 5;
        Four_X -= 5;
    }

    public void MoveRight()
    {
        One_X += 2;
        Two_X += 2;
        Three_X += 2;
        Four_X += 2;
    }

    public void MoveUp()
    {
        One_Y -= 2;
        Two_Y -= 2;
        Three_Y -= 2;
        Four_Y -= 2;
    }

    public void MoveDown()
    {
        One_Y += 2;
        Two_Y += 2;
        Three_Y += 2;
        Four_Y += 2;
    }
}