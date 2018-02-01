using System;

namespace Removing_Branching
{
    class Frozen : IFreezable
    {
        private Action OnUnFreeze { get; set; }
        public Frozen(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        public IFreezable Deposit()
        {
            this.OnUnFreeze();
            return new Active(OnUnFreeze);
        }
        
        public IFreezable Withdraw()
        {
            this.OnUnFreeze();
            return new Active(OnUnFreeze);
        }

        public IFreezable Freeze() => this;       
    }
}

