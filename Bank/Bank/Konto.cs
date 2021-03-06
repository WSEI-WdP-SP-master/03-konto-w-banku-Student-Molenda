﻿using System;

namespace Bank
{
    public class Konto
    {
        private string klient;  //nazwa klienta
        private decimal bilans;  //aktualny stan środków na koncie
        private bool zablokowane = false; //stan konta

        public string Nazwa => klient; // property get
        public decimal Bilans => bilans;
        public bool Zablokowane => zablokowane;


        // --- ctor's

        //public Konto() { }

        public Konto(string klient, decimal bilansNaStart = 0)
        {
            this.klient = klient;
            if (bilansNaStart < 0)
                bilans = 0;
            else
                bilans = bilansNaStart;
        }

        // --- metody
        public void Wplata( decimal kwota )
        {
            if (this.Zablokowane)
                throw new ArgumentException("konto zablokowane");

            if (kwota < 0)
                throw new ArgumentOutOfRangeException("ujemna kwota");

            bilans += kwota;
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentOutOfRangeException("ujemna kwota");

            if (kwota > bilans)
                throw new ArgumentException("kwota wypłaty przekracza bilans");

            bilans -= kwota;
        }

        public void BlokujKonto() => zablokowane = true;
        //{
        //    zablokowane = true;
        //}

        public void OdblokujKonto() => zablokowane = false;



    }
}
