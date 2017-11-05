using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konto_bankowe
{
    class Konto
    {
        private string bank;
        private string numerKonta;
        private double saldo;
        private string imie;
        private string nazwisko;
        private int oplataZaPrzelew = 3;
        private static Random rnd = new Random();

        public Konto(string imie, string nazwisko,string bank)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            numerKonta = GenerujNumerKonta();
            this.bank = bank;
            saldo = 0.0;

        }
        public void WplatawKasie(Konto kontoOdbiory, double kwota)
        {
            kontoOdbiory.saldo += kwota;            
            
        }
        public void WplatawBankomacie(double kwota)
        {
            saldo += kwota;
        }
        public void WyplatawKaise(double kwota)
        {
            if(saldo>kwota)
            {
                saldo -= kwota;
            }
        }
        public void WyplatawBankomacie(double kwota)
        {
            if (saldo > kwota)
            {
                saldo -= kwota;
            }
            else
                Console.WriteLine("Za mało środkow na koncie");
        }
        public void Przelew(Konto kontoOdbiorcy, Konto kontoWysylajacego, double kwota)
        {
            if(kontoOdbiorcy.bank==kontoWysylajacego.bank)
            {
                if (kontoWysylajacego.saldo > kwota)
                    kontoWysylajacego.saldo -= kwota;
                    kontoOdbiorcy.saldo += kwota;
            }
            else
            {
                if (kontoWysylajacego.saldo > (kwota+oplataZaPrzelew))
                    kontoWysylajacego.saldo = kontoWysylajacego.saldo-(kwota +oplataZaPrzelew);
                    kontoOdbiorcy.saldo += kwota;

            }
        }
        public void PlatnoscKarta(double kwota)
        {
            if(saldo>kwota)
            {
                saldo -= kwota;
            }
        }
        private string GenerujNumerKonta()
        {
            string numer = "";
            //Random rnd = new Random();
            numer += rnd.Next(1, 9).ToString(); // pierwsza cyfra rozna od 0
            for (int i = 0; i < 25; i++)
            {
                numer += rnd.Next(0, 9).ToString();
            }

            return numer;
        }
        public void WypiszInfo()
        {
            Console.WriteLine("{0} {1} {2} {3} {4}", imie, nazwisko, bank, numerKonta, saldo);
        }

    }
    class KontoPrywatne : Konto
    {

    }
}
