using Godot;
using System;

public partial interface IHittable
{
    public void Hit(int damage, bool critical);
}
