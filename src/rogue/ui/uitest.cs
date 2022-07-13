using SFML.Graphics;
using SFML.System;
using Rogui;
using Rogui.Shapes;
using Rogui.Themes;

namespace RogueAgent.UI
{
    public class UITest : Aspect
    {
        private VBox ButtonList = new VBox();
        private AnimLine Line;
        private AnimButton Panel;

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
                Position = new Vector2f(500, 500),
            };

            this.Panel = new AnimButton("ANIMATED") {
                Theme = _theme_btn,
                Position = new Vector2f(100, 200),
            };

            btn1.OnClick += this.HandleClick;
            btn2.OnClick += this.HandleClick;
            btn3.OnClick += this.HandleLineToggle;

            this.Line = new Rogui.Shapes.AnimLine(250, 50, 1250, 1000, 10);
            this.Line.Opened += this.HandleOpen;
            this.Line.Closed += this.HandleClose;
            this.Panel.Opened += this.HandleOpen;
            this.Panel.Closed += this.HandleClose;

            this.ButtonList.Add(btn1, btn2);
            this.Add(this.ButtonList, btn3, this.Line, this.Panel);
        }

        public void HandleClick(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} CLICKED");
        }

        public void HandleOpen(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} OPENED");
        }

        public void HandleClose(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} CLOSED");
        }

        public void HandleLineToggle(object? sender, EventArgs e)
        {
            if(!this.Line.IsOpening && !this.Line.IsOpen)
            {
                this.Line.Open();
            }
            else
            {
                this.Line.Close();
            }
            if(!this.Panel.IsOpening && !this.Panel.IsOpen)
            {
                this.Panel.Open();
            }
            else
            {
                this.Panel.Close();
            }
        }
    }
}