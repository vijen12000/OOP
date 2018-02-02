using System;

namespace Removing_Branching
{
    class NotVerfied : IFreezable
    {
        public Action OnUnFreeze { get; set; }
        public NotVerfied(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        public IFreezable Deposit(Action addToInvoke)
        {
            addToInvoke();
            return this;
        }

        public IFreezable Freeze() => this;

        public IFreezable Withdraw(Action subtractFromBalance) => this;

        public IFreezable Close() => new Closed();

        public IFreezable HolderVerified() => new Active(this.OnUnFreeze);        
    }
}

