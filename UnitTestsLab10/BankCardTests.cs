using Microsoft.VisualStudio.TestTools.UnitTesting;


using lab10;


using System;





namespace lab10Tests


{


    [TestClass]


    public class BankCardTests


    {


        [TestMethod]


        public void Constructor_DefaultConstructor_ShouldSetDefaults()


        {


            // Arrange & Act


            BankCard card = new BankCard();





            // Assert


            Assert.AreEqual(0, card.Number);


            Assert.AreEqual("01.01.2025", card.ExpirationDate);


            Assert.AreEqual("NoName", card.OwnerOfCard);


            Assert.IsNull(card.Id);





        }





        [TestMethod]


        public void Constructor_CopyConstructor_ShouldCopyProperties()


        {


            // Arrange


            var card = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);


            var copiedCard = new BankCard(card);





            // Assert


            Assert.AreEqual(card.Number, copiedCard.Number);


            Assert.AreEqual(card.ExpirationDate, copiedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, copiedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, copiedCard.Id.Number);


        }





        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetNumber_ShouldThrowArgumentException_WhenNegativeNumber()


        {


            // Arrange


            var card = new BankCard();





            // Act


            card.Number = -1;





            // Assert - Exception should be thrown.


        }





        [TestMethod]


        public void SetOwner_ShouldSetCorrectValue()


        {


            // Arrange


            var card = new BankCard();


            string testOwner = "TestUser";





            // Act


            card.OwnerOfCard = testOwner;





            // Assert


            Assert.AreEqual(testOwner, card.OwnerOfCard);


        }








        [TestMethod]


        [ExpectedException(typeof(ArgumentException))]


        public void SetExpirationDate_ShouldThrowArgumentException_WhenInvalidDateFormat()


        {


            // Arrange


            var card = new BankCard();





            // Act


            card.ExpirationDate = "31-12-2025";





            // Assert - Exception should be thrown


        }





        [TestMethod]


        public void SetExpirationDate_ShouldSetDate_WhenValidDate()


        {


            // Arrange


            var card = new BankCard();


            string testDate = "31.12.2025";





            // Act


            card.ExpirationDate = testDate;





            // Assert


            Assert.AreEqual(testDate, card.ExpirationDate);


        }





        [TestMethod]


        public void Equals_ShouldReturnFalse_WhenDifferent()


        {


            // Arrange


            var card1 = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);


            var card2 = new BankCard(5678, "Криштиану Роналду", "01.01.2026", 2);





            // Act


            bool result = card1.Equals(card2);





            // Assert


            Assert.IsFalse(result);


        }





        [TestMethod]


        public void Clone_ShouldCreateIndependentClone()


        {


            // Arrange


            var card = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);





            // Act


            var clonedCard = (BankCard)card.Clone();





            // Assert


            Assert.AreNotSame(card, clonedCard);


            Assert.AreEqual(card.Number, clonedCard.Number);


            Assert.AreEqual(card.ExpirationDate, clonedCard.ExpirationDate);


            Assert.AreEqual(card.OwnerOfCard, clonedCard.OwnerOfCard);


            Assert.AreEqual(card.Id.Number, clonedCard.Id.Number);


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


        public void CompareTo_ShouldReturnPositive_WhenObjectIsNull()


        {


            // Arrange


            var card = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);





            // Act


            int result = card.CompareTo(null);





            // Assert


            Assert.IsTrue(result > 0);


        }





        [TestMethod]


        public void CompareTo_ShouldReturnZero_WhenNumbersAreEqual()


        {


            // Arrange


            var card1 = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);


            var card2 = new BankCard(1234, "Криштиану Роналду", "01.01.2026", 2);





            // Act


            int result = card1.CompareTo(card2);





            // Assert


            Assert.AreEqual(0, result);


        }





        [TestMethod]





        public void TestToString()


        {


            // Arrange


            var card = new BankCard();





            // Act


            string result = card.ToString();





            // Assert


            string expected = $"Номер вашей карты - {card.Number}, владелец карты - {card.OwnerOfCard}, сроки действия карты - {card.ExpirationDate}, Id карты - {card.Id}";


            Assert.AreEqual(expected, result);


        }





        [TestMethod]


        public void ShowVirtual_WritesFormattedOutputToConsole()


        {


            // Arrange


            var card = new BankCard();





            using (StringWriter sw = new StringWriter())


            {


                Console.SetOut(sw); // Set the StringWriter as the Console output





                // Act


                card.ShowVirtual();





                // Assert


                string expected = $"Номер вашей карты - {card.Number}, владелец карты - {card.OwnerOfCard}, сроки действия карты - {card.ExpirationDate}, Id карты - {card.Id}" + Environment.NewLine; // Account for newline


                Assert.AreEqual(expected, sw.ToString());


            }


            Console.SetOut(Console.Out);


        }


        [TestMethod]


        public void Equals_DifferentObjectType_ReturnsFalse()


        {


            // Arrange


            var card1 = new DebetCard(123456789, "12.01.2026", "Криштиану Роналду", 1, 1000);


            object card2 = new object();





            // Act


            bool result = card1.Equals(card2);





            // Assert


            Assert.IsFalse(result);


        }


    }


}