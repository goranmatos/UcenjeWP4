using System.Xml.Linq;

namespace UcenjeWP4.SolarKonzolna.Model
{
    internal class Location : Entitet
    {
        public string? SiteId { get; set; }
        public string? SiteName { get; set; }
        public string? InstalationTypes { get; set; }
        public string? PowerSupplyTypes { get; set; }

        public override string ToString()
        {
            return "Sifra=" + Sifra + " ,InstalationTypes=" + InstalationTypes + " ,PowerSupplyTypes=" + PowerSupplyTypes;
        }
    }
}
