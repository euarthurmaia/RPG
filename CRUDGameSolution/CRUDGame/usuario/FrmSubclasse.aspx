<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSubclasse.aspx.cs" Inherits="CRUDGame.FrmSubclasse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciar Subclasses</title>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Gerenciar Subclasses</h1>
    <form id="form1" runat="server">
        <div>
            <a href="RPG">Início</a>
        </div>

        <fieldset>
            <legend>Criar nova Subclasse
            </legend>

            <p>
                <label>Subclasse:</label>
                <asp:TextBox runat="server" ID="txtDescricao" />
            </p>
            <p>
                <label>Selecione uma classe: </label>
                <asp:DropDownList runat="server" ID="DDLClasse">
                </asp:DropDownList>
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

        <h2>SubClasses Cadastradas</h2>
        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Descrição</th>
                <th>Classe</th>
                <th>Ações</th>
            </tr>


            <asp:ListView runat="server" ID="lvSubclasses" OnItemCommand="lvSubclasses_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdSubclasse") %> </td>
                        <td><%# Eval("Descricao") %> </td>
                        <td><%# Eval("GetClasse.Descricao") %> </td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar" runat="server" ImageUrl="img/view.svg" CommandName="Visualizar" CommandArgument='<%# Eval("idSubclasse") %>'/>
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="img/edit.svg" CommandName="Editar" CommandArgument='<%# Eval("idSubclasse") %>'/>
                            <asp:ImageButton ID="btnDeletar" runat="server" ImageUrl="img/delete.svg" CommandName="Excluir" CommandArgument='<%# Eval("IdSubclasse") %>' 
                                OnClientClick="return confirm('Deseja Realmente Excluir essa SubClasse?')"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>


        </table>

    </form>


</body>
</html>
