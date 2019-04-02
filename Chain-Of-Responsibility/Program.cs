using Chain_Of_Responsibility.Cor;
using Chain_Of_Responsibility.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var creditOperations = GetCreditOperations();

            //Krediyi isteyen müşterinin bilgilerini içeren sınıf paramtre olarak sisteme veriliyor
            //buradan sonra işlemler belirlenen sırada tekrarlanıyor.
            //Burada amaç deseni anlamak olduğu için customer bilgileri ile gerçek bir işlem yapılmamaktadır.
            creditOperations.FirstOrDefault().Execute(new Customer() { Id = 1, FirstName = "Ali", LastName = "Veli" });
            //Son işlemden sonra son işlemin içerisinde bulunan ilgili propertyde istediğimiz bilgi set edilmiş şekildedir.

            bool creditConfirmed = creditOperations.LastOrDefault().CreditConfirmed;

            if (creditConfirmed)
                Console.WriteLine("Kredi isteği onaylandı.");
            else
                Console.WriteLine("Kredi isteği reddedildi.");

            Console.ReadLine();
        }

        public static List<CreditRequestBase> GetCreditOperations()
        {
            //Yapılacak olan işlemlerin hepsini aynı listeye koyalım.
            List<CreditRequestBase> creditOperations = new List<CreditRequestBase>();
            //Bütün işlemler listenin içerisine yerleştiriliyor.
            creditOperations.Add(new CheckKbbScore());
            creditOperations.Add(new CheckKreditCardPaymentTime());
            creditOperations.Add(new CheckGuarantorIsFine());
            creditOperations.Add(new CustomersEarningsIsEnoughToPayCredit());
            creditOperations.Add(new CheckCompanyCustomerWork());

            creditOperations[0].SetNext(creditOperations[1]);
            creditOperations[1].SetNext(creditOperations[2]);
            creditOperations[2].SetNext(creditOperations[3]);
            creditOperations[3].SetNext(creditOperations[4]);

            return creditOperations;
        }
    }
}
