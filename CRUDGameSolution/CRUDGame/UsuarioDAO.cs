using System;
using System.Linq;

namespace CRUDGame
{
    public class UsuarioDAO
    {
        public static Usuario Autenticar(string user, string passCript)
        {
            Usuario userAutenticado = null;

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    userAutenticado = ctx.Usuarios.FirstOrDefault(
                            x => x.Login == user && x.Senha == passCript
                        );
                }
            }
            catch (Exception ex)
            {
                userAutenticado = null;
            }

            return userAutenticado;
        }

        public static Usuario VerificarExistencia(string user)
        {
            Usuario criarUsuario = null;

            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    criarUsuario = ctx.Usuarios.FirstOrDefault(
                            x => x.Login == user
                        );
                }
            }
            catch (Exception ex)
            {
                criarUsuario = null;
            }

            return criarUsuario;
        }

        public static void CadastrarUsuario(Usuario userCadastrar)
        {
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.Usuarios.Add(userCadastrar);
                    ctx.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}