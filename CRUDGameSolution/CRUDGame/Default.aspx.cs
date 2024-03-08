using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                div_Cadastro.Visible = false;
            }
        }

        protected void btnCriarUsuario_Click(object sender, EventArgs e)
        {
            div_Cadastro.Visible = true;
            div_Login.Visible = false;
        }

        [Obsolete]

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            var user = txtUsuario.Value;
            var pass = txtSenha.Value;

            if (user != null && pass != null)
            {
                var passCript =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "SHA1");
                Usuario userAutenticado = UsuarioDAO.Autenticar(user, passCript);

                if (userAutenticado != null)
                {
                    //Registrá-lo como válido
                    FormsAuthentication.SetAuthCookie(userAutenticado.Nome, true);

                    LogAcesso log = new LogAcesso();
                    log.DataHoraAcesso = DateTime.Now;
                    log.UsuarioId = userAutenticado.IdUsuario;

                    LogAcessoDAO.RegistrarAcesso(log);

                    Response.Redirect("~/RPG");

                }
                else
                {
                    var criarUsuario = UsuarioDAO.VerificarExistencia(user);
                    if (criarUsuario != null)
                    {
                        lblMensagemLogin.Text = "Senha incorreta!";
                    }
                    else
                    {
                        lblMensagemLogin.Text = "Usuário não cadastrado!";
                    }
                }
            }
            else
            {
                lblMensagemLogin.Text = "Todos os campos precisam ser preenchidos!";
            }
            txtUsuario.Value = "";
            txtSenha.Value = "";
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            div_Cadastro.Visible = false;
            div_Login.Visible = true;
        }

        [Obsolete]

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var nome = txtNomeCadastro.Text;
            var usuario = txtUsuarioCadastro.Text;
            var senha = txtSenhaCadastro.Text;
            var confirmarsenha = txtConfirmarSenhaCadastro.Text;
            var datanascimento = txtDataNascCadastro.Text;

            if(nome != "" && usuario != "" && senha != "" && confirmarsenha != "" && datanascimento != "")
            {
                if(senha == confirmarsenha)
                {
                    var senhacript = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "SHA1"); ;
                    Usuario UserCadastrar = new Usuario();
                    UserCadastrar.Nome = nome;
                    UserCadastrar.Login = usuario;
                    UserCadastrar.Senha = senhacript;
                    UserCadastrar.DataNasc = Convert.ToDateTime(datanascimento);

                    UsuarioDAO.CadastrarUsuario(UserCadastrar);

                    txtNomeCadastro.Text = "";
                    txtUsuarioCadastro.Text = "";
                    txtSenhaCadastro.Text = "";
                    txtConfirmarSenhaCadastro.Text = "";
                    txtDataNascCadastro.Text = "";
                    lblMensagemCadastro.Text = "Usuário " + UserCadastrar.Login + " cadastrado com sucesso!";
                }
                else
                {
                    lblMensagemCadastro.Text = "As senhas precisam ser iguais!";
                }
            }
            else
            {
                lblMensagemCadastro.Text = "É preciso preencher todos os campos!";
            }
        }
    }
}