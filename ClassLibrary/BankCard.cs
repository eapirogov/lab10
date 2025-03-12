using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab10
{
    public class BankCard: IInit, IComparable<BankCard>, ICloneable
    {
        protected int number;
        protected string expirationDate;
        protected string ownerOfCard;

        public IdNumber Id { get; set; }

        protected static string expDatePattern = @"^\d{1,2}\.\d{1,2}\.\d{4}$";
        protected static Regex expDateRegex = new Regex(expDatePattern);

        protected static Random random = new Random();
        protected string[] ownerOfCardsNames = { "Егор", "Алексей", "Георгий", "Виктор" };
        protected string[] ownerOfCardsSurnnames = { "Пирогов", "Пигасов", "Галкин", "Штенцов" };

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Номер карты не может являться отрицательным числом!");
                }
            }
        }
        public string OwnerOfCard
        {
            get
            {
                return ownerOfCard;
            }
            set
            {
                ownerOfCard = value;
            }
        }
        public string ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if (!expDateRegex.IsMatch(value))
                {
                    throw new ArgumentException("Дата должна быть представлена в формате **.**.****");
                }
                expirationDate = value;
            }
        }

        public BankCard()
        {
            Number = 0;
            OwnerOfCard = "NoName";
            ExpirationDate = "01.01.2025";
        }

        public BankCard( int number, string ownerOfCard, string expirationDate, int ID)
        {
            Number = number;
            OwnerOfCard = ownerOfCard;
            ExpirationDate = expirationDate;
            Id = new IdNumber(ID);
        }

        public BankCard(BankCard toCopy)
        {
            Number = toCopy.Number;
            OwnerOfCard = toCopy.OwnerOfCard;
            ExpirationDate = toCopy.ExpirationDate;
            Id = toCopy.Id;
        }

        public void Show()
        {
            Console.WriteLine($"Номер вашей карты - {Number}, владелец карты - {OwnerOfCard}, сроки действия карты - {ExpirationDate}, Id карты - {Id}");
        }
        public override string ToString()
        {
            return $"Номер вашей карты - {Number}, владелец карты - {OwnerOfCard}, сроки действия карты - {ExpirationDate}, Id карты - {Id}";
        }

        public virtual void ShowVirtual()
        {
            Console.WriteLine($"Номер вашей карты - {Number}, владелец карты - {OwnerOfCard}, сроки действия карты - {ExpirationDate}, Id карты - {Id}");
        }

        public virtual void Init()
        {
            Number = Input.IntegerInput("Введите номер вашей карты: ");
            try
            {
                Console.WriteLine("Введите сроки дейсвтия вашей карты в формате **.**.****");
                ExpirationDate = Console.ReadLine();

                Console.WriteLine("Введите имя владельца карты: ");
                OwnerOfCard = Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Id = new IdNumber(Input.IntegerInputWithZero("Введите ID карты"));
        }

        public virtual void RandomInit()
        {
            Number = random.Next(1000, 9999);
            OwnerOfCard = ownerOfCardsNames[random.Next(ownerOfCardsNames.Length)] + " " + ownerOfCardsSurnnames[random.Next(ownerOfCardsSurnnames.Length)];
            ExpirationDate = random.Next(1, 31).ToString() + "." + random.Next(1, 12).ToString() + "." + random.Next(2025, 3000).ToString();
            Id = new IdNumber(random.Next(0, 9999));
        }

        public int CompareTo(BankCard obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if(obj is not BankCard other)
            {
                throw new ArgumentException("Сравнение ведётся только с объектами BankCard");

            }

            return Number.CompareTo(other.Number);
        }

        public virtual object Clone()
        {
            return new BankCard(Number, OwnerOfCard, ExpirationDate, Id.Number);
        }

        public virtual object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is BankCard))
            {
                return false;
            }
            var objToComapre = obj as BankCard;
            if (Number == objToComapre.Number && OwnerOfCard == objToComapre.OwnerOfCard && ExpirationDate == objToComapre.ExpirationDate)
            {
                return true;
            }
            return false;
        }
    }
}
