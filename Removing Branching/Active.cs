using System;

namespace Removing_Branching
{
    class Active : IFreezable
    {
        public Action OnUnFreeze { get; }

        public Active(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        public IFreezable Deposit() => this;

        public IFreezable Withdraw() => this;

        public IFreezable Freeze()
        {
            return new Frozen(OnUnFreeze);
        }        
    }
}

