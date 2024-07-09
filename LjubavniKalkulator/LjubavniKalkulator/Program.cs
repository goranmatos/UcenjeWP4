// See https://aka.ms/new-console-template for more information
using LjubavniKalkulator;
string Ime1;
string Ime2;
string Ime;
string BrojeviOdImenaString = "";

Console.WriteLine("Unijeti prvo ime: ");
Ime1 = Console.ReadLine().Trim();
Console.WriteLine("Unijeti drugo ime: ");
Ime2 = Console.ReadLine().Trim();
Ime = Ime1.ToLower() + Ime2.ToLower();

for (int i = 0; i < Ime.Length; i++)
{    
    BrojeviOdImenaString = BrojeviOdImenaString + Pomocno.BrojSlovaUImenu(Ime, Ime[i]);   
}

Console.WriteLine("{0} i {1} se vole: {2} %", Ime1, Ime2, Pomocno.PretvoriNizuPostotak(BrojeviOdImenaString));
