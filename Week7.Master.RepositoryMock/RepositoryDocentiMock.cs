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
