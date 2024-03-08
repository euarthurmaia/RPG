using System;

namespace CRUDGame
{
    public class LogAcessoDAO
    {
        public static void RegistrarAcesso(LogAcesso log)
        {
            try
            {
                using (var ctx = new RPGDBEntities1())
                {
                    ctx.LogAcessoes.Add(log);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}