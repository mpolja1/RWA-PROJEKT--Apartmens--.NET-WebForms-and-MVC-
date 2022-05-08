<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="RegistredUsers.aspx.cs" Inherits="Apartmani.RegistredUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
   
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>   
    <link href = "~/lib/bootstrap/dist/css/bootstrap.css" rel = "stylesheet" / >  
  
<link href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" rel="stylesheet" />   
<link href = "https://cdn.datatables.net/responsive/2.1.1/css/responsive.bootstrap.min.css" rel = "stylesheet" / >  
  
  
    


    
    <div class="container mt-2">
        <asp:Repeater ID="RepeaterUsers" runat="server">
           <HeaderTemplate>
        <table id="myTable" class="table table-hover border-top" style="width: 100%">
            <thead>
                <tr>
                    <th>#</th>
                    <th>UserName</th>
                    <th>CreatedAt</th>
                    <th>E-mail</th>
                    <th>Adress</th>
                    <th>Phone number</th>
                </tr>
            </thead>
            <tbody>
                </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Id") %></td>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("CreatedAt") %></td>
                    <td><%# Eval("Email") %></td>
                    <td><%# Eval("Address") %></td>
                    <td><%# Eval("PhoneNumber") %></td>
                </tr>            
                </ItemTemplate>
            <FooterTemplate>
            </tbody>
        </table>
                </FooterTemplate>
              </asp:Repeater>
    </div>
  


 


</asp:Content>
