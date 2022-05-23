<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ApartmentDetails.aspx.cs" Inherits="Apartmani.ApartmentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
    
    <link href="style/MyStyle.css" rel="stylesheet" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <asp:Panel ID="PanelEditApartment" runat="server">

        <div class="container-fluid">
            <div class="row col-md-12">
                <div class="col-sm-3">
                    <div class=" col-sm-8">
                        <asp:Label ID="OwnerName" for="txtOwnerName" class="form-label" runat="server" Text="Owner Name"></asp:Label>
                        <asp:TextBox ID="txtOwnerName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOwnerName" Display="Dynamic"
                            ForeColor="Red">* </asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-sm-8">
                        <asp:Label CssClass="p-2" runat="server" Text="Status"></asp:Label>
                        <asp:DropDownList ID="ddlStatusAdd" class="form-select " runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-8">
                        <asp:Label ID="lblCityFormAdd" CssClass="" runat="server" Text="City"></asp:Label>
                        <asp:DropDownList ID="ddlCityAdd" class="form-select " runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-8">
                        <asp:Label ID="lblAddress" class="form-label" runat="server" Text="Address"></asp:Label>
                        <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" Display="Dynamic"
                            ForeColor="Red">* </asp:RequiredFieldValidator>
                    </div>

                    <div class="col-sm-8">
                        <asp:Label ID="lblName" class="form-label" runat="server" Text="Apartment Name"></asp:Label>
                        <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" Display="Dynamic"
                            ForeColor="Red">* </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-8">
                        <asp:Label ID="lblNameEng" class="form-label" runat="server" Text="Apartment Name Eng"></asp:Label>
                        <asp:TextBox ID="txtNameEng" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNameEng" Display="Dynamic"
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-8">
                        <asp:Label ID="lblPrice" class="form-label" runat="server" Text="Price"></asp:Label>
                        <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrice" Display="Dynamic"
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" Operator="DataTypeCheck" runat="server" Type="Double" ControlToValidate="txtPrice" ForeColor="Red">*</asp:CompareValidator>
                    </div>

                    
                    <div class="row my-2">
                        <div class="btn-group">
                            <div class="me-4">
                                <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" OnClick="btnEdit_Click" />

                            </div>
                            <div class="me-4">
                                <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" />
                            </div>
                            <div class="">
                                <asp:Button ID="btnAddReservation" Visible="false" CssClass="btn btn-info" runat="server" OnClick="btnAddReservation_Click" Text="Add Reservation" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-sm-3">
                    <div class="col-sm-8">
                        <asp:Label ID="lblMaxAdults" class="form-label" runat="server" Text="Max Adults"></asp:Label>
                        <asp:TextBox ID="txtMaxAdults" class="form-control" runat="server"></asp:TextBox>

                        <asp:CompareValidator ID="CompareValidator2" Operator="DataTypeCheck" runat="server" Type="Integer" ControlToValidate="txtMaxAdults"></asp:CompareValidator>
                    </div>


                    <div class=" col-sm-8">
                        <asp:Label ID="lblMaxChildren" class="form-label" runat="server" Text="Max Children"></asp:Label>
                        <asp:TextBox ID="txtMaxChildren" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class=" col-sm-8">
                        <asp:Label ID="lblTotalRooms" class="form-label" runat="server" Text="Total Rooms"></asp:Label>
                        <asp:TextBox ID="txtTotalRooms" class="form-control" runat="server"></asp:TextBox>

                    </div>
                    <div class="col-sm-8">
                        <asp:Label ID="lblBeachDistance" class="form-label" runat="server" Text="Beach Distance"></asp:Label>
                        <asp:TextBox ID="txtBeachDistance" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-12 p-2">
                        <h5>Tags</h5>

                        <div class="col-sm-12 p-1">
                            <div class="row">
                                <div class="col">
                                    <asp:DropDownList ID="ddlUnusedTags" class="form-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <asp:Button ID="btnAddTag" CssClass="btn btn-primary" OnClick="btnAddTag_Click" runat="server" Text="Add tag" />
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-12 p-1">

                            <div class="row">
                                <div class="col">
                                    <asp:DropDownList ID="ddlTags" class="form-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <asp:Button ID="Button1" runat="server" OnClientClick="return fnConfirmDelete()" OnClick="bntDeleteTag_click" CssClass="btn btn-danger" Text="Delete tag" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4  p-2">
                    <h1>Images</h1>
                    <asp:Repeater ID="RepeaterImages" runat="server">
                        <ItemTemplate>
                            <asp:Image ImageUrl='<%#Eval("Path")%>' CssClass="img-fluid p-1" Width="180" Height="70" AlternateText='<%#Eval("Name")%>' runat="server" />


                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="border my-2">
                        <div class="p-2">
                            <asp:Label ID="lblImageName" runat="server" Text="Title"></asp:Label>
                            <asp:TextBox ID="txtImageName" placeholder="Image title" runat="server"></asp:TextBox>

                        </div>

                        <div >
                            <asp:Label ID="Label7" runat="server" Text="Upload File:"></asp:Label>
                            <asp:FileUpload ID="ImageUpload" runat="server" accept=".png,.jpg,.jpeg" />
                            <div class="p-2">
                                <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" CssClass="btn btn-primary" Text="Upload" />
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </asp:Panel>
    <asp:Panel ID="PanelReservation" Visible="false" runat="server">

        <div class="p-3 border">
            <div class="col-md-8">
                <div class=" col-sm-4">
                    <asp:Label ID="Label5" class="form-label" runat="server" Text="Details"></asp:Label>
                    <asp:TextBox ID="txtReservationDetails" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReservationDetails" Display="Dynamic"
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label1" class="form-label" runat="server" Text="User Name"></asp:Label>
                    <asp:TextBox ID="txtReservationUserName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtReservationUserName" Display="Dynamic"
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>


                <div class=" col-sm-3">
                    <asp:Label ID="Label2" class="form-label" runat="server" Text="User Email"></asp:Label>
                    <asp:TextBox ID="txtReservationUserEmail" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtReservationUserEmail" Display="Dynamic"
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>

                <div class=" col-sm-2">
                    <asp:Label ID="Label3" class="form-label" runat="server" Text="User Phone"></asp:Label>
                    <asp:TextBox ID="txtReservationUserPhone" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtReservationUserPhone" Display="Dynamic"
                        ForeColor="Red">*</asp:RequiredFieldValidator>

                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label4" class="form-label" runat="server" Text="User Address"></asp:Label>
                    <asp:TextBox ID="txtReservationUserAdress" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtReservationUserAdress" Display="Dynamic"
                        ForeColor="Red">*</asp:RequiredFieldValidator>

                </div>

            </div>

        </div>
    </asp:Panel>

</asp:Content>
