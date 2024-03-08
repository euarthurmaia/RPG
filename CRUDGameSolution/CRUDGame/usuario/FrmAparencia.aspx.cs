using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmAparencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularDDLs();

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
            var aparencias = AparenciaDAO.ListarAparencias(id);
            txtNome.Text = aparencias.Nome;
            txtPeso.Text = aparencias.Peso.ToString();
            txtAltura.Text = aparencias.Altura.ToString();
            txtEstiloCabelo.Text = aparencias.EstiloCabelo;
            DDLCorCabelo.SelectedValue = aparencias.CorCabelo.ToString();
            DDLCorOlho.SelectedValue = aparencias.CorOlho.ToString();
            DDLCorPele.SelectedValue = aparencias.CorPele.ToString();

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
                txtNome.Enabled = false;
                txtPeso.Enabled = false;
                txtAltura.Enabled = false;
                txtEstiloCabelo.Enabled = false;
                DDLCorCabelo.Enabled = false;
                DDLCorOlho.Enabled = false;
                DDLCorPele.Enabled = false;
            }
        }

        private void PopularLVs()
        {
            var aparencias = AparenciaDAO.ListarAparencias();
            PopularLVAparencias(aparencias);
        }

        private void PopularLVAparencias(List<Aparencia> aparencias)
        {
            lvAparencias.DataSource = aparencias;
            lvAparencias.DataBind();
        }

        private void PopularDDLs()
        {
            try
            {
                List<Cor> cor = CorDAO.ListarCores();

                PopularDDLCorCabelo(cor);
                PopularDDlCorOlho(cor);
                PopularDDlCorPele(cor);

            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }

        private void PopularDDlCorPele(List<Cor> cor)
        {
            DDLCorPele.DataSource = cor;
            DDLCorPele.DataTextField = "Descricao";
            DDLCorPele.DataValueField = "IdCor";
            DDLCorPele.DataBind();
            DDLCorPele.Items.Insert(0, "Selecione..");
        }

        private void PopularDDlCorOlho(List<Cor> cor)
        {
            DDLCorOlho.DataSource = cor;
            DDLCorOlho.DataTextField = "Descricao";
            DDLCorOlho.DataValueField = "IdCor";
            DDLCorOlho.DataBind();
            DDLCorOlho.Items.Insert(0, "Selecione..");
        }

        private void PopularDDLCorCabelo(List<Cor> cor)
        {
            DDLCorCabelo.DataSource = cor;
            DDLCorCabelo.DataTextField = "Descricao";
            DDLCorCabelo.DataValueField = "IdCor";
            DDLCorCabelo.DataBind();
            DDLCorCabelo.Items.Insert(0, "Selecione..");
        }



        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            decimal peso = Convert.ToDecimal(txtPeso.Text);
            decimal altura = Convert.ToDecimal(txtAltura.Text);
            string estilocabelo = txtEstiloCabelo.Text;
            int indexCabelo = DDLCorCabelo.SelectedIndex;
            int indexOlho = DDLCorOlho.SelectedIndex;
            int indexPele = DDLCorPele.SelectedIndex;

            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (nome == "")
            {
                lblMensagem.InnerText = "Você precisa nomear uma Cor!";
            }
            else if (indexCabelo == 0 || indexOlho == 0 || indexPele == 0)
            {
                lblMensagem.InnerText =
                    "Você precisa selecionar todos os dados!";
            }
            else if (nome != "")
            {

                Aparencia novaAparencia = null;
                //Caso id seja -1, não existe uma classe para ser alterada
                int id = -1;

                if (cadastrando)
                {
                    novaAparencia = new Aparencia();
                }
                else
                {
                    //Alterando
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaAparencia = AparenciaDAO.ListarAparencias(id);
                    }
                }

                novaAparencia.Nome = nome;
                novaAparencia.Peso = peso;
                novaAparencia.Altura = altura;
                novaAparencia.EstiloCabelo = estilocabelo;

                int idCorCabelo = Convert.ToInt32(DDLCorCabelo.SelectedValue);
                novaAparencia.CorCabelo = idCorCabelo;

                int idCorOlho = Convert.ToInt32(DDLCorOlho.SelectedValue);
                novaAparencia.CorOlho = idCorOlho;

                int idCorPele = Convert.ToInt32(DDLCorPele.SelectedValue);
                novaAparencia.CorPele = idCorPele;


                string mensagem = "";


                if (cadastrando)
                {
                    mensagem = AparenciaDAO.CadastrarAparencia(novaAparencia);
                }
                else
                {
                    mensagem = AparenciaDAO.AlterarAparencia(novaAparencia);
                    btnConfirmar.Text = "Cadastrar";
                }



                //Limpando o campo de texto
                txtNome.Text = "";
                txtPeso.Text = "";
                txtAltura.Text = "";
                txtEstiloCabelo.Text = "";
                DDLCorCabelo.SelectedIndex = 0;
                DDLCorOlho.SelectedIndex = 0;
                DDLCorPele.SelectedIndex = 0;

                lblMensagem.InnerText = mensagem;

                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear uma Aparência!";
            }
        }
        protected void lvAparencias_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idAparencia = Convert.ToInt32(id);
                    Aparencia AparenciaExcluida = AparenciaDAO.Remover(idAparencia);
                    if (AparenciaExcluida != null)
                    {
                        lblMensagem.InnerText = "Aparência " + AparenciaExcluida.Nome + " excluída com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Aparência está sendo usada em um Personagem!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Aparencias?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Aparencias?id=" + id + "&edit=true");
                }
            }
            PopularLVs();
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {

            txtNome.Enabled = true;
            txtPeso.Enabled = true;
            txtAltura.Enabled = true;
            txtEstiloCabelo.Enabled = true;
            DDLCorCabelo.Enabled = true;
            DDLCorOlho.Enabled = true;
            DDLCorPele.Enabled = true;
            btnConfirmar.Text = "Cadastrar";
            btnConfirmar.Visible = true;

            txtNome.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            txtEstiloCabelo.Text = "";
            DDLCorCabelo.SelectedIndex = 0;
            DDLCorOlho.SelectedIndex = 0;
            DDLCorPele.SelectedIndex = 0;
            lblMensagem.InnerText = "";

        }
    }
}