using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmAtributo : System.Web.UI.Page
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
            var atributos = AtributoDAO.ListarAtributos();
            PopularLVAtributos(atributos);
        }

        private void PopularLVAtributos(List<Atributo> atributos)
        {
            lvAtributos.DataSource = atributos;
            lvAtributos.DataBind();
        }

        private void PreencherDados(int id, bool edit)
        {
            var atributos =AtributoDAO.ListarAtributos(id);
            txtNome.Text = atributos.Nome;
            txtForca.Text = atributos.Forca.ToString();
            txtDestreza.Text = atributos.Destreza.ToString();
            txtSabedoria.Text = atributos.Sabedoria.ToString();
            txtConstituicao.Text = atributos.Constituicao.ToString();
            txtInteligencia.Text = atributos.Inteligencia.ToString();
            txtCarisma.Text = atributos.Carisma.ToString();

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
                txtForca.Enabled = false;
                txtDestreza.Enabled = false;
                txtSabedoria.Enabled = false;
                txtConstituicao.Enabled = false;
                txtInteligencia.Enabled = false;
                txtCarisma.Enabled = false;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int forca = Convert.ToInt32(txtForca.Text);
            int destreza = Convert.ToInt32(txtDestreza.Text);
            int sabedoria = Convert.ToInt32(txtSabedoria.Text);
            int constituicao = Convert.ToInt32(txtConstituicao.Text);
            int inteligencia = Convert.ToInt32(txtInteligencia.Text);
            int carisma = Convert.ToInt32(txtCarisma.Text);

            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (nome == "" || txtForca.Text == "" || txtDestreza.Text == "" || txtSabedoria.Text == "" ||
                txtConstituicao.Text == "" || txtInteligencia.Text == "" || txtCarisma.Text == "")
            {
                lblMensagem.InnerText = "Você precisa preencher todos os campos";
            }
            else if (nome != "")
            {

                Atributo novoAtributo = null;
                //Caso id seja -1, não existe uma classe para ser alterada
                int id = -1;

                if (cadastrando)
                {
                    novoAtributo = new Atributo();
                }
                else
                {
                    //Alterando
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novoAtributo = AtributoDAO.ListarAtributos(id);
                    }
                }

                novoAtributo.Nome = nome;
                novoAtributo.Forca = forca;
                novoAtributo.Destreza = destreza;
                novoAtributo.Sabedoria = sabedoria;
                novoAtributo.Constituicao = constituicao;
                novoAtributo.Inteligencia = inteligencia;
                novoAtributo.Carisma = carisma;

                string mensagem = "";


                if (cadastrando)
                {
                    mensagem = AtributoDAO.CadastrarAtributo(novoAtributo);
                }
                else
                {
                    mensagem = AtributoDAO.AlterarAtributo(novoAtributo);
                    btnConfirmar.Text = "Cadastrar";
                }



                //Limpando o campo de texto
                txtNome.Text = "";
                txtForca.Text = "";
                txtDestreza.Text = "" ;
                txtSabedoria.Text = "" ;
                txtConstituicao.Text = "" ;
                txtInteligencia.Text = "" ;
                txtCarisma.Text = "";

                lblMensagem.InnerText = mensagem;

                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear uma Aparência!";
            }
        }

        protected void lvAtributos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idAtributo = Convert.ToInt32(id);
                    Atributo AtributoExcluido = AtributoDAO.Remover(idAtributo);
                    if (AtributoExcluido != null)
                    {
                        lblMensagem.InnerText = "Atributo " + AtributoExcluido.Nome + " excluído com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Atributo está sendo usado em um Personagem!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Atributos?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Atributos?id=" + id + "&edit=true");
                }
            }
            PopularLVs();
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            txtNome.Enabled = true;
            txtForca.Enabled = true;
            txtDestreza.Enabled = true;
            txtSabedoria.Enabled = true;
            txtConstituicao.Enabled = true;
            txtInteligencia.Enabled = true;
            txtCarisma.Enabled = true;
            btnConfirmar.Text = "Cadastrar";

            txtNome.Text = "";
            txtForca.Text = "";
            txtDestreza.Text = "";
            txtSabedoria.Text = "";
            txtConstituicao.Text = "";
            txtInteligencia.Text = "";
            txtCarisma.Text = "";
            lblMensagem.InnerText = "";
        }
    }
}