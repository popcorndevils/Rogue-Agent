using Rogue.Aspects.Containers;
using Rogue.Aspects.Primitives;

namespace Rogue.UI
{
    public class Debug : VBox
    {
        public Debug() : base()
        {
            this.Margin = 20;
            this.MarginSeparator = 10;
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
    }
}