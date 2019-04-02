using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chain_Of_Responsibility.Entities;

namespace Chain_Of_Responsibility.Cor
{
    public class CheckKbbScore : CreditRequestBase
    {
        public override void ExecuteProcess(Customer customer)
        {
            //Bu değeri bir servisten veya veri tabanından çektiğimizi varsayalım.
            int kbbScore = 1200;

            base.CreditConfirmed = kbbScore > 1000 ? true : false;
        }
    }
}
