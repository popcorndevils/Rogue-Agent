using SFML.Graphics;
using SFML.System;
using Rogui;
using Rogui.Themes;

namespace RogueAgent.UI
{
    public class UITest : Aspect
    {
        private VBox ButtonList = new VBox();

        public UITest()
        {    
            this.ButtonList.MarginSeparator = 5;

            var _theme_normal = new ThemePanel() {
                FillColor = new Color(255, 0, 0),
                Border = 10,
                BorderColor = new Color(200, 200, 200),
                Margin = 10,
                Padding = 50,
            };

            var _theme_hover = new ThemePanel() {
                FillColor = new Color(0, 255, 0),
                BorderColor = new Color(150, 150, 150),
            };

            var _theme_pressed = new ThemePanel() {
                FillColor = new Color(0, 0, 255),
                BorderColor = new Color(50, 50, 50),
            };

            var _theme_btn = new ThemeButton() {
                Normal =_theme_normal,
                Hover = _theme_hover,
                Pressed = _theme_pressed,
            };

            var btn1 = new Button("CLICK 1") {
                Theme = _theme_btn,
            };

            var btn2 = new Button("CLICK 2") {
                Theme = _theme_btn,
            };

            var btn3 = new Button("CLICK 3") {
                Theme = _theme_btn,
                Position = new Vector2f(0, 50),
            };

            btn1.OnClick += this.HandleClick;
            btn2.OnClick += this.HandleClick;
            btn3.OnClick += this.HandleClick;

            this.ButtonList.Add(btn1, btn2);
            this.Add(this.ButtonList, btn3, new Rogui.Shapes.Line(250, 50, 1250, 1000, 10));
        }

        public void HandleClick(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} CLICKED");
            // this.btn.DisplayedString = "CHANGED Right hererere";
        }
    }
}