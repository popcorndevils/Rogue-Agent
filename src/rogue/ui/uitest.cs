using SFML.Graphics;
using Rogui;
using Rogui.Themes;

namespace RogueAgent.UI
{
    public class UITest : VBox
    {
        private Button btn;

        public UITest()
        {    
            this.MarginSeparator = 5;

            var _theme_normal = new ThemeButton() {
                FillColor = new Color(255, 0, 0),
                Border = 10,
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

            this.btn = new Button("CLICK 1") {
                ThemeNormal = _theme_normal,
                ThemeHover = _theme_hover,
                ThemePressed = _theme_pressed,
            };

            var btn2 = new Button("CLICK 2") {
                ThemeNormal = _theme_normal,
                ThemeHover = _theme_hover,
                ThemePressed = _theme_pressed,
            };

            this.btn.OnClick += this.HandleClick;
            btn2.OnClick += this.HandleClick;

            this.Add(this.btn, btn2);
        }

        public void HandleClick(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} CLICKED");
            this.btn.DisplayedString = "CHANGED Right hererere";
        }
    }
}