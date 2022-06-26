using SFML.Window;

namespace Rogue.Types
{
    public struct KeyState
    {
        Keyboard.Key Code;
        public bool Alt;
        public bool Control;
        public bool Shift;

        public KeyState(Keyboard.Key k, bool alt = false, bool ctrl = false, bool shft = false)
        {
            this.Code = k;
            this.Alt = alt;
            this.Control = ctrl;
            this.Shift = shft;
        }

        public static explicit operator KeyState(KeyEventArgs k) => new KeyState(k.Code, k.Alt, k.Control, k.Shift);
    }
}