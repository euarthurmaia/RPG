using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmClasse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var queryString_ID = Request.QueryString["id"];
                var queryString_Edit = Request.QueryString["edit"];

                if (queryString_ID != null && queryString_Edit != null)
                {
                    int id = Convert.ToInt32(queryString_ID);
                    PreencherDados(id, queryString_Edit == "true");
                }

                PopularLVs();
            }
        }

        private void PreencherDados(int id, bool edit)
        {
            var classe = ClasseDAO.ListarClasses(id);
            txtDescricao.Text = classe.Descricao;

            //Verifica se iremos editar os dados ou não
            if(edit) 
            {
                //editando
                btnConfirmar.Text = "Alterar";
            }
            else
            {
                //Visualizando
                btnConfirmar.Visible = false;
                txtDescricao.Enabled = false;
            }
        }

        private void PopularLVs()
        {
            var classes = ClasseDAO.ListarClasses();
            PopularLVClasses(classes);
        }

        private void PopularLVClasses(List<Classe> classes)
        {
            lvClasses.DataSource = classes;
            lvClasses.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                //Criando uma instância da classe (objeto)
                Classe novaClasse = null;
                //Caso id seja -1, não existe uma classe para ser alterada
                int id = -1;

                if (cadastrando)
                {
                    novaClasse = new Classe();
                }
                else
                {
                    //Alterando
                    var idQuery = Request.QueryString["id"];
                    if(idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaClasse = ClasseDAO.ListarClasses(id);
                    }
                }
                //Preencher o objeto
                novaClasse.Descricao = descricao;

                string mensagem = "";
                if (cadastrando)
                {
                   mensagem = ClasseDAO.CadastrarClasse(novaClasse);
                }
                else
                {
                    mensagem = ClasseDAO.AlterarClasse(novaClasse);
                    btnConfirmar.Text = "Cadastrar";
                }
                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear uma classe!";
            }
        }

        protected void lvClasses_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idClasse = Convert.ToInt32(id);
                    Classe classeExcluida = ClasseDAO.Remover(idClasse);
                    if (classeExcluida != null)
                    {
                        lblMensagem.InnerText = "Classe " + classeExcluida.Descricao + " excluída com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Classe está sendo usada em um Subclasse!";
                    }
                }
            } else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Classes?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)                    
                {
                    this.Response.Redirect("~/Classes?id=" + id + "&edit=true");
                }
            }
            PopularLVs();
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            txtDescricao.Enabled = true;
            btnConfirmar.Text = "Cadastrar";

            txtDescricao.Text = "";
            lblMensagem.InnerText = "";
        }
    }
}