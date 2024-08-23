namespace UcenjeWP4.SolarKonzolna.Model
{
    internal class InstalationTypes : Entitet
    {
        public string? Name { get; set; }
        public override string ToString()
        {
            return "Sifra=" + Sifra + " ,Naziv=" + Name;
        }
    }

}
