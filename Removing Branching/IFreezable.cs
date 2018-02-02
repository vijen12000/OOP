using System;

namespace Removing_Branching
{
    interface IFreezable
    {
        IFreezable Deposit(Action addToBalance);
        IFreezable Withdraw(Action subtractFromBalance);
        IFreezable Freeze();
        IFreezable Close();
        IFreezable HolderVerified();
    }
}

