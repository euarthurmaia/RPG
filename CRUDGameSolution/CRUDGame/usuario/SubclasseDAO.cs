using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class SubclasseDAO
    {
        public static string CadastrarSubclasse(Subclasse novaSubclasse)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Subclasses.Add(novaSubclasse);
                    ctx.SaveChanges();
                }
                mensagem = "Subclasse " + 
                    novaSubclasse.Descricao + " cadastrada com suceso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static List<Subclasse> ListarSubclasses()
        {
            List<Subclasse> subClasses = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    subClasses = ctx.Subclasses.OrderBy(
                        x => x.IdSubclasse).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return subClasses;
        }

        public static Subclasse ListarSubclasses(int subclasseID)
        {
            Subclasse subclasse = null;

            using (var ctx = new RPGDBEntities1())
            {
                subclasse = ctx.Subclasses.FirstOrDefault(x => x.IdSubclasse == subclasseID);
            }



            return subclasse;
        }

        public static Subclasse Remover(int idSubclasse)
        {
            Subclasse subExcluir = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    subExcluir = ctx.Subclasses.FirstOrDefault(x => x.IdSubclasse == idSubclasse);
                    ctx.Subclasses.Remove(subExcluir);
                    ctx.SaveChanges();
                }
            }
            catch
            {
                subExcluir = null;
            }

            return subExcluir;
        }

        public static string AlterarSubclasse(Subclasse novaSubclasse)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                   Subclasse subclasse = ctx.Subclasses.FirstOrDefault(x => x.IdSubclasse== novaSubclasse.IdSubclasse);
                    subclasse.Descricao = novaSubclasse.Descricao;
                    subclasse.ClasseID = novaSubclasse.ClasseID;
                    ctx.SaveChanges();
                    mensagem = "SubClasse " + novaSubclasse.Descricao +
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