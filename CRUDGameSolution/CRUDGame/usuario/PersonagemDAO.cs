using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class PersonagemDAO
    {
        public static string CadastrarPersonagem(Personagem novoPersonagem)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Personagens.Add(novoPersonagem);
                    ctx.SaveChanges();
                }
                mensagem = "Personagem " +
                    novoPersonagem.Nome + " cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static Personagem ListarPersonagens(int personagemID)
        {
            Personagem personagem = null;

            using (var ctx = new RPGDBEntities1())
            {
                personagem = ctx.Personagens.FirstOrDefault(x => x.IdPersonagem == personagemID);
            }

            return personagem;
        }

        public static List<Personagem> ListarPersonagens()
        {
            List<Personagem> personagens = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    personagens= ctx.Personagens.OrderBy(
                        x => x.IdPersonagem).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return personagens;
        }

        public static string AlterarPersonagem(Personagem novoPersonagem)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities1 ctx = new RPGDBEntities1())
                {
                    Personagem personagem = ctx.Personagens.FirstOrDefault(x => x.IdPersonagem == novoPersonagem.IdPersonagem);
                    personagem.Nome = novoPersonagem.Nome;
                    personagem.DataNasc = novoPersonagem.DataNasc;
                    personagem.Nivel = novoPersonagem.Nivel;
                    personagem.Sexo = novoPersonagem.Sexo;
                    personagem.RacaID = novoPersonagem.RacaID;
                    personagem.SubclasseID = novoPersonagem.SubclasseID;
                    personagem.AparenciaID = novoPersonagem.AparenciaID;
                    personagem.AtributoID = novoPersonagem.AtributoID;
                    personagem.HabilidadeID = novoPersonagem.HabilidadeID;
                    ctx.SaveChanges();
                    mensagem = "Personagem " + novoPersonagem.Nome +
                        " alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static Personagem Remover(int PersonagemID)
        {
            Personagem PersonagemExcluir = null;
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    PersonagemExcluir = ctx.Personagens.FirstOrDefault(x => x.IdPersonagem == PersonagemID);
                    ctx.Personagens.Remove(PersonagemExcluir);
                    ctx.SaveChanges();
                }

            }
            catch (Exception)
            {

                PersonagemExcluir = null;
            }

            return PersonagemExcluir;
        }
    }
}