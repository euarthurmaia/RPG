<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmHabilidade.aspx.cs" Inherits="CRUDGame.FrmHabilidade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/style.css" rel="stylesheet" />
    <title>Gerenciamento de Habilidades</title>
</head>
<body>
    <h1>Gerenciar Habilidades</h1>
    <form id="form1" runat="server">
        <div>
            <a href="RPG">Início</a>
        </div>

        <fieldset>
            <legend>Criar nova habilidade
            </legend>

            <p>
                <label>Nome da Habilidade:</label>
                <asp:TextBox runat="server" ID="txtDescricao" />
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

        <h2>Habilidades cadastradas</h2>

        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Descrição</th>
                <th>Ações</th>
            </tr>

            <asp:ListView runat="server" ID="lvHabilidades" OnItemCommand="lvClasses_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("IdHabilidade") %>
                        </td>
                        <td>
                            <%# Eval("Descricao") %>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar" runat="server" ImageUrl="img/view.svg" CommandName="Visualizar" CommandArgument='<%# Eval("IdHabilidade") %>' />
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="img/edit.svg" CommandName="Editar" CommandArgument='<%# Eval("idHabilidade") %>'/>
                            <asp:ImageButton ID="btnDeletar" runat="server" ImageUrl="img/delete.svg" CommandName="Excluir" CommandArgument='<%# Eval("IdHabilidade") %>'
                                OnClientClick="return confirm('Deseja Realmente Excluir essa Classe?')" />
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>

    </form>
</body>
</html>
