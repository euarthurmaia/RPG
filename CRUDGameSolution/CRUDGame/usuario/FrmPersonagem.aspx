<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPersonagem.aspx.cs" Inherits="CRUDGame.FrmPersonagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/style.css" rel="stylesheet" />
    <title>Gerenciar Personagens</title>
</head>
<body>
    <h1>Gerenciar Personagens</h1>
    <form id="form1" runat="server">
        <div>
            <a href="RPG">Início</a>
        </div>

        <fieldset>
            <legend>Criar novo personagem
            </legend>

            <p>
                <label>Nome do Personagem:</label>
                <asp:TextBox runat="server" ID="txtNome" />
            </p>

            <p>
                <label>Data de nascimento:</label>
                <asp:TextBox runat="server" ID="txtDataNasc" TextMode="Date" />
            </p>

            <p>
                <label>Nível:</label>
                <asp:TextBox runat="server" ID="txtNivel" />
            </p>

            <p>
                <label>Sexo:</label>
                <asp:TextBox runat="server" ID="txtSexo" />
            </p>

            <p>
                <label>Raça:</label>
                <asp:DropDownList runat="server" ID="ddlRaca">
                </asp:DropDownList>
            </p>

            <p>
                <label>Subclasse:</label>
                <asp:DropDownList runat="server" ID="ddlSubclasse">
                </asp:DropDownList>
            </p>

            <p>
                <%--Precisaremos rever e refatorar a aparência--%>
                <label>Aparência:</label>
                <asp:DropDownList runat="server" ID="ddlAparencia">
                </asp:DropDownList>
            </p>
            <p>
                <label>Atributo:</label>
                <asp:DropDownList runat="server" ID="ddlAtributo">
                </asp:DropDownList>
            </p>
            <p>
                <label>Habilidade:</label>
                <asp:DropDownList runat="server" ID="ddlHabilidade">
                </asp:DropDownList>
            </p>

            <p>
                <asp:Button Text="Cadastrar"
                    runat="server"
                    ID="btnConfirmar" OnClick="btnConfirmar_Click" />
            </p>
            <p>
                <asp:Button ID="btnResetar" runat="server" Text="Reset" OnClick="btnResetar_Click" />
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </fieldset>

        <h2>Personagens Cadastrados</h2>
        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Nome</th>
                <th>Data Nascimento</th>
                <th>Nível</th>
                <th>Sexo</th>
                <th>Raça</th>
                <th>Subclasse</th>
                <th>Aparência</th>
                <th>Atributo</th>
                <th>Habilidade</th>
                <th>Ações</th>
            </tr>


            <asp:ListView runat="server" ID="lvPersonagens" OnItemCommand="lvPersonagens_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdPersonagem") %> </td>
                        <td><%# Eval("Nome") %> </td>
                        <td><%# Eval("DataNasc", "{0:dd/MM/yyyy}") %> </td>
                        <td><%# Eval("Nivel") %> </td>
                        <td><%# Eval("Sexo") %> </td>
                        <td><%# Eval("GetRaca.Descricao") %> </td>
                        <td><%# Eval("GetSubclasse.Descricao") %> </td>
                        <td><%# Eval("GetAparencia.Nome") %> </td>
                        <td><%# Eval("GetAtributo.Nome") %> </td>
                        <td><%# Eval("GetHabilidade.Descricao") %> </td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar" runat="server" ImageUrl="img/view.svg" CommandName="Visualizar" CommandArgument='<%# Eval("idPersonagem") %>' />
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="img/edit.svg" CommandName="Editar" CommandArgument='<%# Eval("idPersonagem") %>' />
                            <asp:ImageButton ID="btnDeletar" runat="server" ImageUrl="img/delete.svg" CommandName="Excluir" CommandArgument='<%# Eval("IdPersonagem") %>'
                                OnClientClick="return confirm('Deseja Realmente Excluir esse Personagem?')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>


        </table>

    </form>
</body>
</html>
