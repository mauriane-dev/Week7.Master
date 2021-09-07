using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryEF.RepositoryEF
{
    public class RepositoryLezioniEF : IRepositoryLezioni
    {
        public Lezione Add(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Lezione> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(x => x.Corso).Include(x => x.Docente).ToList();
            }
        }

        public Lezione GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(x => x.Corso).Include(x => x.Docente).FirstOrDefault(l => l.LezioneID == id);
            }
        }

        public Lezione Update(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
