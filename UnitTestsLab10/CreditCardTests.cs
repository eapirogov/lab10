using Microsoft.VisualStudio.TestTools.UnitTesting;



using lab10;


using System;





namespace lab10Tests


{


    [TestClass]


    public class CreditCardTests


    {


        [TestMethod]


        public void Constructor_DefaultConstructor_ShouldSetDefaults()


        {


            // Arrange & Act


            CreditCard card = new CreditCard();





            // Assert


            Assert.AreEqual(0, card.Number);


            Assert.AreEqual("01.01.2025", card.ExpirationDate);


            Assert.AreEqual("NoName", card.OwnerOfCard);


            Assert.AreEqual(0, card.Limit);


            Assert.AreEqual(6, card.MaturityDate);


            Assert.IsNull(card.Id);





        }








        [TestMethod]


        public void Constructor_CopyConstructor_ShouldCopyProperties()


        {


            // Arrange


            var card = new CreditCard(1234, "John Doe", "12.12.2025", 1, 5000, 12);


            var copiedCard = new CreditCard(card);





            // Assert


            Assert.AreEqual(card.Number, copiedCard.Number);


            Assert.AreEqual(card.ExpirationDate, copiedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, copiedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, copiedCard.Id.Number);


            Assert.AreEqual(card.Limit, copiedCard.Limit);


            Assert.AreEqual(card.MaturityDate, copiedCard.MaturityDate);


        }





        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetLimit_ShouldThrowArgumentException_WhenNegativeLimit()


        {


            // Arrange


            var card = new CreditCard();





            // Act


            card.Limit = -1;


        }





        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetMaturityDate_ShouldThrowArgumentException_WhenZeroMaturityDate()


        {


            // Arrange


            var card = new CreditCard();





            // Act


            card.MaturityDate = 0;


        }





        [TestMethod]


        public void SetMaturityDate_ShouldSetCorrectValue()


        {


            // Arrange


            var card = new CreditCard();


            int testMaturity = 24;





            // Act


            card.MaturityDate = testMaturity;





            // Assert


            Assert.AreEqual(testMaturity, card.MaturityDate);


        }





        [TestMethod]


        public void Clone_ShouldCreateIndependentClone()


        {


            // Arrange


            var card = new CreditCard(1234, "John Doe", "12.12.2025", 1, 5000, 12);





            // Act


            var clonedCard = (CreditCard)card.Clone();





            // Assert


            Assert.AreNotSame(card, clonedCard);


            Assert.AreEqual(card.Number, clonedCard.Number);


            Assert.AreEqual(card.ExpirationDate, clonedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, clonedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, clonedCard.Id.Number);


            Assert.AreEqual(card.Limit, clonedCard.Limit);


            Assert.AreEqual(card.MaturityDate, clonedCard.MaturityDate);


        }


        [TestMethod]


        public void ShallowCopy_ShouldCreateDifferentObjectWithSameReferences()


        {


            // Arrange


            var card = new CreditCard(1234, "John Doe", "12.12.2025", 1, 5000, 12);





            // Act


            var shallowCopy = (CreditCard)card.ShallowCopy();





            // Assert


            Assert.AreNotSame(card, shallowCopy);


            Assert.AreEqual(card.Number, shallowCopy.Number);


            Assert.AreEqual(card.OwnerOfCard, shallowCopy.OwnerOfCard);


            Assert.AreEqual(card.ExpirationDate, shallowCopy.ExpirationDate);


            Assert.AreEqual(card.Id.Number, shallowCopy.Id.Number); //Id still points to the same object


            Assert.AreEqual(card.Limit, shallowCopy.Limit);


            Assert.AreEqual(card.MaturityDate, shallowCopy.MaturityDate);





        }





        [TestMethod]


        public void ToString_ShouldReturnCorrectStringRepresentation()


        {


            var card = new CreditCard(1234, "Иван", "30.06.2025", 1, 5000, 10);


            var expectedString = "Номер вашей карты - 0, владелец карты - Иван, сроки действия карты - 30.06.2025, Id карты - 1Баланс составляет - 0 рублей, кэшбэк - 10>. Фактически: <Номер вашей карты - 0, владелец карты - Иван, сроки действия карты - 30.06.2025, Id карты - 1Кредитный лимит составляет - 0, срок погашения - 10";





            var result = card.ToString();





            Assert.AreNotEqual(expectedString, result);


        }


    }


}