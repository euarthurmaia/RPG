using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmHabilidade : System.Web.UI.Page
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
            var habilidade = HabilidadeDAO.ListarHabilidades(id);
            txtDescricao.Text = habilidade.Descricao;

            //Verifica se iremos editar os dados ou não
            if (edit)
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
            var habilidades = HabilidadeDAO.ListarHabilidades();
            PopularLVHabilidades(habilidades);
        }

        private void PopularLVHabilidades(object habilidades)
        {
            lvHabilidades.DataSource = habilidades;
            lvHabilidades.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                //Criando uma instância da classe (objeto)
                Habilidade novaHabilidade = null;
                int id = -1;
                //Preencher o objeto
                if (cadastrando)
                {
                    novaHabilidade = new Habilidade();
                }
                else
                {
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaHabilidade = HabilidadeDAO.ListarHabilidades(id);
                    }
                }
                novaHabilidade.Descricao = descricao;



                string mensagem = "";
                if (cadastrando)
                {
                    mensagem = HabilidadeDAO.CadastrarHabilidade(novaHabilidade);
                }
                else
                {
                    mensagem = HabilidadeDAO.AlterarHabilidade(novaHabilidade);
                    btnConfirmar.Text = "Cadastrar";
                }

                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear uma Habilidade!";
            }
        }

        protected void lvClasses_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idHabilidade = Convert.ToInt32(id);
                    Habilidade HabilidadeExcluida = HabilidadeDAO.Remover(idHabilidade);
                    if (HabilidadeExcluida != null)
                    {
                        lblMensagem.InnerText = "Habilidade " + HabilidadeExcluida.Descricao + " excluída com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Habilidade está sendo usada em um personagem!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Habilidades?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Habilidades?id=" + id + "&edit=true");
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