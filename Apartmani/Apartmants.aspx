<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Apartmants.aspx.cs" Inherits="Apartmani.Apartmants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="" runat="server">
        <div class="d-flex  my-3">
            <asp:Label ID="lblStatus" CssClass="p-2" runat="server" Text="Status"></asp:Label>  
            <asp:DropDownList ID="ddlStatus" class="form-group "  runat="server">


                </asp:DropDownList>
        </div>
        <div class="d-flex justify-content-between">

            <div class="d-flex mb-3">
                <asp:Label ID="lblCity" CssClass="p-2" runat="server" Text="City"></asp:Label>  
                <asp:DropDownList ID="ddlCity" class="form-select w-100"  runat="server">


                </asp:DropDownList>
                
                
            </div>
            <div class="d-flex my-3 mx-5">
                <asp:Label ID="lblSort" runat="server" CssClass="p-0" Text="Sort by"></asp:Label>  
                <asp:DropDownList ID="ddlSort" class="form-group"  runat="server">


                </asp:DropDownList>
            </div>
        </div>

    </div>
    <asp:Button ID="btnGradispis" runat="server" Text="Button" OnClick="btnGradispis_Click" />
    <asp:Label ID="lblGrad" runat="server" Text=""></asp:Label>

</asp:Content>
