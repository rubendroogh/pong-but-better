using Godot;
using System.Threading.Tasks;

public static class NodeExtensions
{
    public static async Task Delay(this Node node, int milliseconds)
    {
        // Convert milliseconds to seconds for Godot timer
        float seconds = milliseconds / 1000f;

        // Create a one-shot timer and wait for it
        await node.ToSignal(node.GetTree().CreateTimer(seconds), "timeout");
    }
}
