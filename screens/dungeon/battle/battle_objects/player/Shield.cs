using Godot;
using System;

public partial class Shield : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 250;

    [Export]
    public int SpecialCooldownSeconds { get; set; } = 2;

    [Export]
    public int UltimateCooldownSeconds { get; set; } = 60;

    // A unique ability that can be activated by button press
    public virtual void Special()
    {
        
    }

    // A powerful ability that can be activated by button press
    public virtual void Ultimate()
    {
        
    }
}
