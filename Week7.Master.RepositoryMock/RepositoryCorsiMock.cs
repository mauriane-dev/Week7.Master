using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryCorsiMock : IRepositoryCorsi
    {
        //Dati finti
        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso{CorsoCodice="C-01", Nome="Pre-Academy I", Descrizione="Corso base c# livello1"},
            new Corso{CorsoCodice="C-02", Nome="Academy I", Descrizione="Corso base c# livello2"}
        };


        public Corso Add(Corso item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Corso item)
        {
            throw new NotImplementedException();
        }

        public List<Corso> GetAll()
        {
            return Corsi;
        }

        public Corso GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Corso Update(Corso item)
        {
            throw new NotImplementedException();
        }
    }
}
