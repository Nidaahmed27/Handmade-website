<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="finalyearproject.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login page</title>
    <link href="stylesheets/user/Login.css" rel="stylesheet" />
</head>
<body>
    <header>
       <%-- <p>HAND<span>MADE</span></p>--%>
    </header>
    <form id="form1" runat="server">
        <div class="Login-form">
            <h1 class="container-heading">LOGIN</h1>
            <div class="form-items">
                <asp:Label ID="Label1" runat="server" Text="Email:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="Email" runat="server" TextMode="Email" Class="input-area"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatoremail" runat="server" ErrorMessage="*please provide correct email" ControlToValidate="Email" ForeColor="#b80000"></asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:Label ID="Label2" runat="server" Text="Password:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="Password" runat="server" TextMode="Password" Class="input-area"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorpassword" runat="server" ErrorMessage="*invalid password" ControlToValidate="Password" ForeColor="#b80000"></asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="Remember me" class="label-text"></asp:Label>
            </div>
            <div class="form-items">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Class="Button" Text="Login" />
               <asp:Label ID="error" runat="server" class="label-text-error"></asp:Label>
            </div>
            <div class="form-items">
                <asp:Label ID="Label4" runat="server" Text=" If you don't have an account click here"  class="label-text"></asp:Label>
                 <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx" Class="HyperLink">Register</asp:HyperLink>
            </div>

            <div class="form-items">
                <asp:Label ID="Label5" runat="server" Text="If you forgot your password click here" class="label-text"></asp:Label>
                <asp:HyperLink ID="ForgotPassword" runat="server" NavigateUrl="~/ForgetPassword.aspx" Class="HyperLink">Forget Password</asp:HyperLink>
            </div>
           <%-- <div class="form-items">
                <asp:Label ID="error" runat="server" class="label-text-error"></asp:Label>
            </div>--%>
        </div>
    </form>
    <footer></footer>
</body>
</html>

