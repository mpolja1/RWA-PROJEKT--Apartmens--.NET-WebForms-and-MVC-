<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apartmani.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default</title>
    <!-- CSS only -->
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <h1 style="text-align: center">Welcome to Admin site</h1>
    <section class="vh-70">
        <div class="container-fluid h-custom">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-md-9 col-lg-6 col-xl-5">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                        class="img-fluid" alt="Sample image">
                </div>
                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">

                    <form runat="server">

                        <!-- Email input -->
                        <div class="form-outline mb-4">
                            <label class="form-label" for="form3Example3">Username</label>
                            <asp:TextBox ID="txtUsername" runat="server" class="form-control form-control-lg"
                                placeholder="Enter username"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" ForeColor="Red" runat="server">*Niste upisali username</asp:RequiredFieldValidator>
                        </div>

                        <!-- Password input -->
                        <div class="form-outline mb-2" runat="server">
                            <label class="form-label" for="form3Example4">Password</label>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control form-control-lg"
                                placeholder="Enter password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ForeColor="Red" runat="server">*Niste upisali lozinku</asp:RequiredFieldValidator>
                        </div>
                        <asp:Panel ID="PanelIspis"  runat="server" Visible="False">
            <div class='alert alert-danger' role='alert'>
                <asp:Label ID="lblErrorLogin" meta:resourcekey="lblErrorLogin" runat="server" Text="Check the entered data again!"></asp:Label>
            </div>

        </asp:Panel>
                        <div class="text-center text-lg-start mt-4 pt-2">
                            <asp:Button ID="btnLogin" class="btn btn-primary btn-lg"
                                Style="padding-left: 2.5rem; padding-right: 2.5rem;" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                    </form>
                </div>
        </div>
        <div class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-7 bg-primary">
    <!-- Copyright -->
    <div class="text-white mb-3 mb-md-0">
      Copyright © 2022. All rights reserved.
    </div>
  </div>
    </section>
</body>
<!-- JavaScript Bundle with Popper -->
   <script src="Scripts/jquery-3.6.0.min.js"></script>

    <!-- BOOTSTRAP -->
    <script src="Scripts/bootstrap.min.js"></script>
</html>
