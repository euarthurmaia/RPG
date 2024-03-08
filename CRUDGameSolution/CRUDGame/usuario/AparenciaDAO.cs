using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class AparenciaDAO
    {
        public static List<Aparencia> ListarAparencias()
        {
            List<Aparencia> aparencia = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    aparencia = ctx.Aparencias.OrderBy(
                        x => x.IdAparencia).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return aparencia;
        }

        public static string CadastrarAparencia(Aparencia novaAparencia)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Aparencias.Add(novaAparencia);
                    ctx.SaveChanges();
                }
                mensagem = "Aparência " +
                    novaAparencia.Nome + " cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static Aparencia ListarAparencias(int aparenciaID)
        {
            Aparencia aparencia = null;

            using (var ctx = new RPGDBEntities1())
            {
                aparencia = ctx.Aparencias.FirstOrDefault(x => x.IdAparencia == aparenciaID);
            }

            return aparencia;
        }

        public static Aparencia Remover(int idAparencia)
        {
            Aparencia AparenciaExcluir = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    AparenciaExcluir = ctx.Aparencias.FirstOrDefault(x => x.IdAparencia == idAparencia);
                    ctx.Aparencias.Remove(AparenciaExcluir);
                    ctx.SaveChanges();
                }

            }
            catch (Exception)
            {

                AparenciaExcluir = null;
            }

            return AparenciaExcluir;
        }

        public static string AlterarAparencia(Aparencia novaAparencia)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    Aparencia aparencia = ctx.Aparencias.FirstOrDefault(x => x.IdAparencia == novaAparencia.IdAparencia);
                    aparencia.Nome = novaAparencia.Nome;
                    aparencia.Peso = novaAparencia.Peso;
                    aparencia.Altura = novaAparencia.Altura;
                    aparencia.EstiloCabelo = novaAparencia.EstiloCabelo;
                    aparencia.CorCabelo = novaAparencia.CorCabelo;
                    aparencia.CorOlho = novaAparencia.CorOlho;
                    aparencia.CorPele = novaAparencia.CorPele;
                    ctx.SaveChanges();
                    mensagem = "Aparência " + novaAparencia.Nome +
                        " alterada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }
    }
}