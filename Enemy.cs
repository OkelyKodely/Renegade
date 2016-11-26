using System;

public class Enemy
{
    public int x, y;
    
    public Enemy(int X, int Y)
    {
        x = X;
        y = Y;
    }

    public void moveLeft()
    {
        x -= 10;
    }

    public void moveUp()
    {
        y -= 10;
    }

    public void moveDown()
    {
        y += 10;
    }
}