<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCor.aspx.cs" Inherits="CRUDGame.FrmCor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/style.css" rel="stylesheet" />
    <title>Gerenciar Cores</title>
</head>
<body>
    <h1>Gerenciar Cores</h1>
    <form id="form1" runat="server">
        <div>
            <a href="RPG">Início</a>
        </div>

        <fieldset>
            <legend>Criar nova Cor
            </legend>

            <p>
                <label>Nome da Cor:</label>
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

        <h2>Cores cadastradas</h2>

        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Descrição</th>
                <th>Ações</th>
            </tr>

            <asp:ListView runat="server" ID="lvCores" OnItemCommand="lvCores_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("IdCor") %>
                        </td>
                        <td>
                            <%# Eval("Descricao") %>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar" runat="server" ImageUrl="img/view.svg" CommandName="Visualizar" CommandArgument='<%# Eval("IdCor") %>'/>
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="img/edit.svg" CommandName="Editar" CommandArgument='<%# Eval("IdCor") %>'/>
                            <asp:ImageButton ID="btnDeletar" runat="server" ImageUrl="img/delete.svg" CommandName="Excluir" CommandArgument='<%# Eval("IdCor") %>' 
                                             OnClientClick="return confirm('Deseja Realmente Excluir essa Cor?')" />
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>
    </form>
</body>
</html>
