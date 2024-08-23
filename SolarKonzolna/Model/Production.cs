namespace UcenjeWP4.SolarKonzolna.Model
{
    internal class Production : Entitet
    {

        public string? Location { get; set; }
        public int? Consumption24 { get; set; }
        public int? SolarProduction24 { get; set; }
        public DateTime? Date { get; set; }


    }
}
