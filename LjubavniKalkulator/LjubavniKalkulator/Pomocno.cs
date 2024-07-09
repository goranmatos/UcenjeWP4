using System;

namespace LjubavniKalkulator
{
    internal class Pomocno
    {
        public static int BrojSlovaUImenu(string Ime, char Slovo)
        {
            return Ime.Split(Slovo).Length - 1;
        }

        public static string PretvoriNizuPostotak(string BrojeviOdImenaString)
        {
            String BrojeviOdImenaStringPrivremeni = "";
            int BrojeviOdImenaPrivremeniInt;

            if (BrojeviOdImenaString.Length < 4)
            {
                if (long.Parse(BrojeviOdImenaString) <= 100) return BrojeviOdImenaString;
            }

            int y = BrojeviOdImenaString.Length / 2;
            if (BrojeviOdImenaString.Length % 2 == 0)
            {
                y = y - 1;
            }

            for (int i = 0; y >= i; i++)
            {
                //punjene novog zbrojenog broja
                if (BrojeviOdImenaString.Length != 1)
                {
                    BrojeviOdImenaPrivremeniInt = int.Parse(BrojeviOdImenaString.Substring(0, 1)) + (int.Parse(BrojeviOdImenaString.Substring(BrojeviOdImenaString.Length - 1, 1)));
                    BrojeviOdImenaStringPrivremeni = BrojeviOdImenaStringPrivremeni + BrojeviOdImenaPrivremeniInt.ToString();
                    BrojeviOdImenaString = (BrojeviOdImenaString.Remove(0, 1)).Remove((BrojeviOdImenaString.Remove(0, 1)).Length - 1, 1);
                }
                else
                {
                    BrojeviOdImenaStringPrivremeni = BrojeviOdImenaStringPrivremeni + BrojeviOdImenaString.ToString();
                }
            }
            return PretvoriNizuPostotak(BrojeviOdImenaStringPrivremeni);
        }

    }
}
