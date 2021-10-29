using Godot;
using System;
using static Godot.GD;

public class Dyna : KinematicBody2D
{

    [Export] private int speed = 100;
    private Vector2 velocity = new Vector2();

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);
    }

    private void GetInput()
    {
        velocity = new Vector2();

        if (Input.IsActionPressed("right"))
        {
            velocity.x += 1;
        }
        else if (Input.IsActionPressed("left"))
        {
            velocity.x -= 1;
        }
        else if (Input.IsActionPressed("up"))
        {
            velocity.y -= 1;
        }
        else if (Input.IsActionPressed("down"))
        {
            velocity.y += 1;
        }

        velocity = velocity.Normalized() * speed;
    }

}
