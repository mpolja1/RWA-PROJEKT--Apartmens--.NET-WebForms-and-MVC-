<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Apartmani.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <h1 class="p-2">Tags</h1>


    <asp:Button ID="btnAdd" CssClass="btn btn-primary m-2" runat="server" Text="Add" OnClick="btnAdd_Click" />
    <asp:Panel ID="PanelAddTag" runat="server" Visible="false">

        <div class="row  container ">
            <div class="col-12">
                <asp:TextBox ID="txtName" class="form-control w-25" runat="server" placeholder="Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" ForeColor="Red" runat="server">*</asp:RequiredFieldValidator>
            </div>

            <div class="col-12">

                <asp:TextBox ID="txtNameEng" class="form-control w-25" runat="server" placeholder="NameEng"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNameEng" ForeColor="Red" runat="server">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-12">
                <asp:Label ID="lblType" class="form-label" runat="server" Text="Type"></asp:Label>
                <asp:DropDownList ID="ddlType" class="dropdown form-control w-25" runat="server"></asp:DropDownList>
            </div>
        </div>
    </asp:Panel>

 
        <asp:Repeater ID="RepeaterTags" runat="server" OnItemCommand="RepeaterTags_DeleteTag">
            <ItemTemplate>
                <ul>
                    <li class="fs-6">
                        <%#Eval("Name") %>  (<%#Eval("TagCount")%>)
                        <asp:Button ID="btnDelete" Visible='<%# CheckCount(Convert.ToInt32(Eval("TagCount"))) %>'
                            OnClientClick="return fnConfirmDelete();" CommandArgument=' <%#Eval("Id")%>  ' CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" />
                    </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
    
  



</asp:Content>
