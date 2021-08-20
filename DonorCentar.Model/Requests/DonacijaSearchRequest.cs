using System;
using System.Collections.Generic;
using System.Text;

namespace DonorCentar.Model.Requests
{
    public class DonacijaSearchRequest
    {
        public string Tip { get; set; }
        public string Vrsta { get; set; }
        public int? PrimalacId { get; set; }
    }
}
