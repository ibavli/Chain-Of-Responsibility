using Chain_Of_Responsibility.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility.Cor
{
    public abstract class CreditRequestBase
    {
        //Bu veri bizim nesneler arasında yaşımak isteyeceğimiz veri.
        //Birden fazla da olabilirdi.
        public bool CreditConfirmed;

        protected CreditRequestBase nextOperation;

        public void SetNext(CreditRequestBase operation)
        {
            this.nextOperation = operation;
        }

        public void Execute(Customer customer)
        {
            ExecuteProcess(customer);
            if(this.nextOperation != null)
            {
                //Her seferinde bir sonrakine aktarılır.
                this.nextOperation.CreditConfirmed = this.CreditConfirmed;

                //Bir sonraki çalıştırılır.
                this.nextOperation.Execute(customer);
            }
        }

        public abstract void ExecuteProcess(Customer customer);
    }
}
