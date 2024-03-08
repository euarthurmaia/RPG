using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmPersonagem : System.Web.UI.Page
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
            var personagens = PersonagemDAO.ListarPersonagens(id);
            txtNome.Text = personagens.Nome;
            txtDataNasc.Text = personagens.DataNasc.ToString("yyyy-MM-dd");
            txtNivel.Text = personagens.Nivel.ToString();
            txtSexo.Text = personagens.Sexo;
            ddlRaca.SelectedValue = personagens.RacaID.ToString();
            ddlSubclasse.SelectedValue = personagens.SubclasseID.ToString();
            ddlAparencia.SelectedValue = personagens.AparenciaID.ToString();
            ddlAtributo.SelectedValue = personagens.AtributoID.ToString();
            ddlHabilidade.SelectedValue = personagens.HabilidadeID.ToString();


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
                txtDataNasc.Enabled = false;
                txtNivel.Enabled = false;
                txtSexo.Enabled = false;
                ddlRaca.Enabled = false;
                ddlSubclasse.Enabled = false;
                ddlAparencia.Enabled = false;
                ddlAtributo.Enabled = false;
                ddlHabilidade.Enabled = false;

            }
        }

        private void PopularDDLs()
        {
            try
            {
                List<Raca> racas = RacaDAO.ListarRacas();
                List<Subclasse> subClasses = SubclasseDAO.ListarSubclasses();
                List<Aparencia> aparencias = AparenciaDAO.ListarAparencias();
                List<Atributo> atributos = AtributoDAO.ListarAtributos();
                List<Habilidade> habilidades = HabilidadeDAO.ListarHabilidades();

                PopularDDLRaca(racas);
                PopularDDlSubclasse(subClasses);
                PopularDDlAparencia(aparencias);
                PopularDDlAtributo(atributos);
                PopularDDLHabilidades(habilidades);

            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }

        private void PopularDDLHabilidades(List<Habilidade> habilidades)
        {
            ddlHabilidade.DataSource = habilidades;
            ddlHabilidade.DataTextField = "Descricao";
            ddlHabilidade.DataValueField = "IdHabilidade";
            ddlHabilidade.DataBind();
            ddlHabilidade.Items.Insert(0, "Selecione..");
        }

        private void PopularDDlAtributo(List<Atributo> atributos)
        {
            ddlAtributo.DataSource = atributos;
            ddlAtributo.DataTextField = "Nome";
            ddlAtributo.DataValueField = "IdAtributo";
            ddlAtributo.DataBind();
            ddlAtributo.Items.Insert(0, "Selecione..");
        }

        private void PopularDDlAparencia(List<Aparencia> aparencias)
        {
            ddlAparencia.DataSource = aparencias;
            ddlAparencia.DataTextField = "Nome";
            ddlAparencia.DataValueField = "IdAparencia";
            ddlAparencia.DataBind();
            ddlAparencia.Items.Insert(0, "Selecione..");
        }

        private void PopularDDlSubclasse(List<Subclasse> subClasses)
        {
            ddlSubclasse.DataSource = subClasses;
            ddlSubclasse.DataTextField = "Descricao";
            ddlSubclasse.DataValueField = "IdSubclasse";
            ddlSubclasse.DataBind();
            ddlSubclasse.Items.Insert(0, "Selecione..");
        }

        private void PopularDDLRaca(List<Raca> racas)
        {
            ddlRaca.DataSource = racas;
            ddlRaca.DataTextField = "Descricao";
            ddlRaca.DataValueField = "IdRaca";
            ddlRaca.DataBind();
            ddlRaca.Items.Insert(0, "Selecione..");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string sexo = txtSexo.Text;
            var datanascimento = txtDataNasc.Text;
            var nivel = txtNivel.Text;
            int indexRaca = ddlRaca.SelectedIndex;
            int indexSubClasse = ddlSubclasse.SelectedIndex;
            int indexAparencia = ddlAparencia.SelectedIndex;
            int indexAtributo = ddlAtributo.SelectedIndex;
            int indexHabilidade = ddlHabilidade.SelectedIndex;

            var cadastrando = btnConfirmar.Text == "Cadastrar";


            if (nome == "")
            {
                lblMensagem.InnerText = "Você precisa nomear um Personagem!";
            }
            else if (indexRaca == 0 || indexSubClasse == 0 || indexAparencia == 0
                || indexAtributo == 0 || indexHabilidade == 0)
            {
                lblMensagem.InnerText =
                    "Você precisa selecionar todos os campos!";
            }

            else if (nome != "")
            {

                Personagem novoPersonagem = null;

                int id = -1;

                if (cadastrando)
                {
                    novoPersonagem = new Personagem();
                }else
                {
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novoPersonagem = PersonagemDAO.ListarPersonagens(id);
                    }
                }


                novoPersonagem.Nome = nome;
                novoPersonagem.Sexo = sexo;
                novoPersonagem.DataNasc = Convert.ToDateTime(datanascimento);
                novoPersonagem.Nivel = Convert.ToInt32(nivel);



                int idRaca = Convert.ToInt32(ddlRaca.SelectedValue);
                novoPersonagem.RacaID = idRaca;

                int idSubclasse = Convert.ToInt32(ddlSubclasse.SelectedValue);
                novoPersonagem.SubclasseID = idSubclasse;

                int idAparencia = Convert.ToInt32(ddlAparencia.SelectedValue);
                novoPersonagem.AparenciaID = idAparencia;

                int idAtributo = Convert.ToInt32(ddlAtributo.SelectedValue);
                novoPersonagem.AtributoID = idAtributo;

                int idHabilidade = Convert.ToInt32(ddlHabilidade.SelectedValue);
                novoPersonagem.HabilidadeID = idHabilidade;

                string mensagem = "";

                if (cadastrando)
                {
                    mensagem = PersonagemDAO.CadastrarPersonagem(novoPersonagem);
                }
                else
                {
                    mensagem = PersonagemDAO.AlterarPersonagem(novoPersonagem);
                    btnConfirmar.Text = "Cadastrar";
                }


                    
                //Limpando o campo de texto
                txtNome.Text = "";
                txtNivel.Text = "";
                txtSexo.Text = "";
                txtDataNasc.Text = "";
                ddlRaca.SelectedIndex = 0;
                ddlSubclasse.SelectedIndex= 0;
                ddlAparencia.SelectedIndex = 0;
                ddlAtributo.SelectedIndex = 0;
                ddlHabilidade.SelectedIndex = 0;
                
                
                lblMensagem.InnerText = mensagem;

                PopularLVs();
            }
            else
            {
                lblMensagem.InnerText = "Você precisa nomear um Personagem!";
            }
        }

        private void PopularLVs()
        {
            var personagens = PersonagemDAO.ListarPersonagens();
            PopularLVAparencias(personagens);
        }

        private void PopularLVAparencias(List<Personagem> personagens)
        {
            lvPersonagens.DataSource = personagens;
            lvPersonagens.DataBind();

        }

        protected void lvPersonagens_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idPersonagem = Convert.ToInt32(id);
                    Personagem PersonagemExcluido = PersonagemDAO.Remover(idPersonagem);
                    if (PersonagemExcluido != null)
                    {
                        lblMensagem.InnerText = "Personagem " + PersonagemExcluido.Nome + " excluído com sucesso!";
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Personagens?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    this.Response.Redirect("~/Personagens?id=" + id + "&edit=true");
                }
            }
            PopularLVs();
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            txtNome.Enabled = true;
            txtDataNasc.Enabled = true;
            txtNivel.Enabled = true;
            txtSexo.Enabled = true;
            ddlRaca.Enabled = true;
            ddlSubclasse.Enabled = true;
            ddlAparencia.Enabled = true;
            ddlAtributo.Enabled = true;
            ddlHabilidade.Enabled = true;
            btnConfirmar.Text = "Cadastrar";

            txtNome.Text = "";
            txtNivel.Text = "";
            txtSexo.Text = "";
            txtDataNasc.Text = "";
            ddlRaca.SelectedIndex = 0;
            ddlSubclasse.SelectedIndex = 0;
            ddlAparencia.SelectedIndex = 0;
            ddlAtributo.SelectedIndex = 0;
            ddlHabilidade.SelectedIndex = 0;
            lblMensagem.InnerText = "";
        }
    }
}