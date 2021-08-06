using AutoMapper;
using DonorCentar.Model.Requests;
using DonorCentar.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.WebAPI.Services
{


    public class ObavijestService : BaseCRUDService<Model.Obavijest, Database.Obavijest, ObavijestSearchRequest, ObavijestInsertRequest, ObavijestUpdateRequest>, IObavijestService
    {
        public ObavijestService(BazaPodataka context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}