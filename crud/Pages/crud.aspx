<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="crud.aspx.cs" Inherits="crud.Pages.crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container">
        <div class="mx-auto" style="text-align: center">
            <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
        </div>

        <form runat="server">
          <div class="mb-3">
            <label for="tbname" class="form-label">Nombres</label>
            <asp:TextBox runat="server" ID="tbname" CssClass="form-control" > </asp:TextBox>  
          </div>

          <div class="mb-3">
            <label for="tblastname" class="form-label">Apellidos</label>
            <asp:TextBox runat="server" ID="tblastname" CssClass="form-control" > </asp:TextBox>  
          </div>

          <div class="mb-3">
            <label for="tbaddress" class="form-label">Direccion</label>
            <asp:TextBox runat="server" ID="tbaddress" CssClass="form-control" > </asp:TextBox>  
          </div>

          <div class="mb-3">
            <label for="tbdate" class="form-label">Fecha Nacimiento</label>
            <asp:TextBox runat="server" TextMode="Date" ID="tbdate" CssClass="form-control" > </asp:TextBox>  
          </div>

            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCreate" Text="Create" Visible="false" OnClick ="BtnCreate_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnUpdate" Text="Update" Visible="false" OnClick ="BtnUpdate_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnDelete" Text="Delete" Visible="false" OnClick ="BtnDelete_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="btnBack" Text="Back" Visible="true" OnClick ="BtnBack_Click"></asp:Button>

        </form>
    </div>
</asp:Content>
