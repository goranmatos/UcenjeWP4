using System.Reflection.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UcenjeWP4.SolarKonzolna.Model;


namespace UcenjeWP4.SolarKonzolna
{
    internal class Izbornik
    {

        public ObradaInstalationTypes ObradaInstalationTypes { get; set; }
        public ObradaLocation ObradaLocation { get; set; }
        public ObradaProduction ObradaProduction { get; set; }
        public ObradaPowerSupplyTypes ObradaPowerSupplyTypes { get; set; }

        public Izbornik()
        {

            ObradaInstalationTypes = new ObradaInstalationTypes();
            ObradaLocation = new ObradaLocation(this);
            ObradaProduction = new ObradaProduction();
            ObradaPowerSupplyTypes = new ObradaPowerSupplyTypes();
            UcitajPodatke();
            PrikaziIzbornik();
        }

        private void UcitajPodatke()
        {
            string docPath =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(Path.Combine(docPath, "PowerSupplyTypes.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "PowerSupplyTypes.json"));
                ObradaPowerSupplyTypes.PowerSupplyTypes = JsonConvert.DeserializeObject<List<PowerSupplyTypes>>(file.ReadToEnd());
                file.Close();
            }
            if (File.Exists(Path.Combine(docPath, "polaznici.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "InstalationTypes.json"));
                ObradaInstalationTypes.InstalationTypes = JsonConvert.DeserializeObject<List<InstalationTypes>>(file.ReadToEnd());
                file.Close();
            }
            if (File.Exists(Path.Combine(docPath, "Production.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Production.json"));
                ObradaProduction.Productions = JsonConvert.DeserializeObject<List<Production>>(file.ReadToEnd());
                file.Close();
            }
            if (File.Exists(Path.Combine(docPath, "Location.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Location.json"));
                ObradaLocation.Locations = JsonConvert.DeserializeObject<List<Location>>(file.ReadToEnd());
                file.Close();
            }
        }

        private void PrikaziIzbornik()
        {
            PozdravnaPoruka();
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. PowerSupplyTypes");
            Console.WriteLine("2. Location");
            Console.WriteLine("3. InstalationTypes");
            Console.WriteLine("4. Production");
            Console.WriteLine("5. Izlaz iz programa");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {

            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ObradaPowerSupplyTypes.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaLocation.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaInstalationTypes.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.Clear();
                    ObradaProduction.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Hvala na korištenju aplikacije, doviđenja!");
                    SpremiPodatke();
                    break;
            }
        }

        private void SpremiPodatke()
        {
            string docPath =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outputFilePowerSupplyTypes = new StreamWriter(Path.Combine(docPath, "PowerSupplyTypes.json"));
            outputFilePowerSupplyTypes.WriteLine(JsonConvert.SerializeObject(ObradaPowerSupplyTypes.PowerSupplyTypes));
            outputFilePowerSupplyTypes.Close();

            StreamWriter outputFileInstalationTypes = new StreamWriter(Path.Combine(docPath, "InstalationTypes.json"));
            outputFileInstalationTypes.WriteLine(JsonConvert.SerializeObject(ObradaInstalationTypes.InstalationTypes));
            outputFileInstalationTypes.Close();

            StreamWriter outputFileProduction = new StreamWriter(Path.Combine(docPath, "Production.json"));
            outputFileProduction.WriteLine(JsonConvert.SerializeObject(ObradaProduction.Productions));
            outputFileProduction.Close();

            StreamWriter outputFileLocation = new StreamWriter(Path.Combine(docPath, "Location.json"));
            outputFileLocation.WriteLine(JsonConvert.SerializeObject(ObradaLocation.Locations));
            outputFileLocation.Close();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("***  Goran Console App v 1.0  ***");
            Console.WriteLine("*********************************");
        }
    }
}
