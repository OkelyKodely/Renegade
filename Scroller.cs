using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System;

class Scroller
{
    public WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
    public WMPLib.WindowsMediaPlayer wmp2 = new WMPLib.WindowsMediaPlayer();
    public WMPLib.WindowsMediaPlayer wmp3 = new WMPLib.WindowsMediaPlayer();
    private System.Windows.Forms.Timer timer21 = new System.Windows.Forms.Timer();
    private System.Windows.Forms.Timer timer22 = new System.Windows.Forms.Timer();
    private Random rnd = new Random();
    private bool started = true;
    private Soldier soldier;
    private List<List<Enemy>> es = new List<List<Enemy>>();
    private List<Enemy> ens = new List<Enemy>();
    private List<Antagonist> ant;
    private Image skull, heart, thebg, thebg2, bg, bg2, antt, antagonist, antagonist2, antagonist3, antagonist4, antagonist5, soldierimg, mylead, mybullet, myjet, myexplosion, enmy;
    private Panel panel = new Panel();
    private Form form = new Form();
    private Graphics g;
    private int x = 0;
    private int y = 0;
    private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    private System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
    private System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
    private System.Windows.Forms.Timer timer4 = new System.Windows.Forms.Timer();
    private System.Windows.Forms.Timer timer5 = new System.Windows.Forms.Timer();

    public Scroller()
    {
        form.SetBounds(0, 0, 1280, 1024);
        form.Controls.Add(panel);
        panel.SetBounds(0, 0, 1280, 1024);
        panel.BackColor = Color.Black;
        form.WindowState = FormWindowState.Maximized;
        g = panel.CreateGraphics();
        skull = Image.FromFile(Environment.CurrentDirectory + "\\skull.png");
        bg = Image.FromFile(Environment.CurrentDirectory + "\\bg_.png");
        bg2 = Image.FromFile(Environment.CurrentDirectory + "\\bg_.jpg");
        thebg = bg;
        thebg2 = bg2;
        antagonist = Image.FromFile(Environment.CurrentDirectory + "\\ant.png");
        antagonist2 = Image.FromFile(Environment.CurrentDirectory + "\\ant2.png");
        antagonist3 = Image.FromFile(Environment.CurrentDirectory + "\\ant3.png");
        antagonist4 = Image.FromFile(Environment.CurrentDirectory + "\\ant4.png");
        antagonist5 = Image.FromFile(Environment.CurrentDirectory + "\\ant5.png");
        mybullet = Image.FromFile(Environment.CurrentDirectory + "\\bullet.png");
        mylead = Image.FromFile(Environment.CurrentDirectory + "\\bull.png");
        myjet = Image.FromFile(Environment.CurrentDirectory + "\\jet.png");
        myexplosion = Image.FromFile(Environment.CurrentDirectory + "\\explosion.png");
        enmy = Image.FromFile(Environment.CurrentDirectory + "\\enemy.png");
        heart = Image.FromFile(Environment.CurrentDirectory + "\\heart.png");
        soldierimg = Image.FromFile(Environment.CurrentDirectory + "\\soldier.png");
        soldier = new Soldier(panel, soldierimg);
        soldier.SetLocation(10, 330);
        Random rend = new Random();
        ant = new List<Antagonist>();
        for (int i = 0; i < 100; i++)
        {
            int v = rend.Next(5);
            if (v == 0)
                antt = antagonist;
            else if (v == 1)
                antt = antagonist2;
            else if (v == 2)
                antt = antagonist3;
            else if (v == 3)
                antt = antagonist4;
            else if (v == 4)
                antt = antagonist5;
            antagonist = antt;
            ant.Add(new Antagonist(this, g, antagonist));
            v = rend.Next(5);
            if (v == 0)
                antt = antagonist;
            else if (v == 1)
                antt = antagonist2;
            else if (v == 2)
                antt = antagonist3;
            else if (v == 3)
                antt = antagonist4;
            else if (v == 4)
                antt = antagonist5;
            antagonist = antt;
            ant.Add(new Antagonist(this, g, antagonist));
            v = rend.Next(5);
            if (v == 0)
                antt = antagonist;
            else if (v == 1)
                antt = antagonist2;
            else if (v == 2)
                antt = antagonist3;
            else if (v == 3)
                antt = antagonist4;
            else if (v == 4)
                antt = antagonist5;
            antagonist = antt;
            ant.Add(new Antagonist(this, g, antagonist));
            v = rend.Next(5);
            if (v == 0)
                antt = antagonist;
            else if (v == 1)
                antt = antagonist2;
            else if (v == 2)
                antt = antagonist3;
            else if (v == 3)
                antt = antagonist4;
            else if (v == 4)
                antt = antagonist5;
            antagonist = antt;
            ant.Add(new Antagonist(this, g, antagonist));
            v = rend.Next(5);
            if (v == 0)
                antt = antagonist;
            else if (v == 1)
                antt = antagonist2;
            else if (v == 2)
                antt = antagonist3;
            else if (v == 3)
                antt = antagonist4;
            else if (v == 4)
                antt = antagonist5;
            antagonist = antt;
            ant.Add(new Antagonist(this, g, antagonist));
            v = (rend.Next(10) + 1) * 100 + 200; 
            ant[0 + i * 5].SetLocation(800+i*1280, v);
            v = (rend.Next(10) + 1) * 100 + 200; 
            ant[1 + i * 5].SetLocation(630 + i * 1280, v);
            v = (rend.Next(10) + 1) * 100 + 200; 
            ant[2 + i * 5].SetLocation(330 + i * 1280, v);
            v = (rend.Next(10) + 1) * 100 + 200;
            ant[3 + i * 5].SetLocation(430 + i * 1280, v);
            v = (rend.Next(10) + 1) * 100 + 200;
            ant[4 + i * 5].SetLocation(530 + i * 1280, v);
        }
    }

    public void playSound(String filePath)
    {
        try
        {
            wmp.URL = filePath;
            wmp.controls.play();
        }
        catch (Exception e)
        {
        }
    }

    public void playFile(String filePath)
    {
        try
        {
            wmp2.URL = filePath;
            wmp2.controls.play();
        }
        catch (Exception e)
        {
        }
    }

    public void playMusic(String filePath)
    {
        try
        {
            wmp3.URL = filePath;
            wmp3.controls.play();
        }
        catch (Exception e)
        {
        }
    }

    public void Draw()
    {
        soldier.Draw();

        if (started)
        {
            DrawLife();
            started = false;
        }

        try
        {
            g.DrawImage(bg, x, y+200, panel.Width, panel.Height-200);
            g.DrawImage(bg, x+1280, y+200, panel.Width, panel.Height-200);
        }
        catch (Exception xx)
        {
        }
        if (x + 1280 <= 0)
        {
            x = 0;
        }
    }

    public void Play()
    {
        timer1.Interval = 1;
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Start();

        timer2.Interval = 1;
        timer2.Tick += new EventHandler(timer2_Tick);
        timer2.Start();

        timer3.Interval = 1000;
        timer3.Tick += new EventHandler(timer3_Tick);
        timer3.Start();

        timer4.Interval = 1 * 60 * 1000;
        timer4.Tick += new EventHandler(timer4_Tick);
        timer4.Start();

        timer4_Tick(null, null);

        timer5.Interval = 3 * 60 * 1000;
        timer5.Tick += new EventHandler(timer5_Tick);
        timer5.Start();

        this.form.KeyDown += new KeyEventHandler(Events);
    }

    public void timer5_Tick(object sender, EventArgs e)
    {
        timer1.Stop();
        timer2.Stop();
        timer3.Stop();
        timer4.Stop();

        timer1.Dispose();
        timer2.Dispose();
        timer3.Dispose();
        timer4.Dispose();

        timer1 = new System.Windows.Forms.Timer();
        timer2 = new System.Windows.Forms.Timer();
        timer3 = new System.Windows.Forms.Timer();
        timer4 = new System.Windows.Forms.Timer();

        timer1.Interval = 1;
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Start();

        timer2.Interval = 1;
        timer2.Tick += new EventHandler(timer2_Tick);
        timer2.Start();

        timer3.Interval = 1 * 1000;
        timer3.Tick += new EventHandler(timer3_Tick);
        timer3.Start();

        timer4.Interval = 1 * 60 * 1000;
        timer4.Tick += new EventHandler(timer4_Tick);
        timer4.Start();
    }

    public void timer4_Tick(object sender, EventArgs e)
    {
        try
        {
            playMusic("war.mp3");
        } catch(Exception ex)
        {
        }
        GC.Collect();
    }

    public void DrawLife()
    {
        if (ant.Count <= 0)
        {
            MessageBox.Show("You won!");
            Application.Exit();
        }
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 1280, 200));
        int remx = -20;
        int x = 0;
        for (int i = 0; i < soldier.life / 1000; i++)
        {
            if (i % 100 == 1)
            {
                remx += 20;
                x = 0;
            }
            try
            {
                g.DrawImage(heart, 90 + x * 13, remx, 13, 20);
            }
            catch (Exception ex)
            {
            }
            x++;
        }
        try
        {
            g.DrawString("Life: ", new Font("Arial", 32), new SolidBrush(Color.White), 0, 0);
        }
        catch (Exception ex)
        {
        }
        remx = 60;
        x = 0;
        for (int i = 0; i < ant.Count; i++)
        {
            if (i % 100 == 1 && i != 1)
            {
                remx += 20;
                x = 0;
            }
            try
            {
                g.DrawImage(heart, 240 + x * 10, remx, 10, 10);
            }
            catch (Exception ex)
            {
            }
            x++;
        }
        try
        {
            g.DrawString("Enemies Left: ", new Font("Arial", 26), new SolidBrush(Color.Red), 0, 68);
        }
        catch (Exception ex)
        {
        }
    }

    public void StartEnemies()
    {
        int puttedIndexOfEnemies = Enemies();
        timer21.Interval = 30;
        timer21.Tick += new EventHandler((new Mover(es, enmy, puttedIndexOfEnemies, panel, soldier, mylead, this)).moveEnemiesLeft);
        timer21.Start();

        timer22.Interval = 30 * 1000;
        timer22.Tick += new EventHandler(StopEnemies);
        timer22.Start();
    }

    private void StopEnemies(object sender, EventArgs e)
    {
        timer21.Stop();
        timer21.Dispose();
    }

    private int Enemies()
    {
        Random rand = new Random();
        Random rd = new Random();
        int v = rand.Next(10) + 5;
        ens.Clear();
        for (int i = 0; i < v; i++)
        {
            int w = rd.Next(700) + 400;
            int x = rd.Next(100) * 10;
            Enemy en = new Enemy(w, x);
            ens.Add(en);
        }
        es.Add(ens);
        return es.Count - 1;
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
        else if (e.KeyCode == Keys.J)
        {
            new System.Threading.Thread(() =>
            {
                Jets jets = new Jets(g, myjet, this);
                jets.moveEm(ant, soldier);
            }).Start();
        }
        else if (e.KeyCode == Keys.S)
        {
            Glock glock = new Glock(es, panel, myexplosion, this, g, soldier.Four_X, soldier.Four_Y + 50, ant, soldier, mybullet);
            System.Collections.Generic.List<GlockBullies> bulless = glock.Sheut();
            glock.exe(glock.randomizeShiets(bulless));
        }
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        x--;
        Draw();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        try
        {
            new Thread(() =>
            {
                try
                {
                    for (int i = 0; i < es.Count; i++)
                    {
                        for (int j = 0; j < es[i].Count; j++)
                        {
                            List<Enemy> en = es[i];
                            if (en[j].x <= soldier.One_X && en[j].x >= soldier.Four_X &&
                                en[j].y >= soldier.One_Y && en[j].y <= soldier.Two_Y)
                            {
                                en.Remove(en[j]);
                                soldier.life -= 900;
                            }
                            else if (en[j].x < -100)
                            {
                                en.Remove(en[j]);
                                soldier.life -= 3000;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }).Start();

            form.Text = "Life: " + soldier.Life() + " Enemies Left: " + ant.Count;

            for (int index = 0; index < ant.Count; index++)
            {
                if (ant[index].Four_X < 1400 && ant[index].Four_X > 1300)
                    ant[index].SetLocation(600, ant[index].Four_Y);

                if (ant[index].Four_X < -30)
                {
                    soldier.life -= 100;
                    ant.Remove(ant[index]);
                }
                Random rnd = new Random();
                int vv = rnd.Next(25);
                if (vv == 23)
                {
                    if (ant[index].Four_X > 1280)
                    {
                    }
                    else
                    {
                        int xr = rnd.Next(50) * -1 + 30;
                        int yr = rnd.Next(50) - rnd.Next(50);
                        Lead lead = new Lead(this, g, ant[index].Four_X, ant[index].Four_Y, soldier, mylead);
                        lead.exe(lead.randomizeShiets(lead.Sheut(), xr, yr));
                    }
                }
                if (soldier.One_X - 74 >= ant[index].Four_X && soldier.One_X - 74 <= ant[index].One_X &&
                    soldier.One_Y + 74 >= ant[index].One_Y && soldier.One_Y + 74 <= ant[index].Two_Y)
                {
                    soldier.life -= 100;
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
                int v = rnd.Next(2) + 1;
                int w = rnd.Next(2) + 1;
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
        catch (Exception ex)
        {
        }
    }

    private void timer3_Tick(object sender, EventArgs e)
    {
        DrawLife();
    }

    public static void Main(String[] args)
    {
        Form splashForm = new Form();

        splashForm.SetBounds(0, 0, 400, 400);

        splashForm.ControlBox = false;
        splashForm.MaximizeBox = false;
        splashForm.MinimizeBox = false;
        splashForm.ShowIcon = false;

        splashForm.StartPosition = FormStartPosition.CenterScreen;
        splashForm.FormBorderStyle = FormBorderStyle.None;

        splashForm.MinimumSize = new Size(400, 400);
        splashForm.MaximumSize = new Size(400, 400);

        Panel splashPanel = new Panel();
        splashPanel.SetBounds(0, 0, 400, 400);
        splashPanel.BackColor = Color.Transparent;

        Size size = new Size(400, 400);
        splashPanel.BackgroundImage = Image.FromFile("splash.jpg");

        Bitmap bmp = new Bitmap(splashPanel.BackgroundImage, size);
        splashPanel.BackgroundImage = bmp;

        splashForm.Controls.Add(splashPanel);

        splashForm.Show();

        new System.Threading.ManualResetEvent(false).WaitOne(1250);

        splashForm.Close();
        
        
        Scroller s = new Scroller();
        s.form.Show();
        s.Play();
        Application.Run(s.form);
    }
}