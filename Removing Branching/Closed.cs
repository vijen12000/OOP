using System;

namespace Removing_Branching
{
    class Closed : IFreezable
    {        
        public IFreezable Deposit(Action addToBalance)=> this;

        public IFreezable Freeze() => this;
        
        public IFreezable Withdraw(Action subtractFromBalance)=>this;

        public IFreezable Close() => this;

        public IFreezable HolderVerified() => this;        
    }
}

