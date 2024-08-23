using System.Security.Cryptography;
using UcenjeWP4.SolarKonzolna.Model;
using UcenjeWP4.SolarKonzolna;
using System.Text.RegularExpressions;

namespace UcenjeWP4.SolarKonzolna
{
    internal class ObradaProduction
    {

        public List<Production> Productions { get; set; }
        private Izbornik Izbornik;
        public ObradaProduction()
        {
            Productions = new List<Production>();

        }
        public ObradaProduction(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
        }



        public void PrikaziIzbornik()
        {

            Console.WriteLine("Izbornik za rad s Production");
            Console.WriteLine("1. Pregled svih Production");
            Console.WriteLine("2. Unos novog Production");
            Console.WriteLine("3. Promjena podataka postojećeg Production");
            Console.WriteLine("4. Brisanje Production");
            Console.WriteLine("5. Statistika Production");
            Console.WriteLine("6. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    Console.Clear();
                    PrikaziProduction();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogProduction();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniProduction();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiProduction();
                    PrikaziIzbornik();
                    break;
                case 5:
                    PrikaziStatistikuProduction();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }

        private void PrikaziStatistikuProduction()
        {
            Console.Clear();
            Console.WriteLine("-> STATISTIKA Production");
            Console.WriteLine("Ukupno Production: " + Productions.Count());
            Console.WriteLine("");
        }

        private void ObrisiProduction()
        {
            PrikaziProduction();
            var odabrani = Productions[
                Pomocno.UcitajRasponBroja("Odaberi redni broj InstalationTypes za brisanje",
                1, Productions.Count) - 1
                ];
            if (Pomocno.UcitajBool("Sigurno obrisati " + odabrani.Sifra + " " + odabrani.Consumption24 + "? (DA/NE)", "da"))
            {
                Productions.Remove(odabrani);
            }
        }

        private void PromjeniProduction()
        {
            PrikaziProduction();
            var odabrani = Productions[
                Pomocno.UcitajRasponBroja("Odaberi redni broj InstalationTypes za promjenu",
                1, Productions.Count) - 1
                ];
            odabrani.Sifra = Pomocno.UcitajRasponBroja(odabrani.Sifra, "Unesi šifru Production", 1, int.MaxValue);
            odabrani.SolarProduction24 = Pomocno.UcitajRasponBroja(odabrani.Consumption24, "Unesi Solar production",0, 10000);

        }

        public void PrikaziProduction()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Production u aplikaciji");
            int rb = 0;
            foreach (var p in Productions)
            {
                Console.WriteLine(p.Sifra + ". " + p.Location + " " + p.Consumption24 + " " + p.SolarProduction24 + " " + p.Date);
            }
            Console.WriteLine("****************************");
        }

        private void UnosNovogProduction()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o InstalationTypes");
            Productions.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru InstalationTypes", 1, int.MaxValue),
             //   Name = Pomocno.UcitajString("Unesi ime InstalationTypes", 50, true),

            });
        }
    }
}
