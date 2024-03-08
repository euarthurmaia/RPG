using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDGame
{
    public partial class Aparencia
    {

        private Cor getCorCabelo;
        private Cor getCorOlho;
        private Cor getCorPele;

        public Cor GetCorCabelo
        {
            get
            {
                getCorCabelo = CorDAO.ListarCores(CorCabelo);
                return getCorCabelo;
            }
        }

        public Cor GetCorOlho
        {
            get
            {
                getCorOlho = CorDAO.ListarCores(CorOlho);
                return getCorOlho;
            }
        }

        public Cor GetCorPele
        {
            get
            {
                getCorPele = CorDAO.ListarCores(CorPele);
                return getCorPele;
            }
        }

    }
}