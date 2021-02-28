using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoPlus : Konto
    {
        private decimal limit;
        public decimal Limit
        {
            get => limit;
            set // ToDo: kiedy możliwa zmiana limitu debetowego
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("limit musi byc nieujemny");

                limit = value; 
            }
        }

        public decimal DostepneSrodki { get; private set; }

        // ctor's
        public KontoPlus( string  klient, decimal bilansNaStart = 0, decimal limitNaStart = 0) : base(klient, bilansNaStart)
        {
            //limit = limitNaStart;
            Limit = limitNaStart;
            DostepneSrodki = bilansNaStart + limitNaStart;
        }

        new public void Wyplata( decimal kwota)
        {
            if( DostepneSrodki < kwota )
                throw new ArgumentException("kwota wypłaty przekracza dostepne środki");

            if (kwota <= Bilans)
            {
                base.Wyplata(kwota);
                DostepneSrodki = Bilans + Limit;
            }
            else // musimy się zadłużyć
            {
                var kwotaZadluzenia = kwota - Bilans;
                base.Wyplata(Bilans); // zchodzimy do zera z rzeczywistymi środkami
                DostepneSrodki = Bilans + (Limit - kwotaZadluzenia);
                BlokujKonto();
            }

        }


    }
}
