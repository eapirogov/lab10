using Microsoft.VisualStudio.TestTools.UnitTesting;



using lab10;


using System;


using System.Collections.Generic;


using System.Globalization;





namespace lab10Tests


{


    [TestClass]


    public class ExperiationComparerTests


    {


        [TestMethod]


        public void Compare_XIsNull_ShouldReturnZero()


        {


            //Arrange


            ExperiationComparer comparer = new ExperiationComparer();


            BankCard y = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);





            //Act


            int result = comparer.Compare(null, y);





            //Assert


            Assert.AreEqual(0, result);


        }





        [TestMethod]


        public void Compare_YIsNull_ShouldReturnZero()


        {


            //Arrange


            ExperiationComparer comparer = new ExperiationComparer();


            BankCard x = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);





            //Act


            int result = comparer.Compare(x, null);





            //Assert


            Assert.AreEqual(0, result);


        }





        [TestMethod]


        public void Compare_BothAreNull_ShouldReturnZero()


        {


            //Arrange


            ExperiationComparer comparer = new ExperiationComparer();


            BankCard y = new BankCard(1234, "Криштиану Роналду", "12.12.2025", 1);





            //Act


            int result = comparer.Compare(null, null);





            //Assert


            Assert.AreEqual(0, result);


        }





        [TestMethod]


        public void Compare_XDateIsEarlierThanYDate_ShouldReturnNegative()


        {


            //Arrange


            ExperiationComparer comparer = new ExperiationComparer();


            BankCard x = new BankCard(1234, "Криштиану Роналду", "01.01.2025", 1);


            BankCard y = new BankCard(5678, "Криштиану Роналду", "01.02.2025", 2);





            //Act


            int result = comparer.Compare(x, y);





            //Assert


            Assert.IsTrue(result < 0);


        }





        [TestMethod]


        public void Compare_XDateIsLaterThanYDate_ShouldReturnPositive()


        {


            //Arrange


            ExperiationComparer comparer = new ExperiationComparer();


            BankCard x = new BankCard(1234, "Криштиану Роналду", "01.02.2025", 1);


            BankCard y = new BankCard(5678, "Криштиану Роналду", "01.01.2025", 2);





            //Act


            int result = comparer.Compare(x, y);





            //Assert


            Assert.IsTrue(result > 0);


        }





        [TestMethod]


        public void Compare_DatesAreEqual_ShouldReturnZero()


        {


            //Arrange


            ExperiationComparer comparer = new ExperiationComparer();


            BankCard x = new BankCard(1234, "Криштиану Роналду", "01.01.2025", 1);


            BankCard y = new BankCard(5678, "Криштиану Роналду", "01.01.2025", 2);





            //Act


            int result = comparer.Compare(x, y);





            //Assert


            Assert.AreEqual(0, result);


        }


    }


}