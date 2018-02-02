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

        public IFreezable Deposit(Action addToBalance)
        {            
            addToBalance();            
            return this;
        }

        public IFreezable Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IFreezable Freeze()
        {
            return new Frozen(OnUnFreeze);
        }

        public IFreezable Close() => new Closed();

        public IFreezable HolderVerified() => this;        
    }
}