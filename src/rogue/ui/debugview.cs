using Rogui;
using RogueAgent.Services;

namespace RogueAgent.UI
{
    public class DebugView : VBox
    {
        public override bool Visible { get; set; } = false;

        public DebugView() : base()
        {
            this.Margin = 10;
            this.MarginSeparator = 0;
        }
        
        public void LoadText(List<string>? txt)
        {
            if(txt is not null)
            {
                for(int i = 0; i < txt.Count; i++)
                {
                    if(i >= this.Children.Count)
                    {
                        this.Children.Add(new Label(txt[i]));
                    }
                    else
                    {
                        var _t = this.Children[i] as Label;
                        if(_t is not null)
                        {
                            _t.DisplayedString = txt[i];
                        }
                    }
                }
                this.UpdateLayout();
            }
        }

        public override void Update(float? ms)
        {
            if(this.Visible)
            {
                this.LoadText(SvcState.DebugText);
            }
            base.Update(ms);
        }
    }
}