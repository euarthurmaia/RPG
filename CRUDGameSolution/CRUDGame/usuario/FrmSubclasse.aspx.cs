using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmSubclasse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<Classe> classes = ClasseDAO.ListarClasses();
                PreencherDDLClasse(classes);

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
            var subclasse = SubclasseDAO.ListarSubclasses(id);
            txtDescricao.Text = subclasse.Descricao;
            DDLClasse.SelectedValue = subclasse.ClasseID.ToString();

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
                DDLClasse.Enabled = false;
            }
        }

        private void PopularLVs()
        {
            var subclasses = SubclasseDAO.ListarSubclasses();
            lvSubclasses.DataSource = subclasses;
            lvSubclasses.DataBind();
        }

        private void PreencherDDLClasse(List<Classe> classes)
        {
            DDLClasse.DataSource = classes;
            DDLClasse.DataTextField = "Descricao";
            DDLClasse.DataValueField = "IdClasse";
            DDLClasse.DataBind();
            DDLClasse.Items.Insert(0, "Selecione..");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            int index = DDLClasse.SelectedIndex;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao == "")
            {
                lblMensagem.InnerText = "Você precisa nomear uma subclasse!";
            }
            else if (index == 0)
            {
                lblMensagem.InnerText =
                    "Você precisa selecionar uma classe!";
            }
            else if (descricao != "")
            {
                Subclasse novaSubclasse = null;
                int id = -1;


                if (cadastrando)
                {
                    novaSubclasse = new Subclasse();
                }
                else
                {
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaSubclasse = SubclasseDAO.ListarSubclasses(id);
                    }
                }
                

                novaSubclasse.Descricao = descricao;

                int idClasse = Convert.ToInt32( DDLClasse.SelectedValue);
                novaSubclasse.ClasseID = idClasse;



                string mensagem = "";
                if (cadastrando)
                {
                    mensagem = SubclasseDAO.CadastrarSubclasse(novaSubclasse);
                }
                else
                {
                    mensagem = SubclasseDAO.AlterarSubclasse(novaSubclasse);
                    btnConfirmar.Text = "Cadastrar";
                }

                //Limpando o campo de texto
                txtDescricao.Text = "";
                DDLClasse.SelectedIndex = 0;

                lblMensagem.InnerText = mensagem;

                PopularLVs();
            }
        }

        protected void lvSubclasses_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idSubclasse = Convert.ToInt32(id);
                    Subclasse subExcluida = SubclasseDAO.Remover(idSubclasse);
                    if (subExcluida != null)
                    {
                        lblMensagem.InnerText = "Subclasse " + subExcluida.Descricao + " excluída com sucesso!";
                    }
                    else
                    {
                        lblMensagem.InnerText = "Subclasse está sendo usada em um Personagem!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/SubClasses?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/SubClasses?id=" + id + "&edit=true");
                }
            }
            PopularLVs();
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            txtDescricao.Enabled = true;
            DDLClasse.Enabled = true;
            btnConfirmar.Text = "Cadastrar";

            txtDescricao.Text = "";
            DDLClasse.SelectedIndex = 0;
            lblMensagem.InnerText = "";

        }
    }
}