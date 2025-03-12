using Microsoft.VisualStudio.TestTools.UnitTesting;



using lab10;


using System;


using System.Text.RegularExpressions;





namespace lab10Tests


{


    [TestClass]


    public class DebetCardTests


    {


        [TestMethod]


        public void Constructor_DefaultConstructor_ShouldSetDefaults()


        {


            // Arrange & Act


            DebetCard card = new DebetCard();





            // Assert


            Assert.AreEqual(0, card.Number);


            Assert.AreEqual("01.01.2025", card.ExpirationDate);


            Assert.AreEqual("NoName", card.OwnerOfCard);


            Assert.AreEqual(0, card.Balance);


            Assert.IsNull(card.Id);


        }


        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetBalance_ShouldThrowArgumentException_WhenNegativeBalance()


        {


            // Arrange


            var card = new DebetCard();





            // Act


            card.Balance = -1;


        }


        [TestMethod]


        public void DebetCard_Constructor_ZeroBalance()


        {


            int balance = 0;


            // Act


            var debetCard = new DebetCard();





            // Assert


            Assert.AreEqual(balance, debetCard.Balance);


        }


        [TestMethod]


        public void DebetCard_CopyConstructor_ZeroBalance()


        {


            // Arrange


            var originalCard = new DebetCard(1111, "01.12.2026", "Криштиану Роналду", 456, 0);





            // Act


            var copiedCard = new DebetCard(originalCard);





            // Assert


            Assert.AreEqual(originalCard.Number, copiedCard.Number);


            Assert.AreEqual(originalCard.OwnerOfCard, copiedCard.OwnerOfCard);


            Assert.AreEqual(originalCard.ExpirationDate, copiedCard.ExpirationDate);


            Assert.AreEqual(originalCard.Id, copiedCard.Id);


            Assert.AreEqual(originalCard.Balance, copiedCard.Balance);


            Assert.AreNotSame(originalCard, copiedCard);


        }


        [TestMethod]


        public void DebetCard_Constructor_SetsPropertiesCorrectly()


        {


            // Arrange


            int number = 0;


            string ownerOfCard = "Криштиану Роналду";


            string expirationDate = "01.12.2026";


            int id = 123;


            int balance = 0;





            // Act


            var debetCard = new DebetCard(number, expirationDate, ownerOfCard, id, balance);





            // Assert


            Assert.AreEqual(number, debetCard.Number);


            Assert.AreEqual(ownerOfCard, debetCard.OwnerOfCard);


            Assert.AreEqual(expirationDate, debetCard.ExpirationDate);


            Assert.AreEqual(id, debetCard.Id.Number);


            Assert.AreEqual(balance, debetCard.Balance);


        }


        [TestMethod]


        public void RandomInit_SetsAllProperties()


        {


            // Arrange


            var debetCard = new DebetCard();





            // Act


            debetCard.RandomInit();





            // Assert


            Assert.IsNotNull(debetCard.Number);


            Assert.IsNotNull(debetCard.OwnerOfCard);


            Assert.IsNotNull(debetCard.ExpirationDate);


            Assert.AreNotEqual(0, debetCard.Id.Number);


            Assert.IsTrue(debetCard.Balance >= 0 && debetCard.Balance <= 1000000);








            Assert.IsTrue(Regex.IsMatch(debetCard.ExpirationDate, @"^\d{1,2}\.\d{1,2}\.\d{4}$"));





            string[] dateParts = debetCard.ExpirationDate.Split('.');


            int day = int.Parse(dateParts[0]);


            int month = int.Parse(dateParts[1]);


            int year = int.Parse(dateParts[2]);





            Assert.IsTrue(day >= 1 && day <= 31);


            Assert.IsTrue(month >= 1 && month <= 12);


            Assert.IsTrue(year >= 2025 && year <= 3000);


        }


        [TestMethod]


        public void Equals_NullObject_ReturnsFalse()


        {


            // Arrange


            var card1 = new DebetCard(123456789, "12.01.2026", "Криштиану Роналду", 1, 1000);


            object card2 = null;





            // Act


            bool result = card1.Equals(card2);





            // Assert


            Assert.IsFalse(result);


        }


        [TestMethod]


        public void Equals_EqualObjects_ReturnsTrue()


        {


            // Arrange


            var card1 = new DebetCard(123456789, "12.01.2025", "Криштиану Роналду", 1, 1000);


            var card2 = new DebetCard(123456789, "12.01.2025", "Криштиану Роналду", 1, 1000);





            // Act


            bool result = card1.Equals(card2);





            // Assert


            Assert.IsTrue(result);


        }


        [TestMethod]


        public void ShallowCopy_ShouldCreateDifferentObjectWithSameReferences()


        {


            // Arrange


            var card = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);





            // Act


            var shallowCopy = (BankCard)card.ShallowCopy();





            // Assert


            Assert.AreNotSame(card, shallowCopy);


            Assert.AreEqual(card.Number, shallowCopy.Number);


            Assert.AreEqual(card.OwnerOfCard, shallowCopy.OwnerOfCard);


            Assert.AreEqual(card.ExpirationDate, shallowCopy.ExpirationDate);


            Assert.AreEqual(card.Id.Number, shallowCopy.Id.Number);





        }


        [TestMethod]


        public void DebitCard_ShallowCopy_ShouldCreateShallowCopy()


        {


            var card = new DebetCard(1234, "10.10.2030", "Иван", 1, 1000);


            var shallowCopiedCard = (DebetCard)card.ShallowCopy();





            Assert.AreNotSame(card, shallowCopiedCard);


            Assert.AreEqual(card.Number, shallowCopiedCard.Number);


            Assert.AreEqual(card.ExpirationDate, shallowCopiedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, shallowCopiedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, shallowCopiedCard.Id.Number);


            Assert.AreEqual(card.Balance, shallowCopiedCard.Balance);





            // Проверяем, что ссылки на Id одинаковые в оригинале и копии


            Assert.AreSame(card.Id, shallowCopiedCard.Id);


        }


        [TestMethod]


        public void CreditCard_RandomInit_ShouldGenerateRandomValues()


        {


            var card = new CreditCard();


            card.RandomInit();





            // Проверяем, что значения изменены (не равны значениям по умолчанию)


            Assert.AreNotEqual(1, card.Number);


        }


    }


}