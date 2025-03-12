using System;


namespace lab10
{
    public class Program
    {
        static int SummInAllDebetsCards(BankCard[] arr)
        {
            int sum = 0;
            foreach (BankCard card in arr)
            {
                if (card is DebetCard dc)
                {
                    sum += dc.Balance;
                }
            }
            return sum;
        }
        static int AverageSummOfCreditCards(BankCard[] arr)
        {
            int sum = 0;
            int count = 0;

            foreach (BankCard card in arr)
            {
                if (card is CreditCard cc)
                {
                    sum += cc.Limit / cc.MaturityDate;
                    count++;
                }
            }

            if (count == 0) return 0;

            return sum / count;
        }

        static int SummOfCashBack(BankCard[] arr)
        {
            int sum = 0;

            foreach (BankCard card in arr)
            {
                if (card is YouthCard jc)
                {
                    sum += jc.Balance * jc.CashBack / 100;
                }
            }

            return sum;
        }
        static void Main(string[] args)
        {
            CreditCard creditCardFirst = new CreditCard();
            creditCardFirst.RandomInit();

            CreditCard creditCardSecond = new CreditCard();
            creditCardSecond.RandomInit();

            DebetCard debetCardFirst = new DebetCard();
            debetCardFirst.RandomInit();

            DebetCard debetCardSecond = new DebetCard(debetCardFirst);

            BankCard bankCardFirst = new BankCard(debetCardFirst);

            YouthCard youthCardFirst = new YouthCard();
            youthCardFirst.RandomInit();

            BankCard[] cardsArr = { debetCardFirst, debetCardSecond, bankCardFirst, youthCardFirst };

            foreach (BankCard currentCard in cardsArr)
            {
                Console.WriteLine(currentCard);
                Console.WriteLine();
            }

            int debetCardsCount = 0;
            Console.WriteLine("Обычный просмотр");
            foreach (BankCard currentcard in cardsArr)
            {
                if(currentcard is DebetCard debetCard)
                {
                    debetCardsCount++;
                    debetCard.Show();
                }
            }
            Console.WriteLine("С помощью виртуальный функций");
            foreach (BankCard currentcard in cardsArr)
            {
                if (currentcard is DebetCard debetCard)
                {
                    debetCardsCount++;
                    debetCard.ShowVirtual();
                }
            }

            Console.WriteLine($"В массиве находится {debetCardsCount} дебетовых карт");

            Type t = typeof(DebetCard);
            Console.WriteLine(t.BaseType + " -> " + t.FullName);

            //Запросы
            Console.WriteLine("Запросы");
            Console.WriteLine(SummInAllDebetsCards(cardsArr));
            Console.WriteLine(AverageSummOfCreditCards(cardsArr));
            Console.WriteLine(SummOfCashBack(cardsArr));

            Console.WriteLine();

            GeoCoordinates geoCoordinatesFirst = new GeoCoordinates();
            geoCoordinatesFirst.RandomInit();

            GeoCoordinates geoCoordinatesSecond = new GeoCoordinates();
            geoCoordinatesSecond.RandomInit();

            IInit[] initObjects = { creditCardFirst, debetCardSecond, geoCoordinatesFirst, youthCardFirst, creditCardSecond, debetCardFirst, geoCoordinatesSecond };

            int bankCount = 0;
            int creditCount = 0;
            int youthCard = 0;
            int debateCard = 0;
            int geoCoordinatesCount = 0;

            foreach (IInit obj in initObjects)
            {
                if (obj is DebetCard)
                {
                    debateCard++;
                }
                else if (obj is BankCard)
                {
                    bankCount++;
                }
                else if (obj is YouthCard)
                {
                    youthCard++;
                }
                else if (obj is GeoCoordinates)
                {
                    geoCoordinatesCount++;
                }
                Console.WriteLine(obj);
                Console.WriteLine();
            }

            Console.WriteLine($"Количество банковских карт - {bankCount}, количество кредитных кард - {creditCount}, количество молодёжных карт - {youthCard}, количество дебетовых карт - {debateCard}, количество координат - {geoCoordinatesCount}");

            BankCard bankCardThird = new BankCard(1234, "Галкин Георгий", "27.01.2944", 1);
            BankCard bankCardFourth = new BankCard(4321, "Гаклин Георгий", "24.02.2781", 2);
            CreditCard creditCardThird = new CreditCard(5555, "Галкин Георгий", "21.06.2055", 3, 11, 14000);

            BankCard[] cardSorting = { bankCardThird, bankCardFourth, creditCardThird };
            //Сортирока по номеру карты
            Array.Sort(cardSorting);

            foreach(BankCard obj in cardSorting)
            {
                Console.WriteLine(obj);
            }

            CreditCard SearchingCard = new CreditCard(creditCardThird);

            //Бинарный поиск
            int index = Array.BinarySearch(cardSorting, SearchingCard);

            if(index >-0)
            {
                Console.WriteLine($"Карта для поиска наёдна на позиции {index}");
            }
            else
            {
                Console.WriteLine("Карта не найдена");
            }
            //Сортировка по дате

            Array.Sort(cardSorting, new ExperiationComparer());

            foreach (BankCard obj in cardSorting)
            {
                obj.ShowVirtual();
            }

            //Бинарный поиск
            index = Array.BinarySearch(cardSorting, SearchingCard, new ExperiationComparer());

            if (index >= 0)
            {
                Console.WriteLine($"Карта для поиска была найдена на позиции {index}");
            }
            else
            {
                Console.WriteLine("Карта не найдена");
            }

            //Разница между клонированием и поверхностынм копированием

            CreditCard original = new CreditCard();
            original.RandomInit();

            CreditCard cloned = (CreditCard)original.Clone();

            CreditCard shallowcopy = (CreditCard)original.ShallowCopy();

            shallowcopy.Id.Number = 787;
            cloned.Id.Number = 444;

            Console.WriteLine($"Поверхностное копирование - {shallowcopy}");
            Console.WriteLine($"Клонирование - {cloned}");
            Console.WriteLine($"Оригинал - {original}");
        }
    }
}
