using System.Security.Cryptography;
using UcenjeWP4.SolarKonzolna.Model;
using UcenjeWP4.SolarKonzolna;

namespace UcenjeWP4.SolarKonzolna
{
    internal class ObradaInstalationTypes
    {

        public List<InstalationTypes> InstalationTypes { get; set; }

        public ObradaInstalationTypes()
        {
            InstalationTypes = new List<InstalationTypes>();

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
                    PrikaziInstalationTypes();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogPolaznika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatakInstalationTypes();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiInstalationTypes();
                    PrikaziIzbornik();
                    break;
                case 5:
                    PrikaziStatistikuInstalationTypes();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }

        private void PrikaziStatistikuInstalationTypes()
        {
            Console.Clear();
            Console.WriteLine("-> STATISTIKA InstalationTypes");
            Console.WriteLine("Ukupno InstalationTypes: " + InstalationTypes.Count());
            Console.WriteLine("");
        }

        private void ObrisiInstalationTypes()
        {
            PrikaziInstalationTypes();
            var odabrani = InstalationTypes[
                Pomocno.UcitajRasponBroja("Odaberi redni broj InstalationTypes za brisanje",
                1, InstalationTypes.Count) - 1
                ];
            if (Pomocno.UcitajBool("Sigurno obrisati " + odabrani.Sifra + " " + odabrani.Name + "? (DA/NE)", "da"))
            {
                InstalationTypes.Remove(odabrani);
            }
        }

        private void PromjeniPodatakInstalationTypes()
        {
            PrikaziInstalationTypes();
            var odabrani = InstalationTypes[
                Pomocno.UcitajRasponBroja("Odaberi redni broj InstalationTypes za promjenu",
                1, InstalationTypes.Count) - 1
                ];
            odabrani.Sifra = Pomocno.UcitajRasponBroja(odabrani.Sifra, "Unesi šifru InstalationTypes", 1, int.MaxValue);
            odabrani.Name = Pomocno.UcitajString(odabrani.Name, "Unesi ime InstalationTypes", 50, true);

        }

        public void PrikaziInstalationTypes()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("popis InstalationTypes u aplikaciji");
            int rb = 0;
            foreach (var p in InstalationTypes)
            {
                Console.WriteLine(p.Sifra + ". " + p.Name);
            }
            Console.WriteLine("****************************");
        }

        private void UnosNovogPolaznika()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o InstalationTypes");
            InstalationTypes.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru InstalationTypes", 1, int.MaxValue),
                Name = Pomocno.UcitajString("Unesi ime InstalationTypes", 50, true),

            });
        }
    }
}
