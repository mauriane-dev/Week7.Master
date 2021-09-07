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
            if (Lezioni.Count() == 0)
            {
                item.LezioneID = 1;
            }
            else
            {
                item.LezioneID = Lezioni.Max(x => x.LezioneID) + 1;
            }

            var docente = RepositoryDocentiMock.Docenti.FirstOrDefault(d => d.ID == item.DocenteID);
            item.Docente = docente;
            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CorsoCodice == item.CorsoCodice);
            item.Corso = corso;

            docente.Lezioni.Add(item);
            corso.Lezioni.Add(item);

            Lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            Lezioni.Remove(item);
            return true;
        }

        public List<Lezione> GetAll()
        {
            return Lezioni.ToList();
        }

        public Lezione GetById(int id)
        {
            return GetAll().FirstOrDefault(d => d.DocenteID == id);
        }

        public Lezione Update(Lezione item)
        {
            var old = GetById(item.LezioneID);          
            old.Aula = item.Aula;
            return item;
        }
    }
}
