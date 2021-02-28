using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        public decimal Limit {get; set;}

        private decimal stanZadluzenia;


        public KontoLimit( string klient, decimal bilansNaStart = 0, decimal limitNaStart = 0)
        {
            konto = new Konto(klient, bilansNaStart);
            Limit = limitNaStart;
            stanZadluzenia = 0;
        }


        public decimal Bilans => konto.Bilans + (Limit - stanZadluzenia);
        public string Nazwa => konto.Nazwa;
        public string Zablokowane => throw new NotImplementedException();

        public void Wplata(decimal kwota)
        {
            throw new NotImplementedException();
        }

        public void Wyplata(decimal kwota)
        {
            throw new NotImplementedException();
        }

    }
}
