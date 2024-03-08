<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDGame.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/style.css" rel="stylesheet" />
    <title>Formulário de Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:LoginStatus ID="LoginStatus1" CssClass="login" runat="server" LoginText="" LogoutText="Sair" />
        <h1>Sistema de Acesso</h1>
        <div runat="server" id="div_Login">
            <label>Usuário:</label>
            <p>
                <input type="text" name="name" runat="server" id="txtUsuario" />
            </p>
            <label>Senha:</label>
            <p>
                <input type="password" name="name" runat="server" id="txtSenha" />
            </p>
            <p>
                <asp:Button Text="Entrar" runat="server" ID="btnEntrar" OnClick="btnEntrar_Click" />
            </p>
            <p>
                <asp:Button ID="btnCriarUsuario" runat="server" Text="Criar Novo Usuário" OnClick="btnCriarUsuario_Click" />
            </p>
            <p>
                <asp:Label ID="lblMensagemLogin" runat="server" Text=""></asp:Label>
            </p>
        </div>
        <div runat="server" id="div_Cadastro">
            <label>Nome:</label>
            <p>
                <asp:TextBox ID="txtNomeCadastro" runat="server"></asp:TextBox>
            </p>
            <label>Data de Nascimento:</label>
            <p>
                <asp:TextBox ID="txtDataNascCadastro" runat="server" TextMode="Date"></asp:TextBox>
            </p>
            <label>Usuário:</label>
            <p>
                <asp:TextBox ID="txtUsuarioCadastro" runat="server"></asp:TextBox>
            </p>
            <label>Senha:</label>
            <p>
                <asp:TextBox ID="txtSenhaCadastro" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <label>Confirme a senha:</label>
            <p>
                <asp:TextBox ID="txtConfirmarSenhaCadastro" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/>
            </p>
            <p>
                <asp:Button ID="btnVoltar" runat="server" Text="Tela de Login" OnClick="btnVoltar_Click"/>
            </p>
            <p>
                <asp:Label ID="lblMensagemCadastro" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
