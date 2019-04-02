using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chain_Of_Responsibility.Entities;

namespace Chain_Of_Responsibility.Cor
{
    public class CheckKreditCardPaymentTime : CreditRequestBase
    {
        public override void ExecuteProcess(Customer customer)
        {
            //Bir önceki adımdan geçti mi?
            if (base.CreditConfirmed)
            {
                //Burada daha önce kredi kartı borcunu geciktirip gecirtirmediği ve geciktirdiyse kaç ay geciktirdiği verisi getiriliyor.
                int paymetDelayTime = 1;

                base.CreditConfirmed = paymetDelayTime > 3 ? false : true;
            }
        }
    }
}
