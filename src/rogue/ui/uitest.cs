using SFML.Graphics;
using Rogui;

namespace RogueAgent.UI
{
    public class UITest : VBox
    {
        public UITest()
        {    
            this.MarginSeparator = 10;

            var btn1 = new Button("CLICK 1") {
                ColorNormal = new Color(255, 0, 0),
                ColorHover = new Color(0, 255, 0),
                ColorPressed = new Color(0, 0, 255),
                BorderWidth = 20,
                Margin = 20,
            };

            var btn2 = new Button("CLICK 2") {
                ColorNormal = new Color(255, 0, 0),
                ColorHover = new Color(0, 255, 0),
                ColorPressed = new Color(0, 0, 255),
                BorderWidth = 5,
                Margin = 5,
            };

            btn1.OnClick += this.HandleClick;
            btn2.OnClick += this.HandleClick;

            this.Add(btn1, btn2);
            // this.Add(btn1);
        }

        public void HandleClick(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} CLICKED");
        }
    }
}