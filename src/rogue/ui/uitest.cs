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
        private AnimButton Button;
        private AnimPanel Panel;

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

            var btn1 = new Button("TEST 1") {
                Theme = _theme_btn,
            };

            var btn2 = new Button("TEST 2") {
                Theme = _theme_btn,
            };

            this.Button = new AnimButton("ANIMATED BUTTON") {
                Theme = _theme_btn,
                Position = new Vector2f(300, 200),
            };

            this.Panel = new AnimPanel() {
                Theme = _theme_normal,
                Position = new Vector2f(700, 500),
            };

            btn1.OnClick += this.HandleClick;
            btn2.OnClick += this.HandleLineToggle;

            this.Panel.Add(new Label("ANIMATED PANEL"));
            this.Line = new Rogui.Shapes.AnimLine(250, 50, 1250, 1000, 10);
            this.Line.AnimationFinished += this.HandleAnimFinished;
            this.Button.AnimationFinished += this.HandleAnimFinished;
            this.Panel.AnimationFinished += this.HandleAnimFinished;

            this.ButtonList.Add(btn1, btn2);
            this.Add(this.ButtonList, this.Line, this.Button, this.Panel);

            this.Button.OnClick += this.CloseButton;
        }

        public void CloseButton(object? sender, EventArgs e)
        {
            this.Button.Close();
        }

        public void HandleClick(object? sender, EventArgs e)
        {
            Console.WriteLine($"{sender} CLICKED");
        }

        public void HandleAnimFinished(object? sender, AnimState state)
        {
            Console.WriteLine($"{sender}: {state}");
        }

        public void HandleLineToggle(object? sender, EventArgs e)
        {
            this.HandleClick(sender, e);

            if(!this.Line.IsOpening && !this.Line.IsOpen)
                { this.Line.Open(); }
            else
                { this.Line.Close(); }
            if(!this.Panel.IsOpening && !this.Panel.IsOpen)
                { this.Panel.Open(); }
            else
                { this.Panel.Close(); }
            if(!this.Button.IsOpening && !this.Button.IsOpen)
                { this.Button.Open(); }
            else
                { this.Button.Close(); }
        }
    }
}