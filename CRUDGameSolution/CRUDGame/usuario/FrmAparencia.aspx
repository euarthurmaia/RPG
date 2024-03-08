<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAparencia.aspx.cs" Inherits="CRUDGame.FrmAparencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/style.css" rel="stylesheet" />
    <title>Gerenciar Aparência</title>
</head>
<body>
    <h1>Gerenciar Aparência</h1>
    <form id="form1" runat="server">
        <div>
            <a href="RPG">Início</a>
        </div>

        <fieldset>
            <legend>Criar nova Aparência
            </legend>

            <p>
                <label>Nome da Aparência:</label>
                <asp:TextBox runat="server" ID="txtNome" />
            </p>
            <p>
                <label>Peso</label>
                <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Altura</label>
                <asp:TextBox ID="txtAltura" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Estilo do Cabelo</label>
                <asp:TextBox ID="txtEstiloCabelo" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Cor do Cabelo: </label>
                <asp:DropDownList runat="server" ID="DDLCorCabelo">
                </asp:DropDownList>
            </p>
            <p>
                <label>Cor da Pele: </label>
                <asp:DropDownList runat="server" ID="DDLCorPele">
                </asp:DropDownList>
            </p>
            <p>
                <label>Cor do Olho: </label>
                <asp:DropDownList runat="server" ID="DDLCorOlho">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button Text="Cadastrar"
                    runat="server"
                    ID="btnConfirmar" OnClick="btnConfirmar_Click"/>
            </p>
            <p>
                <asp:Button ID="btnResetar" runat="server" Text="Reset" OnClick="btnResetar_Click"/>
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </fieldset>

        <h2>Aparencias Cadastradas</h2>
        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Nome</th>
                <th>Peso</th>
                <th>Altura</th>
                <th>Estilo Cabelo</th>
                <th>Cor Cabelo</th>
                <th>Cor Pele</th>
                <th>Cor Olho</th>
                <th>Ações</th>
            </tr>


            <asp:ListView runat="server" ID="lvAparencias" OnItemCommand="lvAparencias_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdAparencia") %> </td>
                        <td><%# Eval("Nome") %> </td>
                        <td><%# Eval("Peso") %> </td>
                        <td><%# Eval("Altura") %> </td>
                        <td><%# Eval("EstiloCabelo") %> </td>
                        <td><%# Eval("GetCorCabelo.Descricao") %> </td>
                        <td><%# Eval("GetCorOlho.Descricao") %> </td>
                        <td><%# Eval("GetCorPele.Descricao") %> </td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar" runat="server" ImageUrl="img/view.svg" CommandName="Visualizar" CommandArgument='<%# Eval("idAparencia") %>' />
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="img/edit.svg" CommandName="Editar" CommandArgument='<%# Eval("idAparencia") %>' />
                            <asp:ImageButton ID="btnDeletar" runat="server" ImageUrl="img/delete.svg" CommandName="Excluir" CommandArgument='<%# Eval("IdAparencia") %>'
                                OnClientClick="return confirm('Deseja Realmente Excluir essa Aparência?')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>


        </table>

    </form>
</body>
</html>
