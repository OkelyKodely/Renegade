using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using WindowsFormsApplication4;

public class Scroller
{
    List<Antagonist> ant;
    private Image bg = null;
    private Panel panel = new Panel();
    private Form form = new Form();
    Graphics g;
    private int x = 0, y = 0;
    Soldier soldier;
    public int X = 10;
    public int Y = 330;
    public int life = 100;

    public Scroller()
    {
        form.SetBounds(0, 0, 1280, 1024);
        panel.SetBounds(0, 0, 1280, 1024);
        soldier = new Soldier(panel);
        soldier.SetLocation(10, 330);
        g = panel.CreateGraphics();
        form.Controls.Add(panel);
        bg = Image.FromFile(Environment.CurrentDirectory + "\\bg_.png");
        ant = new List<Antagonist>();
        for (int i = 0; i <= 10; i++)
        {
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant.Add(new Antagonist(panel));
            ant[0+i*20].SetLocation(800+i*1280, 20);
            ant[1 + i * 20].SetLocation(630 + i * 1280, 192);
            ant[2 + i * 20].SetLocation(330 + i * 1280, 300);
            ant[3 + i * 20].SetLocation(1130 + i * 1280, 502);
            ant[4 + i * 20].SetLocation(1800 + i * 1280, 20);
            ant[5 + i * 20].SetLocation(1630 + i * 1280, 192);
            ant[6 + i * 20].SetLocation(1330 + i * 1280, 300);
            ant[7 + i * 20].SetLocation(1730 + i * 1280, 502);
            ant[8 + i * 20].SetLocation(2800 + i * 1280, 20);
            ant[9 + i * 20].SetLocation(2630 + i * 1280, 192);
            ant[10 + i * 20].SetLocation(2330 + i * 1280, 300);
            ant[11 + i * 20].SetLocation(2730 + i * 1280, 502);
            ant[12 + i * 20].SetLocation(3800 + i * 1280, 20);
            ant[13 + i * 20].SetLocation(3630 + i * 1280, 192);
            ant[14 + i * 20].SetLocation(3330 + i * 1280, 300);
            ant[15 + i * 20].SetLocation(3730 + i * 1280, 502);
            ant[16 + i * 20].SetLocation(4800 + i * 1280, 20);
            ant[17 + i * 20].SetLocation(4630 + i * 1280, 192);
            ant[18 + i * 20].SetLocation(4330 + i * 1280, 300);
            ant[19 + i * 20].SetLocation(4930 + i * 1280, 502);
        }
    }

    public void Draw()
    {
        soldier.Draw();

        try
        {
            g.DrawImage(bg, x, y, panel.Width, panel.Height);
            g.DrawImage(bg, x + 1280, y, panel.Width, panel.Height);
        }
        catch (Exception xx)
        {
        }
        if (x + 1280 < 0)
            x = 0;
    }

    public void Play()
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        timer1.Interval = 70;
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Start();

        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        timer2.Interval = 1;
        timer2.Tick += new EventHandler(timer2_Tick);
        timer2.Start();

        this.form.KeyDown += new KeyEventHandler(Events);
    }

    public void Events(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left)
        {
            soldier.MoveLeft();
        }
        else if (e.KeyCode == Keys.Right)
        {
            soldier.MoveRight();
        }
        else if (e.KeyCode == Keys.Up)
        {
            soldier.MoveUp();
        }
        else if (e.KeyCode == Keys.Down)
        {
            soldier.MoveDown();
        }
        else if (e.KeyCode == Keys.S)
        {
            Glock glock = new Glock(panel, soldier.Four_X, soldier.Four_Y+50, ant, soldier);
            System.Collections.Generic.List<GlockBullies> bulless = glock.Sheut();
            glock.exe(glock.randomizeShiets(bulless));
        }
    }

    private Random rnd = new Random();

    private void timer1_Tick(object sender, EventArgs e)
    {
        x -= 20;
        Draw();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        for (int index = 0; index < ant.Count; index++)
        {
            int vv = rnd.Next(500);
            if (vv == 249)
            {
                int xr = rnd.Next(10) * -1;
                int yr = rnd.Next(10) - rnd.Next(10);
                Lead lead = new Lead(panel, ant[index].Four_X, ant[index].Four_Y, soldier);
                lead.exe(lead.randomizeShiets(lead.Sheut(), xr, yr));
                form.Text = "Life: " + soldier.Life();
            }
            if (soldier.One_X - 74 >= ant[index].Four_X && soldier.One_X - 74 <= ant[index].One_X &&
                soldier.One_Y + 74 >= ant[index].One_Y && soldier.One_Y + 74 <= ant[index].Two_Y)
            {
                soldier.life -= 1;
            }
            if (ant[index].Four_X < 0)
            {
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
                soldier.experiencePain();
            }
            ant[index].Draw();
            int v = rnd.Next(4) + 1;
            int w = rnd.Next(4) + 1;
            if (v == w)
            {
                ant[index].MoveLeft();
                ant[index].MoveLeft();
                ant[index].MoveLeft();
                ant[index].MoveLeft();
                ant[index].MoveLeft();
            }
            v = rnd.Next(8) + 1;
            w = rnd.Next(8) + 1;
            if (v == w)
            {
                ant[index].MoveRight();
                ant[index].MoveRight();
                ant[index].MoveRight();
                ant[index].MoveRight();
            }
            v = rnd.Next(20) + 1;
            w = rnd.Next(20) + 1;
            if (v == w)
            {
                ant[index].MoveUp();
            }
            v = rnd.Next(20) + 1;
            w = rnd.Next(20) + 1;
            if (v == w)
            {
                ant[index].MoveDown();
            }
        }
    }

    public static void Main(String[] args)
    {
        Scroller s = new Scroller();
        s.form.Show();
        s.Play();
        Application.Run(s.form);
    }
}