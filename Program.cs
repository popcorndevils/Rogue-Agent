using System;

using SFML.Graphics;
using SFML.Window;


public class RogueAgent
{
    public static void Main()
    {
        RenderWindow window = new RenderWindow(new VideoMode(200, 200), "TEST");
        CircleShape shape = new CircleShape(100f);
        shape.FillColor = Color.Green;

        window.Closed += OnClose;

        while(window.IsOpen)
        {
            window.Clear();
            window.DispatchEvents();
            window.Draw(shape);
            window.Display();
        }
    }

    static void OnClose(object? sender, EventArgs e)
    {
        var win = sender as RenderWindow;
        if(win != null)
        {
            win.Close();
        }
    }
}