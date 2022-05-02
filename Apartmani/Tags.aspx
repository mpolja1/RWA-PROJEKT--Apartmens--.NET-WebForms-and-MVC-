<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Apartmani.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>tags</h1>
    
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="container p-0">

                    <table>
                         <th>Id </th>
                      <tr><%#Eval("Id")%></tr>
                        <tr>  <th>Name <%#Eval("Name") %></th></tr>
                        
                    </table>

                </div>


            </ItemTemplate>
            </asp:Repeater>
     
</asp:Content>
