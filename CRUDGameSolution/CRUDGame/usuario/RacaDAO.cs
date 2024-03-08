using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class RacaDAO
    {
        /// <summary>
        /// Cadastra um nova raça no banco de dados.
        /// </summary>
        /// <param name="novaRaca">Objeto do tipo Raca.</param>
        /// <returns>Mensagem com informações sobre a operação.</returns>
        public static string CadastrarRaca(Raca novaRaca)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Racas.Add(novaRaca);
                    ctx.SaveChanges();
                }

                mensagem = "Raça " + novaRaca.Descricao
                    + " cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu um erro: " + ex.Message;
            }

            return mensagem;
        }

        public static List<Raca> ListarRacas()
        {
            List<Raca> racas = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    racas = ctx.Racas.OrderBy(
                        x => x.IdRaca).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return racas;
        }

        public static Raca ListarRacas(int RacaID)
        {
            Raca racas = null;

            using (var ctx = new RPGDBEntities1())
            {
                racas = ctx.Racas.FirstOrDefault(x => x.IdRaca == RacaID);
            }



            return racas;
        }

        public static Raca Remover(int idRaca)
        {
            Raca RacaExcluir = null;

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    RacaExcluir = ctx.Racas.FirstOrDefault(x => x.IdRaca == idRaca);
                    ctx.Racas.Remove(RacaExcluir);
                    ctx.SaveChanges();
                }

            }
            catch (Exception )
            {
                RacaExcluir = null;
            }
            return RacaExcluir;
        }

        public static string AlterarRaca(Raca novaRaca)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    Raca racas = ctx.Racas.FirstOrDefault(x => x.IdRaca == novaRaca.IdRaca);
                    racas.Descricao = novaRaca.Descricao;
                    ctx.SaveChanges();
                    mensagem = "Raça " + novaRaca.Descricao +
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