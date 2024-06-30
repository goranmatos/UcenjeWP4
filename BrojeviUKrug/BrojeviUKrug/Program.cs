// See https://aka.ms/new-console-template for more information

using UcenjeCS;

int BrojRedova = Pomocno.UcitajCijeliBroj("Unesi broj redova, manji ili jednak 10");
int BrojStupaca = Pomocno.UcitajCijeliBroj("Unesi broj stupaca, manji ili jednak 10");

Console.WriteLine(BrojRedova);
Console.WriteLine(BrojStupaca);

int UkupanBroj = BrojRedova * BrojStupaca;
int[,] niz = new int[BrojRedova, BrojStupaca];

int A0 = BrojStupaca - 1;
int A1 = 0;
int B0 = BrojRedova - 2;
int B1 = 0;
int RedniBroj = 1;
int i;
int j;

//popunjavanje niza "niz"
for (; ; )
{

    for (j = A0; j >= A1; j--)
    {
        i = B0 + 1;
        niz[i, j] = RedniBroj;
        RedniBroj = RedniBroj + 1;
        if (RedniBroj == UkupanBroj + 1) { break; }
    }
    if (RedniBroj == UkupanBroj + 1) { break; }

    for (i = B0; i >= B1; i--)
    {
        j = A1;
        niz[i, j] = RedniBroj;
        RedniBroj = RedniBroj + 1;
        if (RedniBroj == UkupanBroj + 1) { break; }
    }
    if (RedniBroj == UkupanBroj + 1) { break; }

    for (j = B1 + 1; j <= A0; j++)
    {
        i = B1;
        niz[i, j] = RedniBroj;
        RedniBroj = RedniBroj + 1;
        if (RedniBroj == UkupanBroj + 1) { break; }
    }
    if (RedniBroj == UkupanBroj + 1) { break; }

    for (i = A1 + 1; i <= B0; ++i)
    {
        j = A0;
        niz[i, j] = RedniBroj;
        RedniBroj = RedniBroj + 1;
        if (RedniBroj == UkupanBroj + 1) { break; }
    }
    if (RedniBroj == UkupanBroj + 1) { break; }

    A0 = A0 - 1;
    A1 = A1 + 1;
    B0 = B0 - 1;
    B1 = B1 + 1;
}
//ispisivanje niza niz

for (i = 0; i < BrojRedova; i++)
{
    Console.WriteLine("");
    Console.Write("***");
    for (j = 0; j < BrojStupaca; j++)
    {
        Console.Write(niz[i, j].ToString().PadLeft(4));
    }
    Console.Write("   ***");
}
Console.WriteLine("");