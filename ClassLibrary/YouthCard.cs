using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class YouthCard : BankCard
    {
        protected int cashBack;
        protected int balance;

        public int CashBack
        {
            get
            {
                return cashBack;
            }
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("Кэшбек должен составлять от 0 до 100 процентов");
                }
                cashBack = value;
            }
        }
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Баланс карты не может быть отрицательным");
                }
            }
        }

        public YouthCard() : base()
        {
            CashBack = 0;
            Balance = 0;
        }

        public YouthCard (int number, string ownerOfCard, string expirationDate, int id, int balance, int cashBack) : base(number, ownerOfCard, expirationDate, id)
        {
            Balance = balance;
            CashBack = cashBack;
        }

        public YouthCard(YouthCard cardToCopy) : base(cardToCopy)
        {
            CashBack = cardToCopy.CashBack;
            Balance = cardToCopy.Balance;
        }

        public void Show()
        {
            base.Show();
            Console.WriteLine($"Баланс карты составляет - {Balance}");
            Console.WriteLine($"Кэшбэк составляет - {CashBack}");
        }
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Баланс карты составляет - {Balance}");
            Console.WriteLine($"Кэшбэк составляет - {CashBack}");
        }
        public override string ToString()
        {
            return base.ToString() + $"Баланс составляет - {Balance} рублей, кэшбэк - {CashBack}";
        }
        public override void Init()
        {
            base.Init();
            Balance = Input.IntegerInput("Введите баланс карты");
            CashBack = Input.IntegerInputFromMinToNax("Введите кэшбэк", 0, 100);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Balance = random.Next(0, 1000000);
            CashBack = random.Next(0, 100);
        }
        public override object Clone()
        {
            return new YouthCard(Number, OwnerOfCard, ExpirationDate, Id.Number, Balance, CashBack);
        }
        public override object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}
