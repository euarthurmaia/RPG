using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmRaca : System.Web.UI.Page
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
            var racas = RacaDAO.ListarRacas();
            PopularLVRacas(racas);
        }

        private void PopularLVRacas(List<Raca> racas)
        {
            lvRacas.DataSource = racas;
            lvRacas.DataBind();
        }

        private void PreencherDados(int id, bool edit)
        {
            var racas = RacaDAO.ListarRacas(id);
            txtDescricao.Text = racas.Descricao;

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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                Raca novaRaca = null;
                int id = -1;

                if (cadastrando)
                {
                    novaRaca = new Raca();
                }
                else
                {
                    //Alterando
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaRaca = RacaDAO.ListarRacas(id);
                    }
                }
                //Preencher o objeto
                novaRaca.Descricao = descricao;

                string mensagem = "";
                if (cadastrando)
                {
                    mensagem = RacaDAO.CadastrarRaca(novaRaca);
                }
                else
                {
                    mensagem = RacaDAO.AlterarRaca(novaRaca);
                    btnConfirmar.Text = "Cadastrar";
                }
                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear uma raça!";
            }
        }

        protected void lvRacas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idRaca = Convert.ToInt32(id);
                    Raca RacaExcluida = RacaDAO.Remover(idRaca);
                    if (RacaExcluida != null)
                    {
                        lblMensagem.InnerText = "Raça " + RacaExcluida.Descricao + " excluída com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Raça está sendo usada em um personagem!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Racas?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Racas?id=" + id + "&edit=true");
                }
            }
            PopularLVs();
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            txtDescricao.Enabled = true;
            btnConfirmar.Text = "Confirmar";

            txtDescricao.Text = "";
            lblMensagem.InnerText = "";
        }
    }
}