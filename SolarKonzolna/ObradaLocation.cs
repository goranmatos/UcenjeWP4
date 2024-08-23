using System.Security.Cryptography;
using UcenjeWP4.SolarKonzolna.Model;
using UcenjeWP4.SolarKonzolna;

namespace UcenjeWP4.SolarKonzolna
{
    internal class ObradaLocation
    {

        public List<Location> Locations { get; set; }
        private Izbornik Izbornik;
        public ObradaLocation()
        {
            Locations = new List<Location>();

        }

        public ObradaLocation(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
        }

        public void PrikaziIzbornik()
        {

            Console.WriteLine("Izbornik za rad s InstalationTypes");
            Console.WriteLine("1. Pregled svih InstalationTypes");
            Console.WriteLine("2. Unos novog InstalationTypes");
            Console.WriteLine("3. Promjena podataka postojećeg InstalationTypes");
            Console.WriteLine("4. Brisanje InstalationTypes");
            Console.WriteLine("5. Statistika InstalationTypes");
            Console.WriteLine("6. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    Console.Clear();
                    PrikaziLokaciej();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveLokacije();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatakLokacije();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiLokaciju();
                    PrikaziIzbornik();
                    break;
                case 5:
                    PrikaziStatistikuLocation();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }

        private void PrikaziStatistikuLocation()
        {
            Console.Clear();
            Console.WriteLine("-> STATISTIKA broja Lokacija");
            Console.WriteLine("Ukupno InstalationTypes: " + Locations.Count());
            Console.WriteLine("");
        }

        private void ObrisiLokaciju()
        {
            PrikaziLokaciej();
            var odabrani = Locations[
                Pomocno.UcitajRasponBroja("Odaberi redni broj Lokacije za brisanje",
                1, Locations.Count) - 1
                ];
            if (Pomocno.UcitajBool("Sigurno obrisati " + odabrani.Sifra + " " + odabrani.SiteName + "? (DA/NE)", "da"))
            {
                Locations.Remove(odabrani);
            }
        }

        private void PromjeniPodatakLokacije()
        {
            PrikaziLokaciej();
            var odabrani = Locations[
                Pomocno.UcitajRasponBroja("Odaberi redni broj Lokacije za promjenu",
                1, Locations.Count) - 1
                ];
            odabrani.Sifra = Pomocno.UcitajRasponBroja(odabrani.Sifra, "Unesi šifru Lokacije", 1, int.MaxValue);
            odabrani.SiteId = Pomocno.UcitajString(odabrani.SiteId, "Unesi ime Locije", 50, true);

        }

        public void PrikaziLokaciej()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("popis Location u aplikaciji");
            int rb = 0;
            foreach (var p in Locations)
            {
                Console.WriteLine(p.Sifra + ". " + p.SiteId + " " + p.SiteName + " " + p.InstalationTypes);
            }
            Console.WriteLine("****************************");
        }

        private void UnosNoveLokacije()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o InstalationTypes");
            Locations.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru InstalationTypes", 1, int.MaxValue),
                SiteName = Pomocno.UcitajString("Unesi ime InstalationTypes", 50, true),

            });
        }
    }
}
