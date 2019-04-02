using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chain_Of_Responsibility.Entities;

namespace Chain_Of_Responsibility.Cor
{
    public class CustomersEarningsIsEnoughToPayCredit : CreditRequestBase
    {
        public override void ExecuteProcess(Customer customer)
        {
            //Bir önceki adımdan geçti mi?
            if (base.CreditConfirmed)
            {
                //Gelen müşteri bilgilerinden yola çıkılarak maaşının kredi taksitlerini ödemeye yeterli olup olmadığı kontrolü yapılır.
                bool isEnoughToPay = true;

                base.CreditConfirmed = isEnoughToPay;
            }
        }
    }
}
