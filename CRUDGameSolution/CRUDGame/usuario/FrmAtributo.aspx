<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAtributo.aspx.cs" Inherits="CRUDGame.FrmAtributo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciar Atributos</title>
</head>
<body>
    <h1>Gerenciar Atributo</h1>
    <form id="form1" runat="server">
        <div>
            <a href="RPG">Início</a>
        </div>

        <fieldset>
            <legend>Criar novo Atributo
            </legend>

            <p>
                <label>Nome do Atributo:</label>
                <asp:TextBox runat="server" ID="txtNome" />
            </p>
            <p>
                <label>Força</label>
                <asp:TextBox ID="txtForca" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Destreza</label>
                <asp:TextBox ID="txtDestreza" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Sabedoria</label>
                <asp:TextBox ID="txtSabedoria" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Constituição</label>
                <asp:TextBox ID="txtConstituicao" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Inteligência</label>
                <asp:TextBox ID="txtInteligencia" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Carisma</label>
                <asp:TextBox ID="txtCarisma" runat="server"></asp:TextBox>
            </p>

            <p>
                <asp:Button Text="Cadastrar"
                    runat="server"
                    ID="btnConfirmar" OnClick="btnConfirmar_Click" />
            </p>
            <p>
                <asp:Button ID="btnResetar" runat="server" Text="Reset" OnClick="btnResetar_Click"/>
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </fieldset>

        <h2>Atributos Cadastrados</h2>
        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Nome</th>
                <th>Força</th>
                <th>Destreza</th>
                <th>Sabedoria</th>
                <th>Constituição</th>
                <th>Inteligência</th>
                <th>Carisma</th>
                <th>Ações</th>
            </tr>


            <asp:ListView runat="server" ID="lvAtributos" OnItemCommand="lvAtributos_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdAtributo") %> </td>
                        <td><%# Eval("Nome") %> </td>
                        <td><%# Eval("Forca") %> </td>
                        <td><%# Eval("Destreza") %> </td>
                        <td><%# Eval("Sabedoria") %> </td>
                        <td><%# Eval("Constituicao") %> </td>
                        <td><%# Eval("Inteligencia") %> </td>
                        <td><%# Eval("Carisma")%></td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar" runat="server" ImageUrl="img/view.svg" CommandName="Visualizar" CommandArgument='<%# Eval("idAtributo") %>' />
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="img/edit.svg" CommandName="Editar" CommandArgument='<%# Eval("idAtributo") %>' />
                            <asp:ImageButton ID="btnDeletar" runat="server" ImageUrl="img/delete.svg" CommandName="Excluir" CommandArgument='<%# Eval("IdAtributo") %>'
                                OnClientClick="return confirm('Deseja Realmente Excluir essa Atributo?')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>


        </table>

    </form>
</body>
</html>
