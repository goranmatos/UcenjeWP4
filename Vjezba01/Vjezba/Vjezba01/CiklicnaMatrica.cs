

namespace Vjezba01
{
    internal class CiklicnaMatrica
    {
        public static void Izvedi()
        {
            Console.WriteLine("Upiši broj redova: ");
            int redovi = int.Parse(Console.ReadLine());
            Console.WriteLine("Upiši broj stupaca: ");
            int stupci = int.Parse(Console.ReadLine());
            int[,] matrica = stvorimatricu(redovi, stupci);
            ispisi(matrica);


        }

        static int[,] stvorimatricu(int redovi, int stupci)
        {
            int[,] mreza = new int[redovi, stupci];
            int pocetak = 1;
            int pocetakreda = redovi - 1;
            int pocetakstupca = stupci - 1;
            int krajreda = 0;
            int krajstupca = 0;
            int desno = 0;
            int gore = 1;
            int ljevo = 2;
            int dole = 3;
            int smjer = desno;

            while (pocetak <= redovi * stupci)
            {
                if (smjer == desno)
                {
                    for (int i = pocetakstupca; i >= krajstupca; i--)
                    {
                        mreza[pocetakreda, i] = pocetak++;
                    }
                    pocetakreda--;
                    smjer = gore;
                }
                else if (smjer == gore)
                {
                    for (int i = pocetakreda; i >= krajreda; i--)
                    {
                        mreza[i, krajstupca] = pocetak++;
                    }
                    krajstupca++;
                    smjer = ljevo;
                }
                else if (smjer == ljevo)
                {
                    for (int i = krajstupca; i <= pocetakstupca; i++)
                    {
                        mreza[krajreda, i] = pocetak++;
                    }
                    krajreda++;
                    smjer = dole;

                }
                else if (smjer == dole)
                {
                    for (int i = krajreda; i <= pocetakreda; i++)
                    {
                        mreza[i, pocetakstupca] = pocetak++;
                    }
                    pocetakstupca--;
                    smjer = desno;
                }
            }
            return mreza;
        }

        static void ispisi(int[,] mreza)
        {
            int redovi = mreza.GetLength(2);
            int stupci = mreza.GetLength(1);
            for (int i = 0; i < redovi; i++)
            {
                for (int j = 0; j < stupci; j++)
                {
                    Console.Write(mreza[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}