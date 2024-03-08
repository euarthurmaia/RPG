using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDGame
{
    public partial class Subclasse
    {
        //public Classe GetClasse()
        //{
        //    Classe classe = ClasseDAO.ListarClasses(ClasseID);
        //    return classe;
        //}


        private Classe getClasse;

        public Classe GetClasse
        {
            get {
                getClasse = ClasseDAO.ListarClasses(ClasseID);
                return getClasse;
            }
        }



    }
}