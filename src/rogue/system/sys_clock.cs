using System.Diagnostics;

namespace Rogue.System
{
    public class SysClock : BaseSys
    {
        private long _PreviousTicks;
        private float? _FrameLimit;
        private long _DeltaT;

        public long Ticks;
        public long? TickLimit;
        public float DeltaFps;

        public long DeltaT {
            get => this._DeltaT;
            set {
                this._DeltaT = value;
                this.DeltaFps = 10_000_000f / value;
            }
        }

        public float? FrameLimit {
            get => this._FrameLimit;
            set {
                if(value > 0)
                {
                    this._FrameLimit = value;
                    this.TickLimit =  (long?)(10_000_000 / value);
                }
                else
                {
                    this._FrameLimit = null;
                    this.TickLimit = null;
                }
            }
        }

        public SysClock()
        {
            this.Ticks = Stopwatch.GetTimestamp();
            this._PreviousTicks = this.Ticks;
        }

        public override void Update()
        {
            bool _continue = true;
            long _new_ticks = 0;
            long _passed = 0;

            while(_continue)
            {
                _new_ticks = Stopwatch.GetTimestamp();
                _passed = _new_ticks - this._PreviousTicks;
                if(_passed != 0 && (this.TickLimit is null || _passed >= this.TickLimit))
                {
                    _continue = false;
                }
            }

            this.DeltaT = _passed;
            this._PreviousTicks = this.Ticks;
            this.Ticks = _new_ticks;
        }
    }
}