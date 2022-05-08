<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Apartmants.aspx.cs" Inherits="Apartmani.Apartmants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <link href="style/MyStyle.css" rel="stylesheet" type="text/css"/>

    <div class="" runat="server">
        <div class="d-flex my-2 col-sm-2">
            <asp:Label ID="lblStatus" CssClass="p-2" runat="server" Text="Status"></asp:Label>
            <asp:DropDownList ID="ddlStatus" class="form-select  w-100" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="d-flex justify-content-between">

            <div class="d-flex mb-3">
                <asp:Label ID="lblCity" CssClass="p-2" runat="server" Text="City"></asp:Label>
                <asp:DropDownList ID="ddlCity" class="form-select w-100" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>

    </div>
    <asp:Label ID="indexx" runat="server" Text="Label"></asp:Label>

    <div class=" mx-4">
        <asp:Repeater ID="RepeaterApartments" runat="server">
            <HeaderTemplate>
                <table id="myTable" class="table table-hover aa" style="cursor: pointer">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>City</th>
                            <th>Adults</th>
                            <th>Children</th>
                            <th>Rooms</th>
                            <th>Price</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>

                <tr>
                    <td><%#Eval("Name") %></td>
                    <td><%#Eval("City") %></td>
                    <td><%#Eval("MaxAdults") %></td>
                    <td><%#Eval("MaxChildren") %></td>
                    <td><%#Eval("TotalRooms") %></td>
                    <td><%#Eval("Price") %></td>
                    <td><%#Eval("Status") %></td>
                    <td>
                        <asp:LinkButton ID="btnEdit"  CssClass="btn btn-primary mx-1 buto" runat="server">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server">Delete</asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
    <asp:Button ID="btnAdd" CssClass="btn btn-primary mt-2 " runat="server" Text="Add" OnClick="btnAdd_Click" />

    <asp:Panel ID="PanelApartment" Visible="false" runat="server">

        <div class="container">
            <div class="form-row">
                <div class="form-group col-sm-2">
                    <asp:Label ID="OwnerName" for="txtOwnerName" class="form-label" runat="server" Text="Owner Name"></asp:Label>
                    <asp:TextBox ID="txtOwnerName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOwnerName" Display="Dynamic"
                        ForeColor="Red">* Niste upisali ime</asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-sm-2">
                    <asp:Label CssClass="p-2" runat="server" Text="Status"></asp:Label>
                    <asp:DropDownList ID="ddlStatusAdd" class="form-select " runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group col-sm-2">
                <asp:Label ID="lblCityFormAdd" CssClass="" runat="server" Text="City"></asp:Label>
                <asp:DropDownList ID="ddlCityAdd" class="form-select " runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group col-sm-2">
                <asp:Label ID="lblAddress" class="form-label" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-2">
                    <asp:Label ID="lblName" class="form-label" runat="server" Text="Apartment Name"></asp:Label>
                    <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2">
                    <asp:Label ID="lblNameEng" class="form-label" runat="server" Text="Apartment Name Eng"></asp:Label>
                    <asp:TextBox ID="txtNameEng" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-sm-1">
                    <asp:Label ID="lblPrice" class="form-label" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="form-group col">
                    <div class="row">
                        <div class="col-6 col-sm-3">
                            <asp:Label ID="lblMaxAdults" class="form-label" runat="server" Text="Max Adults"></asp:Label>
                            <asp:TextBox ID="txtMaxAdults" class="form-control" runat="server"></asp:TextBox>
                        </div>


                        <div class="col-6 col-sm-3">
                            <asp:Label ID="lblMaxChildren" class="form-label" runat="server" Text="Max Children"></asp:Label>
                            <asp:TextBox ID="txtMaxChildren" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-6 col-sm-3">
                            <asp:Label ID="lblTotalRooms" class="form-label" runat="server" Text="Total Rooms"></asp:Label>
                            <asp:TextBox ID="txtTotalRooms" class="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-6 col-sm-3">
                            <asp:Label ID="lblBeachDistance" class="form-label" runat="server" Text="Beach Distance"></asp:Label>
                            <asp:TextBox ID="txtBeachDistance" class="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="row my-2">
                    <div class="btn-group">
                        <div class="me-4">
                            <asp:Button ID="btnAddApartment" CssClass="btn btn-primary " runat="server" Text="Save" OnClick="btnAddApartment_Click" />

                        </div>
                        <div class="">
                            <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
