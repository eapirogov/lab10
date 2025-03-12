using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class DebetCard : BankCard
    {
        protected int balance;

        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Баланс карты не может быть отрицательным");
                }
            }
        }
        public DebetCard() : base()
        {
            Balance = 0;
        }

        public DebetCard(int number, string ownerOfCard, string expirationDate, int id, int balance) : base (number, expirationDate, ownerOfCard, id)
        {
            Balance = balance;
        }

        public DebetCard(DebetCard cardToCopy) : base(cardToCopy)
        {
            Balance = cardToCopy.Balance;
        }

        public void Show()
        {
            base.Show();
            Console.WriteLine($"Баланс карты составляет - {Balance} рублей");
        }

        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Баланс карты составляет - {Balance} рублей");

        }

        public override void Init()
        {
            base.Init();
            Balance = Input.IntegerInput("Введите баланс карты");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Balance = random.Next(0, 1000000);
            ExpirationDate = random.Next(1, 31).ToString() + "." + random.Next(1, 12).ToString() + "." + random.Next(2025, 3000).ToString();
        }

        public override object Clone()
        {
            return new DebetCard(Number, OwnerOfCard, ExpirationDate, Id.Number, Balance);
        }

        public override object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DebetCard))
            {
                return false;
            }
            var objToCompare = obj as DebetCard;

            if (Number == objToCompare.Number && OwnerOfCard == objToCompare.OwnerOfCard && ExpirationDate == objToCompare.ExpirationDate && Balance == objToCompare.Balance)
            {
                return true;
            }
            return false;
        }
    }
}
