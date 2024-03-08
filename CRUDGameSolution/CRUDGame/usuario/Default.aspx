<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDGame.usuario.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/RPG.css" rel="stylesheet" />
    <title>RPG</title>
</head>
<body>
    <h1>Página Inicial</h1>
    <form id="form1" runat="server">
        <asp:LoginStatus ID="LoginStatus1" CssClass="login" runat="server" LoginText="" LogoutText="Sair" />
        <div runat="server" id="div_gerenciadora">
            <a href="Classes">Gerenciar Classes</a>
            <br />
            <br />
            <a href="Racas">Gerenciar Raças</a>
            <br />
            <br />
            <a href="Habilidades">Gerenciar Habilidades</a>
            <br />
            <br />
            <a href="SubClasses">Gerenciar Subclasses</a>
            <br />
            <br />
            <a href="Cores">Gerenciar Cores</a>
            <br />
            <br />
            <a href="Personagens">Gerenciar Personagens</a>
            <br />
            <br />
            <a href="Aparencias">Gerenciar Aparências</a>
            <br />
            <br />
            <a href="Atributos">Gerenciar Atributos</a>
        </div>
    </form>
</body>
</html>
