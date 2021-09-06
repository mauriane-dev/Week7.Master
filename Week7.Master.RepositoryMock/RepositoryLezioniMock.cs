using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryLezioniMock : IRepositoryLezioni
    {
        public static List<Lezione> Lezioni = new List<Lezione>();


        public Lezione Add(Lezione item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Lezione item)
        {
            throw new NotImplementedException();
        }

        public List<Lezione> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lezione GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Lezione Update(Lezione item)
        {
            throw new NotImplementedException();
        }
    }
}
