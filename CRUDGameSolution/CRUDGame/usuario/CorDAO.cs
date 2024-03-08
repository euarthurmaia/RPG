using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class CorDAO
    {

        public static string CadastrarCor(Cor novaCor)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Cores.Add(novaCor);
                    ctx.SaveChanges();
                }

                mensagem = "Cor " + novaCor.Descricao
                    + " cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu um erro: " + ex.Message;
            }

            return mensagem;
        }


        public static List<Cor> ListarCores()
        {
            List<Cor> cores = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    cores = ctx.Cores.OrderBy(
                        x => x.IdCor).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return cores;
        }



        public static Cor ListarCores(int CorID)
        {
            Cor cores = null;

            using (var ctx = new RPGDBEntities1())
            {
                cores = ctx.Cores.FirstOrDefault(x => x.IdCor == CorID);
            }



            return cores;
        }



        public static Cor Remover(int idCor)
        {
            Cor CorExcluir = null;

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    CorExcluir = ctx.Cores.FirstOrDefault(x => x.IdCor == idCor);
                    ctx.Cores.Remove(CorExcluir);
                    ctx.SaveChanges();
                }

            }
            catch (Exception)
            {
                CorExcluir = null;
            }
            return CorExcluir;
        }

        public static string AlterarCor(Cor novaCor)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    Cor cores = ctx.Cores.FirstOrDefault(x => x.IdCor == novaCor.IdCor);
                    cores.Descricao = novaCor.Descricao;
                    ctx.SaveChanges();
                    mensagem = "Cor " + novaCor.Descricao +
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