using System;
using System.Drawing;
using Pamella;

App.Open<Joguin>();

public class Enemy
{
    public State State { get; set; } 
    public float X { get; set; }
    public float Y { get; set; }
    public float Angle { get; set; }

    public void Act()
    {
        this.State.Act();
    }

}

public class Player
{
    public State State { get; set; } 
    public float X { get; set; }
    public float Y { get; set; }
}



public abstract class State
{
    protected Enemy enemy;
    // protected Player player;
    public abstract void Act();

    public State (Enemy enemy)
        => this.enemy = enemy;
}

public class MovingState : State
{
    public MovingState(Enemy enemy) : base(enemy) { }

    public float XTarget { get; set; }
    public float YTarget { get; set; }

    public override void Act()
    {
        var dx = XTarget - enemy.X;
        var dy = XTarget - enemy.Y;

        var mod = MathF.Sqrt(dx * dx + dy * dy);

        if (mod < 5)
            this.enemy.State = new StopState(this.enemy);

        enemy.X += 50 * dx / mod / 40;
        enemy.Y += 50 * dy / mod / 40;
    }
}

public class StopState : State
{
    public StopState(Enemy enemy) : base(enemy) { }

    public float XTarget { get; set; }
    public float YTarget { get; set; }

    public override void Act()
    {
        var dx = XTarget - enemy.X;
        var dy = XTarget - enemy.Y;
    }
}

public class Joguin : View
{
    Enemy enemy1;
    Player player1;

    protected override void OnStart(IGraphics g)
    {
        enemy1 = new Enemy
        {
            X = 400,
            Y = 270,  
        };

        enemy1.State = new MovingState(enemy1)
        {
            XTarget = 600,
            YTarget = 330,
        };

        player1 = new Player();
        player1.X = 900;
        player1.Y = 400;

        g.SubscribeKeyDownEvent(key =>
        {
            if (key == Input.Escape)
                App.Close();
            if (key == Input.Up)
                player1.Y -= 20;
            if (key == Input.Down)
                player1.Y += 20;
            if (key == Input.Right)
                player1.X += 20;
            if (key == Input.Left)
                player1.X -= 20;
            
        });
        AlwaysInvalidateMode();
    }

    protected override void OnFrame(IGraphics g)
    {
        enemy1.Act();
    }


    protected override void OnRender(IGraphics g)
    {
        enemy1.Angle += 0.01f;
        g.Clear(Color.DarkGreen);

        g.FillRectangle(
            enemy1.X - 15, enemy1.Y - 15,
            30, 30, Brushes.Red
        );

        g.FillRectangle(
            player1.X - 15, player1.Y - 15,
            30, 30, Brushes.Blue
        );

        var cos = MathF.Cos(enemy1.Angle);
        var sin = MathF.Sin(enemy1.Angle);
        g.FillPolygon(
            new PointF[] {
                new PointF(enemy1.X, enemy1.Y),
                new PointF(enemy1.X + 250 * cos - 50 * sin, enemy1.Y + 250 * sin + 50 * cos),
                new PointF(enemy1.X + 250 * cos + 50 * sin, enemy1.Y + 250 * sin - 50 * cos)
            }, Brushes.YellowGreen
        ); 
    } 
}