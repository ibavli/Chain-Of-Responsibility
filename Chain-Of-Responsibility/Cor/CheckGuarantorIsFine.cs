using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chain_Of_Responsibility.Entities;

namespace Chain_Of_Responsibility.Cor
{
    public class CheckGuarantorIsFine : CreditRequestBase
    {
        public override void ExecuteProcess(Customer customer)
        {
            //Bir önceki adımdan geçti mi?
            if (base.CreditConfirmed)
            {
                //Müşterinin kefili varsa, bu kefilin sağlam olup olmadığına bakılıyor diye düşünülebilir.
                bool guarantorIsFine = true;

                base.CreditConfirmed = guarantorIsFine;
            }
        }
    }
}
