// See https://aka.ms/new-console-template for more information

int Brojredova;
int Brojstupaca;

int IBrojredova = 0;
int IBrojstupaca = 0;

while (true)
{
    Console.WriteLine("Molim unesite broj redova: ");
    try
    {
        Brojredova = int.Parse(Console.ReadLine());
        if (Brojredova > 0 && Brojredova < 10)
        {
            break;
        }
        Console.WriteLine("Uneseni broj nije veći od 0 i manji od 10");
    }
    catch (Exception e)
    {
        Console.WriteLine("Niste unijeli cijeli pozitivni broj.");
    }
}

while (true)
{
    Console.WriteLine("Molim unesite broj stupaca: ");
    try
    {
        Brojstupaca = int.Parse(Console.ReadLine());
        if (Brojstupaca > 0 && Brojstupaca < 10)
        {
            break;
        }
        Console.WriteLine("Uneseni broj stupaca nije veći od 0 i manji od 10");
    }
    catch (Exception e)
    {
        Console.WriteLine("Niste unijeli cijeli pozitivni broj stupaca.");
    }
}




Console.WriteLine("********");
Console.WriteLine("Brojstupaca = {0}, Brojredova = {1}", Brojstupaca, Brojredova);
int[,] niz = new int[Brojstupaca, Brojredova];

for (int i = 1; i <= Brojredova * Brojstupaca; i++)
{
    if (IBrojredova <= Brojredova - 1)
    {
        niz[IBrojstupaca, IBrojredova++] = i;
        Console.WriteLine("niz {0},{1}={2}", IBrojstupaca, IBrojredova-1, niz[IBrojstupaca, IBrojredova-1]);
    }
    else 
    { 
    IBrojredova = 0;
    IBrojstupaca++;
    i--;
    }
    
}
