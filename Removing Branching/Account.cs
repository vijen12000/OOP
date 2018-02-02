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
                        
        private IFreezable State { get; set; }
        public Account(Action onUnFreeze)
        {
            this.State = new Active(onUnFreeze);            
        }

        public void Depoist(decimal amount)
        {           
            this.State = this.State.Deposit(()=> { Balance += amount; });            
        }

        public void Withdraw(decimal amount)
        {          
            this.State = this.State.Withdraw(()=> { Balance -= amount; });            
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerified();
        }

        public void Close()
        {
            this.State = this.State.Close();
        }
        public void Freeze()
        {            
            this.State = this.State.Freeze();
        }        
    }
}

