﻿// See https://aka.ms/new-console-template for more information
using LjubavniKalkulator;
string Ime1="";
string Ime2="";
string Ime = "AnaVoliMilovanaITakoNekolikoPuta";
int[] BrojeviOdImena;
string BrojeviOdImenaString = "";

Console.WriteLine("Molim unijeti imena čiji zbroj znamenaka je manji od 19. u sljedećoj inačici će biti dorađena aplikacija.");

while (Ime.Length > 19)
{
    Console.WriteLine("Unijeti prvo ime: ");
    Ime1 = Console.ReadLine();
    Console.WriteLine("Unijeti drugo ime: ");
    Ime2 = Console.ReadLine();
    Ime = Ime1.ToLower().Trim() + Ime2.ToLower().Trim();
}
BrojeviOdImena = new int[Ime.Length];
for (int i = 0; i < Ime.Length; i++)
{
    BrojeviOdImena[i] = Pomocno.BrojSlovaUImenu(Ime, Ime[i]);
    BrojeviOdImenaString = BrojeviOdImenaString + BrojeviOdImena[i];
}

Console.WriteLine("{0} I {1} se vole: {2} %", Ime1,Ime2, Pomocno.PretvoriNizuPostotak(BrojeviOdImenaString));