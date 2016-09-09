<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="EjemploWebService._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        ASP.NET
    </h2>
    <p>
        Para obtener más información acerca de ASP.NET, visite <a href="http://www.asp.net" title="Sitio web de ASP.NET">www.asp.net</a>.
    </p>
    <p>
        También puede encontrar <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="Documentación de ASP.NET en MSDN">documentación sobre ASP.NET en MSDN</a>.
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>
