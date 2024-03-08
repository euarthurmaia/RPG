using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class ClasseDAO
    {
        public static string CadastrarClasse(Classe novaClasse)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    //Cadastrando uma nova classe
                    ctx.Classes.Add(novaClasse);
                    //Salvando as alterações no BD
                    ctx.SaveChanges();
                    mensagem = "Classe " + novaClasse.Descricao +
                        " cadastrada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        /// <summary>
        /// Retorna uma Classe de acordo com o id!
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>

        public static Classe ListarClasses(int classeID)
        {
            Classe classe = null;

            using (var ctx = new RPGDBEntities1())
            {
                classe = ctx.Classes.FirstOrDefault(x => x.IdClasse == classeID);
            }



            return classe;
        }


        /// <summary>
        /// Retorna todas as classes cadastradas!
        /// </summary>
        /// <returns></returns>


        public static List<Classe> ListarClasses()
        {
            List<Classe> classes = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    classes = ctx.Classes.OrderBy(
                        x => x.IdClasse).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return classes;
        }

        public static Classe Remover(int idClasse)
        {
            Classe classeExcluir = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    classeExcluir = ctx.Classes.FirstOrDefault(x => x.IdClasse == idClasse);
                    ctx.Classes.Remove(classeExcluir);
                    ctx.SaveChanges();
                }

            }
            catch (Exception)
            {

                classeExcluir = null;
            }

            return classeExcluir;
        }

        public static string AlterarClasse(Classe novaClasse)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    Classe classe = ctx.Classes.FirstOrDefault(x => x.IdClasse == novaClasse.IdClasse);
                    classe.Descricao = novaClasse.Descricao;
                    ctx.SaveChanges();
                    mensagem = "Classe " + novaClasse.Descricao +
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