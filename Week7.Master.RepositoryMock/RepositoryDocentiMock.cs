using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{ID=1, Nome="Mario", Cognome="Rossi", Email="mario@mail.it", Telefono="3331234567"},
            new Docente{ID=2, Nome="Giuseppe", Cognome="Bianchi", Email="giuseppe@mail.it", Telefono="3331434567"}
        };

        public Docente Add(Docente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Docente item)
        {
            throw new NotImplementedException();
        }

        public List<Docente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Docente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Docente Update(Docente item)
        {
            throw new NotImplementedException();
        }
    }
}
