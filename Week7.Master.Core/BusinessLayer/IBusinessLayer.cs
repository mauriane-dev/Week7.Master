using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Aggiungere "l'elenco" delle funzionalità richieste dalla traccia

        #region Funzionalità Corsi
        //Visualizza corsi
        public List<Corso> GetAllCorsi();

        //Inserire un nuovo corso
        public string InserisciNuovoCorso(Corso newCorso);
        #endregion

    }
}
