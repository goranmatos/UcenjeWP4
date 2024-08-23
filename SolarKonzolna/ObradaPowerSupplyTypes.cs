using System.Security.Cryptography;
using UcenjeWP4.SolarKonzolna.Model;
using UcenjeWP4.SolarKonzolna;

namespace UcenjeWP4.SolarKonzolna
{
    internal class ObradaPowerSupplyTypes
    {

        public List<PowerSupplyTypes> PowerSupplyTypes { get; set; }

        public ObradaPowerSupplyTypes()
        {
            PowerSupplyTypes = new List<PowerSupplyTypes>();

        }

        public void PrikaziIzbornik()
        {

            Console.WriteLine("Izbornik za rad s Tipovima PowerSupply");
            Console.WriteLine("1. Pregled svih PowerSupplyTypesa");
            Console.WriteLine("2. Unos novog PowerSupply");
            Console.WriteLine("3. Promjena podataka postojećeg PowerSupplyTypes");
            Console.WriteLine("4. Brisanje PowerSupplyTypes");
            Console.WriteLine("5. Statistika PowerSupplyTypes");
            Console.WriteLine("6. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    Console.Clear();
                    PrikaziPowerSupplyTypesa();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogPowerSupply();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPowerSupply();
                    PrikaziIzbornik();
                    break;
                case 4:
                    //      ObrisiPolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    PrikaziStatistikuPolaznika();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }

        private void PrikaziStatistikuPolaznika()
        {
           // int ukupnoPowerSupplyTypes = PowerSupplyTypes.Count();

            Console.Clear();
            Console.WriteLine("-> STATISTIKA PowerSupplyTypes");
            Console.WriteLine("Ukupno PowerSupplyTypes: " + PowerSupplyTypes.Count());
            Console.WriteLine("");
        }

        //       private void ObrisiPolaznika()
        //       {
        // PrikaziPolaznike();
        //var PowerSupplyTypes = PowerSupplyTypes[
        //        Pomocno.UcitajRasponBroja("Odaberi redni broj polaznika za brisanje",
        //               1, PowerSupplyTypes.Count) - 1
        //               ];
        //           if (Pomocno.UcitajBool("Sigurno obrisati " + PowerSupplyTypes.Sifra + " " + PowerSupplyTypes.Naziv + "? (DA/NE)", "da"))
        //           {
        //       PowerSupplyTypes.Remove(PowerSupplyTypes);
        //   }
        //    }

        private void PromjeniPowerSupply()
        {
            PrikaziPowerSupplyTypesa();
            var odabrani = PowerSupplyTypes[
              Pomocno.UcitajRasponBroja("Odaberi redni broj PowerSupply za promjenu",
                     1, PowerSupplyTypes.Count) - 1
                     ];
            odabrani.Sifra = Pomocno.UcitajRasponBroja(odabrani.Sifra, "Unesi šifru PowerSupply", 1, int.MaxValue);
            odabrani.Naziv = Pomocno.UcitajString(odabrani.Naziv, "Unesi ime PowerSupply", 50, true);

        }

        public void PrikaziPowerSupplyTypesa()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Dostupni PowerSupplyTypesa u aplikaciji");
            int rb = 0;
            foreach (var p in PowerSupplyTypes)
            {
                Console.WriteLine(p.Sifra + ". " + p.Naziv); // prepisati metodu toString
            }
            Console.WriteLine("****************************");
        }

        private void UnosNovogPowerSupply()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o PowerSupply");
            PowerSupplyTypes.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru PowerSupplyTypesa", 1, int.MaxValue),
                Naziv = Pomocno.UcitajString("Unesi ime PowerSupplyTypesa", 50, true),

            });
        }
    }
}
