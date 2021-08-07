using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.WebAPI.Database
{
    public class Notifikacija
    {
        public int NotifikacijaId { get; set; }
        public TipNotifikacije TipNotifikacije { get; set; }
        public int TipNotifikacijeId { get; set; }
        public Korisnik ZaKorisnik { get; set; }
        public int ZaKorisnikId { get; set; }
        public Korisnik OdKorisnik { get; set; }
        public int OdKorisnikId { get; set; }
        public int TipKorisnikaId { get; set; }
        public DateTime Vrijeme { get; set; }
        public Donacija Donacija { get; set; }
        public int? DonacijaId { get; set; }
       
    }
}
