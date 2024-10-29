using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Dto
{
    internal class EmployeeDto
    {
        public int IdPracownika { get; set; } 
        public string Login { get; set; }
        public string Osokod { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string RegionPion { get; set; }
        public string LokalizacjaDzial { get; set; }
        public string FormatSklepu { get; set; }
        public string Stanowisko { get; set; }
        public string MiejsceStruktura { get; set; }
        public string StatusPracownika { get; set; }
        public string DataZmianyStanowiska { get; set; }
        public string DataZwolnienia { get; set; }
        public string StatusZatrudnienia { get; set; }
        public int? IdPracownikPrzelozony { get; set; }
        public string NazwiskoPrzelozony { get; set; }
        public string ImiePrzelozony { get; set; }
        public string Etat { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
