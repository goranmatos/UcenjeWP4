using UcenjeWP4.KonzolnaAplikacija.Model;

namespace UcenjeWP4.KonzolnaAplikacija
{
    internal class ObradaGrupa
    {

        public List<Grupa> Grupe { get; set; }
        private Izbornik Izbornik;

        public ObradaGrupa()
        {
            Grupe = new List<Grupa>();

        }
        public ObradaGrupa(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s grupama");
            Console.WriteLine("1. Pregled svih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena podataka postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. Brisanje polaznika iz grupe");
            Console.WriteLine("6. Statistika grupe");
            Console.WriteLine("7. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 7))
            {
                case 1:
                    Console.Clear();
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveGrupe();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatkeGrupe();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiGrupu();
                    PrikaziIzbornik();
                    break;
                case 5:
                    ObrisiPolaznikaIzGrupe();
                    PrikaziIzbornik();
                    break;
                case 6:
                    PrikaziStatistikuGrupe();
                    PrikaziIzbornik();
                    break;
                case 7:
                    Console.Clear();
                    break;
            }
        }

        private void ObrisiPolaznikaIzGrupe()
        {
            PrikaziGrupe();


            // PrikaziPolaznike();
            var odabranaGrupa = Grupe[
                Pomocno.UcitajRasponBroja("Odaberi redni broj grupe iz kojeg želite obrisati polaznika",
                1, Grupe.Count) - 1
                ];

            var odabraniPolaznikIzGrupe = odabranaGrupa.Polaznici[
                    Pomocno.UcitajRasponBroja("Odaberi redni broj polaznika kojeg želite obirsati iz grupe " + odabranaGrupa.Naziv,
                    1, odabranaGrupa.Polaznici.Count) - 1
                    ];
            Console.WriteLine("Odabrana grupa je:" + odabraniPolaznikIzGrupe.Ime + " " + odabraniPolaznikIzGrupe.Prezime);
            if (Pomocno.UcitajBool("Sigurno želite obrisati polaznika " + odabraniPolaznikIzGrupe.Ime + " " + odabraniPolaznikIzGrupe.Prezime + " iz grupe " + odabranaGrupa.Naziv + "? (DA/NE)", "da"))
            {
                var indexGrupe = -1;
                var indexPolaznika = -1;

                indexGrupe = Grupe.IndexOf(odabranaGrupa);
                indexPolaznika = odabranaGrupa.Polaznici.IndexOf(odabraniPolaznikIzGrupe);

                //Grupe[0].Polaznici.RemoveAt(1); brisanje polaznika iz grupe putem indexa
                Grupe[indexGrupe].Polaznici.RemoveAt(indexPolaznika); //brisanje polaznika iz grupe putem indexa
                                                                      //Grupe[Grupe.IndexOf(odabranaGrupa)].Polaznici.RemoveAt(Grupe[Grupe.IndexOf(odabranaGrupa)].Polaznici.IndexOf(odabraniPolaznikIzGrupe));

            }
        }

        private void ObrisiGrupu()
        {
            PrikaziGrupe();
            var g = Grupe[
                Pomocno.UcitajRasponBroja("Odaberi redni broj grupe za brisanje", 1, Grupe.Count) - 1
                ];
            if (Pomocno.UcitajBool("Sigurno obrisati " + g.Naziv + "? (DA/NE)", "da"))
            {
                Grupe.Remove(g);
            }
        }
        private void PromjeniPodatkeGrupe()
        {
            PrikaziGrupe();
            var g = Grupe[
                Pomocno.UcitajRasponBroja("Odaberi redni broj grupe za promjenu", 1, Grupe.Count) - 1
                ];
            var originalSifra = g.Sifra;

            int sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru grupe (" + originalSifra + ")", 1, int.MaxValue);
            while (sifra != originalSifra && Grupe.Exists(p => p.Sifra == sifra))
            {               
                Console.WriteLine("\tTa šifra već postoji za neku grupu!");
                sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru grupe (" + originalSifra + ")", 1, int.MaxValue);
            }
            g.Sifra = sifra;


            g.Naziv = Pomocno.UcitajString(g.Naziv, "Unesi naziv grupe", 50, true);
            //smjer
            Izbornik.ObradaSmjer.PrikaziSmjerove();

            g.Smjer = Izbornik.ObradaSmjer.Smjerovi[
                Pomocno.UcitajRasponBroja("Odaberi redni broj smjera", 1, Izbornik.ObradaSmjer.Smjerovi.Count) - 1];

            g.Predavac = Pomocno.UcitajString(g.Predavac, "Unesi ime i prezime predavača", 50, true);
            g.MaksimalnoPolaznika = Pomocno.UcitajRasponBroja(g.MaksimalnoPolaznika, "Unesi maksimalno polaznika", 1, 30);

            // polaznici
            g.Polaznici = UcitajPolaznike();

        }

        private void PrikaziGrupe()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Grupe u aplikaciji");
            int rb = 0, rbp;

            if (Grupe.Count == 0)
            {
                Console.WriteLine("***Nema definiranih grupa***");
            }
            foreach (var g in Grupe)
            {

                Console.WriteLine(++rb + ". " + g.Naziv + " (" + g.Smjer?.Naziv + "), " + g.Polaznici?.Count + " polaznika"); // prepisati metodu toString
                rbp = 0;
                g.Polaznici.Sort();
                foreach (var p in g.Polaznici)
                {
                    Console.WriteLine("\t" + ++rbp + ". " + p.Ime + " " + p.Prezime);
                }
            }
            Console.WriteLine("****************************");
        }
        private void UnosNoveGrupe()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o grupi");

            Grupa g = new Grupa();
            g.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru grupe", 1, int.MaxValue);
            g.Naziv = Pomocno.UcitajString("Unesi naziv grupe", 50, true);
            //smjer
            Izbornik.ObradaSmjer.PrikaziSmjerove();

            g.Smjer = Izbornik.ObradaSmjer.Smjerovi[
                Pomocno.UcitajRasponBroja("Odaberi redni broj smjera", 1, Izbornik.ObradaSmjer.Smjerovi.Count) - 1];

            g.Predavac = Pomocno.UcitajString("Unesi ime i prezime predavača", 50, true);
            g.MaksimalnoPolaznika = Pomocno.UcitajRasponBroja("Unesi maksimalno polaznika", 1, 30);

            // polaznici
            g.Polaznici = UcitajPolaznike();
            Grupe.Add(g);
        }
        private List<Polaznik> UcitajPolaznike()
        {
            List<Polaznik> lista = new List<Polaznik>();
            while (Pomocno.UcitajBool("Za unos polaznika unesi DA", "da"))
            {
                Izbornik.ObradaPolaznik.PrikaziPolaznike();
                lista.Add(
                    Izbornik.ObradaPolaznik.Polaznici[
                        Pomocno.UcitajRasponBroja("Odaberi redni broj polaznika", 1,
                        Izbornik.ObradaPolaznik.Polaznici.Count) - 1
                        ]
                    );
            }

            return lista;
        }
        private void PrikaziStatistikuGrupe()
        {
            if (Grupe == null || !Grupe.Any())
            {
                Console.WriteLine("\nNema podataka za prikaz!");
                PrikaziIzbornik();
                return;
            }

            int ukupnoPolaznika = Grupe.Sum(g => g.Polaznici?.Count ?? 0);
            float prosjecanBrojPolaznika = Grupe.Any() ? (float)Grupe.Average(g => g.Polaznici?.Count ?? 0) : 0;
            float ukupniPrihod = Grupe.Sum(g => (g.Polaznici?.Count ?? 0) * (g.Smjer?.Cijena ?? 0));
            float prosjecanPrihodPoPolazniku = ukupniPrihod / ukupnoPolaznika;
            var datumi = Grupe.Where(g => g.Smjer?.IzvodiSeOd.HasValue ?? false).Select(g => g.Smjer.IzvodiSeOd.Value).ToList();

            DateTime najranijiDatum = datumi.Any() ? datumi.Min() : DateTime.MinValue;
            DateTime najkasnijiDatum = datumi.Any() ? datumi.Max() : DateTime.MaxValue;
            TimeSpan razlikaDatuma = najkasnijiDatum - najranijiDatum;

            Console.Clear();
            Console.WriteLine("-> STATISTIKA GRUPA");
            Console.WriteLine("Ukupno broj grupa: " + Grupe.Count);
            Console.WriteLine("Ukupno polaznika u svim grupama: " + ukupnoPolaznika);
            Console.WriteLine("Prosječan broj polaznika: " + prosjecanBrojPolaznika);
            Console.WriteLine("Ukupan iznos prihoda po smjerovima: " + ukupniPrihod);
            Console.WriteLine("Prosječan iznos prihoda po polazniku: " + prosjecanPrihodPoPolazniku);
            Console.WriteLine("Razlika između najranijeg i najkasnijeg datuma: " + razlikaDatuma.Days + " dana");
            Console.WriteLine("");

        }
    }
}
