using Godot;
using System;
using static Godot.GD;

public class Dyna : KinematicBody2D
{

    [Export] private int _speed = 200;
    private Vector2 _velocity = new Vector2();
    private AnimatedSprite _sprite;

    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        _velocity = MoveAndSlide(_velocity);
    }

    private void GetInput()
    {
        _velocity = new Vector2();


        if (Input.IsActionPressed("right"))
        {
            _velocity.x += 1;
            _sprite.Animation = "walk";
            _sprite.FlipH = false;

        }
        else if (Input.IsActionPressed("left"))
        {
            _velocity.x -= 1;
            _sprite.Animation = "walk";
            _sprite.FlipH = true;
        }
        else if (Input.IsActionPressed("up"))
        {
            _velocity.y -= 1;
            _sprite.Animation = "up";
        }
        else if (Input.IsActionPressed("down"))
        {
            _velocity.y += 1;
            _sprite.Animation = "down";
        }

        if (_velocity.Length() > 0)
        {
            _velocity = _velocity.Normalized() * _speed;
        }
        else
        {
            _sprite.Animation = "idle";

        }

    }

}
