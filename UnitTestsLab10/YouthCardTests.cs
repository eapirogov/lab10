using Microsoft.VisualStudio.TestTools.UnitTesting;



using lab10;


using System;


using System.Text.RegularExpressions;





namespace lab10Tests


{


    [TestClass]


    public class YouthCardTests


    {


        [TestMethod]


        public void Constructor_DefaultConstructor_ShouldSetDefaults()


        {


            // Arrange & Act


            YouthCard card = new YouthCard();





            // Assert


            Assert.AreEqual(0, card.Number);


            Assert.AreEqual("01.01.2025", card.ExpirationDate);


            Assert.AreEqual("NoName", card.OwnerOfCard);


            Assert.AreEqual(0, card.Balance);


            Assert.AreEqual(0, card.CashBack);


            Assert.IsNull(card.Id);


        }


        [TestMethod]


        public void Constructor_CopyConstructor_ShouldCopyProperties()


        {


            // Arrange


            var card = new YouthCard(1234, "Криштиану Роналду", "12.12.2025", 1, 5000, 5);


            var copiedCard = new YouthCard(card);





            // Assert


            Assert.AreEqual(card.Number, copiedCard.Number);


            Assert.AreEqual(card.ExpirationDate, copiedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, copiedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, copiedCard.Id.Number);


            Assert.AreEqual(card.Balance, copiedCard.Balance);


            Assert.AreEqual(card.CashBack, copiedCard.CashBack);


        }





        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetCashBack_ShouldThrowArgumentException_WhenCashBackIsLessThanZero()


        {


            // Arrange


            var card = new YouthCard();





            // Act


            card.CashBack = -1;


        }





        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetCashBack_ShouldThrowArgumentException_WhenCashBackIsGreaterThanHundred()


        {


            // Arrange


            var card = new YouthCard();





            // Act


            card.CashBack = 101;


        }





        [TestMethod]


        public void SetCashBack_ShouldSetCorrectValue()


        {


            // Arrange


            var card = new YouthCard();


            int testCashBack = 10;





            // Act


            card.CashBack = testCashBack;





            // Assert


            Assert.AreEqual(testCashBack, card.CashBack);


        }





        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetBalance_ShouldThrowArgumentException_WhenBalanceIsLessThanZero()


        {


            // Arrange


            var card = new YouthCard();





            // Act


            card.Balance = -1;


        }





        [TestMethod]


        public void Clone_ShouldCreateIndependentClone()


        {


            // Arrange


            var card = new YouthCard(1234, "Криштиану Роналду", "12.12.2025", 1, 5000, 5);





            // Act


            var clonedCard = (YouthCard)card.Clone();





            // Assert


            Assert.AreNotSame(card, clonedCard);


            Assert.AreEqual(card.Number, clonedCard.Number);


            Assert.AreEqual(card.ExpirationDate, clonedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, clonedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, clonedCard.Id.Number);


            Assert.AreEqual(card.Balance, clonedCard.Balance);


            Assert.AreEqual(card.CashBack, clonedCard.CashBack);


        }





        [TestMethod]


        public void ShallowCopy_ShouldCreateDifferentObjectWithSameReferences()


        {


            // Arrange


            var card = new YouthCard(1234, "Криштиану Роналду", "12.12.2025", 1, 5000, 5);





            // Act


            var shallowCopy = (YouthCard)card.ShallowCopy();





            // Assert


            Assert.AreNotSame(card, shallowCopy);


            Assert.AreEqual(card.Number, shallowCopy.Number);


            Assert.AreEqual(card.OwnerOfCard, shallowCopy.OwnerOfCard);


            Assert.AreEqual(card.ExpirationDate, shallowCopy.ExpirationDate);


            Assert.AreEqual(card.Id.Number, shallowCopy.Id.Number);


            Assert.AreEqual(card.Balance, shallowCopy.Balance);


            Assert.AreEqual(card.CashBack, shallowCopy.CashBack);


        }


        [TestMethod]


        public void RandomInit_SetsAllPropertiesWithinExpectedRanges()


        {


            // Arrange


            var debetCard = new YouthCard();





            // Act


            debetCard.RandomInit();





            // Assert


            Assert.IsNotNull(debetCard.Number);


            Assert.IsNotNull(debetCard.OwnerOfCard);


            Assert.IsNotNull(debetCard.ExpirationDate);


            Assert.AreNotEqual(0, debetCard.Id.Number);


            Assert.IsTrue(debetCard.Balance >= 0 && debetCard.Balance <= 1000000);


            Assert.IsTrue(debetCard.CashBack >= 0 && debetCard.CashBack <= 100);








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


        public void ToString_ShouldReturnCorrectStringRepresentation()


        {


            var card = new YouthCard(1234, "Иван", "30.06.2025", 1, 5000, 10);


            var expectedString = "Номер вашей карты - 0, владелец карты - Иван, сроки действия карты - 30.06.2025, Id карты - 1Баланс составляет - 0 рублей, кэшбэк - 10";





            var result = card.ToString();





            Assert.AreEqual(expectedString, result);


        }


    }


}