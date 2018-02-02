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
        public IFreezable Deposit(Action addToBalance)
        {
            this.OnUnFreeze();
            addToBalance();
            return new Active(OnUnFreeze);
        }
        
        public IFreezable Withdraw(Action subtractFromBalance)
        {
            this.OnUnFreeze();
            subtractFromBalance();
            return new Active(OnUnFreeze);
        }

        public IFreezable Freeze() => this;

        public IFreezable Close() => new Closed();

        public IFreezable HolderVerified() => this;        
    }
}

