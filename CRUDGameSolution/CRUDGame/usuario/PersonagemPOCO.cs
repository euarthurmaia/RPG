using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDGame
{
    public partial class Personagem
    {
        private Raca getRaca;
        private Subclasse getSubclasse;
        private Aparencia getAparencia;
        private Atributo getAtributo;
        private Habilidade getHabilidade;

        public Raca GetRaca
        {
            get
            {
                getRaca = RacaDAO.ListarRacas(RacaID);
                return getRaca;
            }
        }

        public Subclasse GetSubclasse
        {
            get
            {
                getSubclasse = SubclasseDAO.ListarSubclasses(SubclasseID);
                return getSubclasse;
            }
        }
        public Aparencia GetAparencia
        {
            get
            {
                getAparencia = AparenciaDAO.ListarAparencias(AparenciaID);
                return getAparencia;
            }
        }

        public Atributo GetAtributo
        {
            get
            {
                getAtributo = AtributoDAO.ListarAtributos(AtributoID);
                return getAtributo;
            }
        }

        public Habilidade GetHabilidade
        {
            get
            {
                getHabilidade = HabilidadeDAO.ListarHabilidades(HabilidadeID);
                return getHabilidade;
            }
        }

    }
}