using System.Reflection.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UcenjeWP4.KonzolnaAplikacija.Model;


namespace UcenjeWP4.KonzolnaAplikacija
{
    internal class Izbornik
    {

        public ObradaSmjer ObradaSmjer { get; set; }  // da ne mora raditi instancu u konstruktoru
        public ObradaPolaznik ObradaPolaznik { get; set; }
        public ObradaGrupa ObradaGrupa { get; set; }

        public Izbornik()
        {
            Pomocno.DEV = false;
            ObradaSmjer = new ObradaSmjer();
            ObradaPolaznik = new ObradaPolaznik();
            ObradaGrupa = new ObradaGrupa(this);
            UcitajPodatke();
            PrikaziIzbornik();
        }

        private void UcitajPodatke()
        {
            string docPath =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(Path.Combine(docPath, "smjerovi.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "smjerovi.json"));
                ObradaSmjer.Smjerovi = JsonConvert.DeserializeObject<List<Smjer>>(file.ReadToEnd());
                file.Close();
            }
            if (File.Exists(Path.Combine(docPath, "polaznici.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "polaznici.json"));
                ObradaPolaznik.Polaznici = JsonConvert.DeserializeObject<List<Polaznik>>(file.ReadToEnd());
                file.Close();
            }
//            if (File.Exists(Path.Combine(docPath, "grupe.json")))
//            {
//                StreamReader file = File.OpenText(Path.Combine(docPath, "grupe.json"));
//                ObradaGrupa.Grupe = JsonConvert.DeserializeObject<List<Grupa>>(file.ReadToEnd());
//                file.Close();
//
//           }
        }

        private void PrikaziIzbornik()
        {
            PozdravnaPoruka();
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Smjerovi");
            Console.WriteLine("2. Polaznici");
            Console.WriteLine("3. Grupe");
            Console.WriteLine("4. Izlaz iz programa");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {

            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ObradaSmjer.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaPolaznik.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaGrupa.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.WriteLine("Hvala na korištenju aplikacije, doviđenja!");
                    SpremiPodatke();
                    break;
            }
        }

        private void SpremiPodatke()
        {
            string docPath =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (Pomocno.DEV)
            {
                return;
            }
            StreamWriter outputFileSmjerovi = new StreamWriter(Path.Combine(docPath, "smjerovi.json"));
            outputFileSmjerovi.WriteLine(JsonConvert.SerializeObject(ObradaSmjer.Smjerovi));
            outputFileSmjerovi.Close();

            StreamWriter outputFilPolaznici = new StreamWriter(Path.Combine(docPath, "polaznici.json"));
            outputFilPolaznici.WriteLine(JsonConvert.SerializeObject(ObradaPolaznik.Polaznici));
            outputFilPolaznici.Close();

            StreamWriter outputFilGrupe = new StreamWriter(Path.Combine(docPath, "grupe.json"));
            outputFilGrupe.WriteLine(JsonConvert.SerializeObject(ObradaGrupa.Grupe));
            outputFilGrupe.Close();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("*** Edunova Console App v 1.0 ***");
            Console.WriteLine("*********************************");
        }
    }
}
