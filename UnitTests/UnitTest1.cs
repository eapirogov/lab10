
using lab10;
using System;
using NUnit.Framework;

namespace lab10.Tests
{
    [TestClass]
    public class BankCardTests
    {
        [TestMethod]
        public void BankCard_DefaultConstructor_CreatesValidObject()
        {
            // Arrange & Act
            BankCard card = new BankCard();

            // Assert
            Assert.AreEqual(0, card.Number);
            Assert.AreEqual("NoName", card.OwnerOfCard);
            Assert.AreEqual("01.01.2025", card.ExpirationDate);
        }

        [TestMethod]
        public void BankCard_ParameterizedConstructor_CreatesValidObject()
        {
            // Arrange
            int number = 123456789;
            string owner = "John Doe";
            string expiration = "12.12.2024";
            int id = 98765;

            // Act
            BankCard card = new BankCard(number, owner, expiration, id);

            // Assert
            Assert.AreEqual(number, card.Number);
            Assert.AreEqual(owner, card.OwnerOfCard);
            Assert.AreEqual(expiration, card.ExpirationDate);
            Assert.AreEqual(id, card.Id.ID);
        }

        [TestMethod]
        public void BankCard_CopyConstructor_CreatesValidObject()
        {
            // Arrange
            int number = 123456789;
            string owner = "John Doe";
            string expiration = "12.12.2024";
            int id = 98765;
            BankCard originalCard = new BankCard(number, owner, expiration, id);

            // Act
            BankCard copiedCard = new BankCard(originalCard);

            // Assert
            Assert.AreEqual(number, copiedCard.Number);
            Assert.AreEqual(owner, copiedCard.OwnerOfCard);
            Assert.AreEqual(expiration, copiedCard.ExpirationDate);
            Assert.AreEqual(id, copiedCard.Id.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Number_SetNegativeValue_ThrowsArgumentException()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Number = -1;

            // Assert - Exception should be thrown
        }

        [TestMethod]
        public void Number_SetValidValue_SetsCorrectValue()
        {
            // Arrange
            BankCard card = new BankCard();
            int validNumber = 12345;

            // Act
            card.Number = validNumber;

            // Assert
            Assert.AreEqual(validNumber, card.Number);
        }

        [TestMethod]
        public void OwnerOfCard_SetValidValue_SetsCorrectValue()
        {
            // Arrange
            BankCard card = new BankCard();
            string validOwner = "Jane Smith";

            // Act
            card.OwnerOfCard = validOwner;

            // Assert
            Assert.AreEqual(validOwner, card.OwnerOfCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpirationDate_SetInvalidFormat_ThrowsArgumentException()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.ExpirationDate = "12-12-2024";

            // Assert - Exception should be thrown
        }

        [TestMethod]
        public void ExpirationDate_SetValidFormat_SetsCorrectValue()
        {
            // Arrange
            BankCard card = new BankCard();
            string validExpiration = "05.05.2026";

            // Act
            card.ExpirationDate = validExpiration;

            // Assert
            Assert.AreEqual(validExpiration, card.ExpirationDate);
        }

        [TestMethod]
        public void Id_SetValidValue_SetsCorrectValue()
        {
            // Arrange
            BankCard card = new BankCard();
            IdNumber validId = new IdNumber(123);

            // Act
            card.Id = validId;

            // Assert
            Assert.AreEqual(123, card.Id.ID);
        }
    }
}
