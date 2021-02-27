using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Konstruktor_JedenParametr_NazwaKlienta()
        {
            // Arrange
            string nazwaKlienta = "molenda";

            // Act
            Konto k = new Konto(nazwaKlienta);

            // Assert
            Assert.AreEqual(nazwaKlienta, k.Nazwa);
        }

        [TestMethod]
        public void Konstruktor_JedenParametr_Bilans_na_zero()
        {
            //Act
            Konto k = new Konto("xxx");

            //Assert
            Assert.AreEqual(0, k.Bilans);
        }

        [TestMethod]
        public void Konstruktor_DwaArgumenty_Bilans_OK()
        {
            decimal kwotaStartowa = 1000;
            Konto k = new Konto("xxx", kwotaStartowa);
            Assert.AreEqual(kwotaStartowa, k.Bilans);
        }



        [TestMethod]
        public void Konstruktor_JedenArgument_Konto_Odblokowane_na_starcie()
        {
            Konto k = new Konto("xxx");
            Assert.AreEqual(false, k.Zablokowane);
        }

        [TestMethod]
        public void Konstruktor_DwaArgumenty_Konto_Odblokowane_na_starcie()
        {
            Konto k = new Konto("xxx", 150);
            Assert.AreEqual(false, k.Zablokowane);
        }

        [DataTestMethod]
        [DataRow(100, 1000)]
        [DataRow(0, 500)]
        [DataRow(1000, 100)]
        public void Wplata_Kwota_nieujemna_Bilans_OK(double kwotaStartowa, double kwotaWplaty)
        {
            Konto k = new Konto("xxx", (decimal)kwotaStartowa);
            var stanKontaPrzedWplata = k.Bilans;

            k.Wplata( (decimal)kwotaWplaty );

            Assert.AreEqual( stanKontaPrzedWplata + (decimal)kwotaWplaty, k.Bilans);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Wplata_Kwota_ujemna_Wyjatek_ArgumentOutOfRangeException()
        {
            var kwotaWplaty = -100m;
            Konto k = new Konto("xxx", 200);
            k.Wplata(kwotaWplaty);
        }


    }
}
