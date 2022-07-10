using SFML.Graphics;
using SFML.System;
using Rogui;
using Rogui.Themes;
using RogueAgent.UI;
using RogueAgent.System;
using RogueAgent.Services;
using RogueAgent.Entity;

namespace RogueAgent
{
    public class RogueGame
    {
        public static void Main()
        {
            var manager = new Manager();
            var sprite = new Spryte("HELLO", 0, "riblet");
            SvcGameUI.Add(new UITest());            
            
            var _theme_normal = new ThemeButton() {
                FillColor = new Color(255, 0, 0),
                BorderWidth = 10,
                BorderColor = new Color(200, 200, 200),
                Margin = 10,
                Padding = 50,
            };

            var _theme_hover = new ThemeButton() {
                FillColor = new Color(0, 255, 0),
                BorderColor = new Color(150, 150, 150),
            };

            var _theme_pressed = new ThemeButton() {
                FillColor = new Color(0, 0, 255),
                BorderColor = new Color(50, 50, 50),
            };

            var btn = new Button("CLICK 3") {
                ThemeNormal = _theme_normal,
                ThemeHover = _theme_hover,
                ThemePressed = _theme_pressed,
                RelativePosition = new Vector2f(50, 50),
            };

            btn.OnClick += RogueGame.HandleClick;

            SvcGameUI.Add(btn);

            while(manager.Running)
            {
                manager.Run();
            }
        }

        public static void HandleClick(object? sender, EventArgs e)
        {
            Console.WriteLine("HELLO THERE");
        }
    }
}