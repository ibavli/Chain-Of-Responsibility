using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chain_Of_Responsibility.Entities;

namespace Chain_Of_Responsibility.Cor
{
    public class CheckCompanyCustomerWork : CreditRequestBase
    {
        public override void ExecuteProcess(Customer customer)
        {
            //Bir önceki adımdan geçti mi?
            if (base.CreditConfirmed)
            {
                //Burada müşterinin çalıştığı firmanın iyi bir firma olup olmadığının kontrolü yapılıyor.
                bool companyIsFine = true;

                base.CreditConfirmed = companyIsFine;
            }
        }
    }
}
