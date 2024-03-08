using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmCor : System.Web.UI.Page
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

        private void PopularLVs()
        {
            var cores = CorDAO.ListarCores();
            PopularLVsCores(cores);
        }

        private void PopularLVsCores(List<Cor> cores)
        {
            lvCores.DataSource = cores;
            lvCores.DataBind();
        }

        private void PreencherDados(int id, bool edit)
        {
            var cor = CorDAO.ListarCores(id);
            txtDescricao.Text = cor.Descricao;

            if (edit)
            {
                btnConfirmar.Text = "Alterar";
            }
            else
            {
                btnConfirmar.Visible = false;
                txtDescricao.Enabled = false;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                Cor novaCor = null;
                int id = -1;

                if (cadastrando)
                {
                    novaCor = new Cor();
                }
                else
                {
                    //Alterando
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaCor = CorDAO.ListarCores(id);
                    }
                }
                //Preencher o objeto
                novaCor.Descricao = descricao;

                string mensagem = "";
                if (cadastrando)
                {
                    mensagem = CorDAO.CadastrarCor(novaCor);
                }
                else
                {
                    mensagem = CorDAO.AlterarCor(novaCor);
                    btnConfirmar.Text = "Cadastrar";
                }
                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear uma Cor!";
            }
        }

        protected void lvCores_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idCor = Convert.ToInt32(id);
                    Cor CorExcluida = CorDAO.Remover(idCor);
                    if (CorExcluida != null)
                    {
                        lblMensagem.InnerText = "Cor " + CorExcluida.Descricao + " excluída com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Cor está sendo usada em uma Aparência!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Cores?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Cores?id=" + id + "&edit=true");
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