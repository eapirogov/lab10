using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class CreditCard : BankCard
    {
        protected int limit;
        protected int maturityDate;

        public int Limit
        {
            get
            {
                return limit;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Кредитный лимить должен быть больше 0 рублей");
                }
            }
        }
        public int MaturityDate
        {
            get
            {
                return maturityDate;
            }
            set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Срок погашения должен быть от 1 месяца");
                }
                maturityDate = value;
            }
        }
        public CreditCard() : base()
        {
            Limit = 0;
            MaturityDate = 6;
        }
        public CreditCard(int number, string ownerOfCard, string expirationDate, int id, int limit, int maturityDate) : base(number, ownerOfCard, expirationDate, id)
        {
            Limit = limit;
            MaturityDate = maturityDate;
        }
        public CreditCard(CreditCard cardToCopy) : base(cardToCopy)
        {
            Limit = cardToCopy.Limit;
            MaturityDate = cardToCopy.MaturityDate;
        }
        public void Show()
        {
            base.Show();
            Console.WriteLine($"Кредитный лимит составляет - {Limit} рублей");
            Console.WriteLine($"Срок погашения составляет - {MaturityDate} месяцев");
        }
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Кредитный лимит составляет - {Limit} рублей");
            Console.WriteLine($"Срок погашения составляет - {MaturityDate} месяцев");

        }
        public override string ToString()
        {
            return base.ToString() + $"Кредитный лимит составляет - {Limit}, срок погашения - {MaturityDate}";
        }
        public override void Init()
        {
            base.Init();
            Limit = Input.IntegerInput("Введите кредитный лимит: ");
            MaturityDate = Input.IntegerInput("Введите сроки погашения крдита");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Limit = random.Next(0, 100000);
            MaturityDate = random.Next(1, 100);
        }
        public override object Clone()
        {
            return new CreditCard(Number, OwnerOfCard, ExpirationDate, Id.Number, Limit, MaturityDate);
        }
        public override object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}
