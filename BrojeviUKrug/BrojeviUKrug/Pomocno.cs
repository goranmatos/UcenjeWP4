
namespace UcenjeCS
{
    internal class Pomocno
    {
        public static int UcitajCijeliBroj(string poruka)
        {
            while (true)
            {
                try
                {
                    Console.Write(poruka + ": ");

                    int a = int.Parse(Console.ReadLine());
                    if (a <= 10 && a >= 1) return a;
                }

                catch // i ne mora se staviti Exception
                {
                    Console.WriteLine("Pogreška prilikom unosa, unos mora biti cijeli broj !");
                }
            }
        }
    }
}
