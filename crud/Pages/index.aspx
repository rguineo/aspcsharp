<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="index.aspx.cs" Inherits="crud.Pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="container">
        <div class="mx-auto" style="text-align: center">
            <h2>Listado de registros de usuarios</h2>
        </div>
        <br />
        <form runat="server">
            <div class="container">
                <div class="row">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control" Text="Create" OnClick="BtnCreate_Click" />
                </div>
            </div>
            <br />
            <div class="container row">
                <div class="table small">
                    <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones de Administrador">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Read" CssClass="btn btn-info form-control-sm" ID="BtnRead" OnClick="BtnRead_Click" />
                                    <asp:Button runat="server" Text="Update" CssClass="btn btn-warning form-control-sm" ID="BtnUpdate" OnClick="BtnUpdate_Click" />
                                    <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger form-control-sm" ID="BtnDelete" OnClick="BtnDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
