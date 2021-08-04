using AutoMapper;
using DonorCentar.WebAPI.Database;
using DonorCentar.WebAPI.Filters;
using DonorCentar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Korisnici = DonorCentar.Model.Korisnik;
using Microsoft.EntityFrameworkCore;

namespace DonorCentar.WebAPI.Services
{
    public class KorisniciService : IKorisniciService
    {
        public BazaPodataka Context { get; set; }
        protected readonly IMapper _mapper;

        public KorisniciService(BazaPodataka context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }


        public IList<Korisnici> GetAll(KorisniciSearchRequest search)
        {
            var query = Context.Korisnik.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                search.ImePrezime = search.ImePrezime.ToLower();
                query = query.Where(x => x.LicniPodaci.Ime.ToLower().Contains(search.ImePrezime) || x.LicniPodaci.Prezime.ToLower().Contains(search.ImePrezime) || (x.LicniPodaci.Ime + " " + x.LicniPodaci.Prezime).ToLower().Contains(search.ImePrezime));

            }

            if(!string.IsNullOrWhiteSpace(search?.TipKorisnika) && search.TipKorisnika!="Svi")
            {
                query = query.Where(x => x.TipKorisnika.Tip == search.TipKorisnika);
            }

            query = query.Include(x => x.Grad.Kanton);
            query = query.Include(x => x.LicniPodaci);
            query = query.Include(x => x.TipKorisnika);
            query = query.Include(x => x.LoginPodaci);

            var entities = query.ToList();
            

            var result = _mapper.Map<IList<Model.Korisnik>>(entities);



            return result;
        }

        public Korisnici GetById(int id)
        {
            var query = Context.Korisnik.AsQueryable();

            query = query.Include(x => x.Grad.Kanton);
            query = query.Include(x => x.LicniPodaci);
            query = query.Include(x => x.TipKorisnika);



            return _mapper.Map<Model.Korisnik>(query.FirstOrDefault(x=>x.Id==id));
        }

        public Model.Korisnik Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);
            Context.Add(entity);



            entity.LoginPodaci.Sifra = HashSifru(request.LoginPodaci.Sifra);
                


        

            Context.SaveChanges();

            
           

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = Context.Korisnik.Where(x=>x.Id==id).Include(x=>x.LoginPodaci).Include(x => x.LicniPodaci).FirstOrDefault();
            entity.GradId = request.GradId;
            entity.TipKorisnikaId = request.TipKorisnikaId;
            entity.LicniPodaci.Adresa = request.LicniPodaci.Adresa;
            entity.LicniPodaci.BrojTelefona = request.LicniPodaci.BrojTelefona;
            entity.LicniPodaci.Email = request.LicniPodaci.Email;
       
            entity.LicniPodaci.Ime = request.LicniPodaci.Ime;

            entity.LicniPodaci.Prezime = request.LicniPodaci.Prezime;

            if(request.LicniPodaci.ProfilnaSlika!=null)
            entity.LicniPodaci.ProfilnaSlika = request.LicniPodaci.ProfilnaSlika;

            entity.LoginPodaci.KorisnickoIme = request.LoginPodaci.KorisnickoIme;
            entity.LoginPodaci.Sifra = HashSifru(request.LoginPodaci.Sifra);




            Context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }

     

        

        public static string HashSifru(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}








