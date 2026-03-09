using Godot;
using System;

public partial class StartButton : Button
{
    public override void _Ready()
    {
        this.Pressed += StartButton_Pressed;
    }

    private void StartButton_Pressed()
    {
        GetTree().ChangeSceneToFile("res://screens/battle/battle_screen.tscn");
    }
}
