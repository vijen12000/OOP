using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Removing_Branching
{

    class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        private Action OnUnFreeze { get; }

        public Account(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        
        /// <summary>
        /// Question: how many ways this method can be called?
        /// Ans: Two ways
        /// 1. drop for the If Method aka closed account and exit the code.
        /// 2. deposit the amount
        /// </summary>
        /// <param name="amount"></param>
        ///#1:Deposit 10, Close, Deposit 1, Balance should be 10
        ///#2:Deposit 10, Deposit 1, Balance should 11
        public void Depoist(decimal amount)
        {
            if (this.IsClosed)
                return;//or do something else

            Balance += amount;
        }

        /// <summary>
        /// Wihdraw method can be called in three ways.
        /// 1. Account is not verified, Simple exit the method
        /// 2. Account is verified, but closed, exit te method
        /// 3. Account is verified, and account is not closed, withdraw the amount
        /// </summary>
        /// <param name="amount"></param>
        /// #3 Deposit 10, withdraw 1,Balance 10 -- not verified
        /// #4 Deposit 10, verify, close, withdraw 1 balance =10
        /// #5 Deposit 10 verify, withdraw 1 balance 9
        public void Withdraw(decimal amount)
        {
            //To Withdraw money holder must be verified
            if (!this.IsVerified)
                return; //or do something else

            if (this.IsClosed)
                return; // or do something else

            //withdraw money
            Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }
        
        public void Freeze()
        {
            if (this.IsClosed)
                return;//Account must not be closed
            if (!this.IsVerified)
                return;//Account must be verified

            this.IsFrozen = true;
        }
    }
}

/*
 Account will be unfrozen automatically on deposit or withdraw.
 Unfreezing the account triggers a custom action.
*/
