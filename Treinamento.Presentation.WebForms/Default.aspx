<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Treinamento.Presentation.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
           
            <br />
            <br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salvar" />
            <br />
            <asp:Label ID="lblMensagem" runat="server" Text="Label"></asp:Label>
           
        </div> 
    </div>

</asp:Content>
