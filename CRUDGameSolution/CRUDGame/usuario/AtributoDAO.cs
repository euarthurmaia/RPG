using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class AtributoDAO
    {
        public static List<Atributo> ListarAtributos()
        {
            List<Atributo> atributos = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    atributos = ctx.Atributoes.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return atributos;
        }

        public static Atributo ListarAtributos(int AtributoID)
        {
            Atributo atributo= null;

            using (var ctx = new RPGDBEntities1())
            {
                atributo = ctx.Atributoes.FirstOrDefault(x => x.IdAtributo== AtributoID);
            }

            return atributo;
        }

        public static string CadastrarAtributo(Atributo novoAtributo)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Atributoes.Add(novoAtributo);
                    ctx.SaveChanges();
                }
                mensagem = "Atributo " +
                    novoAtributo.Nome + " cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static string AlterarAtributo(Atributo novoAtributo)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    Atributo atributo = ctx.Atributoes.FirstOrDefault(x => x.IdAtributo== novoAtributo.IdAtributo);
                    atributo.Nome = novoAtributo.Nome;
                    atributo.Forca = novoAtributo.Forca;
                    atributo.Destreza = novoAtributo.Destreza;
                    atributo.Sabedoria= novoAtributo.Sabedoria;
                    atributo.Constituicao = novoAtributo.Constituicao;
                    atributo.Inteligencia = novoAtributo.Inteligencia;
                    atributo.Carisma = novoAtributo.Carisma;
                    ctx.SaveChanges();
                    mensagem = "Atributo " + novoAtributo.Nome +
                        " alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static Atributo Remover(int idAtributo)
        {
            Atributo AtributoExcluir = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    AtributoExcluir = ctx.Atributoes.FirstOrDefault(x => x.IdAtributo == idAtributo);
                    ctx.Atributoes.Remove(AtributoExcluir);
                    ctx.SaveChanges();
                }

            }
            catch (Exception)
            {

                AtributoExcluir = null;
            }

            return AtributoExcluir;
        }
    }
}