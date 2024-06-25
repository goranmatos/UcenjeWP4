// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Molim unesite broj redova: ");
//int Brojredova = int.Parse(Console.ReadLine());
//Console.WriteLine("Molim unesite broj stupaca: ");
//int Brojstupaca = int.Parse(Console.ReadLine());
//Console.WriteLine("********");
//Console.WriteLine("Brojredova = {0}, Brojstupaca = {1}", Brojredova, Brojstupaca);
//int[,] niz = new int[Brojredova, Brojstupaca];
//Console.WriteLine(niz[1,1]);

var Vrijeme = DateTime.Now;

int[,] niz = new int[10, 10];

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        niz[j, i] = (i + 1) * (j + 1);
        if (niz[j, i] < 10)
        {
            Console.Write("  " + niz[j, i] + " ");
        }
        else if ((niz[j, i] >= 10) && (niz[j, i] < 100))
        {
            Console.Write(" " + niz[j, i] + " ");
        }
        else if (niz[j, i] == 100)
        {
            Console.Write("" + niz[j, i] + " ");
        }
    }
    Console.WriteLine("\r");
}

Console.WriteLine("\r");
Console.WriteLine("\r");
Console.WriteLine(DateTime.Now - Vrijeme);
