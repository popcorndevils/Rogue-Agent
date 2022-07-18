using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Rogui;
using Rogui.Shapes;
using Rogui.Themes;

namespace RogueAgent.UI
{
    public class UITest : Aspect
    {
        // private VBox ButtonList = new VBox();
        private LineButton LineButton;
        private AnimButton AnimButton;
        private AnimPanel AnimPanel;

        public UITest()
        {    
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

            this.AnimButton = new AnimButton("ANIMATED BUTTON") {
                Theme = _theme_btn,
                Position = new Vector2f(300, 200),
            };

            this.AnimPanel = new AnimPanel(new Label("ANIMATED PANEL")) {
                Theme = _theme_normal,
                Position = new Vector2f(700, 500),
            };

            btn1.OnClick += this.HandleClick;
            btn2.OnClick += this.HandleLineToggle;

            this.LineButton = new LineButton(
                "LINE BUTTON",
                new Vector2f(250, 50),
                new Vector2f(500, 800), 10) {
                    AnimDirection = AnimDirection.CENTER,
                    AnimSpeed = 1,
                };
            
            this.LineButton.Theme = _theme_btn;

            this.LineButton.AnimationFinished += this.HandleAnimFinished;
            this.AnimButton.AnimationFinished += this.HandleAnimFinished;
            this.AnimPanel.AnimationFinished += this.HandleAnimFinished;

            var _btn_list = new VBox(btn1, btn2) {
                MarginSeparator = 5
            };

            this.Add(_btn_list, this.LineButton, this.AnimButton, this.AnimPanel);

            this.AnimButton.OnClick += this.CloseButton;
            this.LineButton.OnClick += this.CloseButton;
        }

        public void CloseButton(object? sender, EventArgs e)
        {
            if(sender is AnimButton a)
                { a.Close(); }
            else if(sender is LineButton b)
                { b.Close(); }
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

            if(!this.LineButton.IsOpening && !this.LineButton.IsOpen)
                { this.LineButton.Open(); }
            else
                { this.LineButton.Close(); }
            if(!this.AnimPanel.IsOpening && !this.AnimPanel.IsOpen)
                { this.AnimPanel.Open(); }
            else
                { this.AnimPanel.Close(); }
            if(!this.AnimButton.IsOpening && !this.AnimButton.IsOpen)
                { this.AnimButton.Open(); }
            else
                { this.AnimButton.Close(); }
        }
    }
}