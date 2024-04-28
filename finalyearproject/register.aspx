<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="finalyearproject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="stylesheets/user/Register.css" rel="stylesheet" />
    <title>registration form</title>
    </head>
<body >
    <header>
        
    </header>
    <form id="form1" runat="server">
        <div class="Registration-form">
            <h2 class="container-heading">REGISTER HERE</h2>
            <p>*If you don’t have an account, register now! </p>
            <div class="form-items">
                <asp:Label ID="Label1" runat="server" Text="Fullname: " class="label-text"></asp:Label><br />
                <asp:TextBox ID="Fullname" runat="server" Class="input-area"></asp:TextBox>
            </div>
            <div class="form-items">
                <asp:Label ID="Label2" runat="server" Text="Username: " class="label-text"></asp:Label><br />
                <asp:TextBox ID="Username" runat="server" Class="input-area"></asp:TextBox>
            </div>
            <div class="form-items">
                <asp:Label ID="Label3" runat="server" Text="Email: " class="label-text"></asp:Label><br />
                <asp:TextBox ID="Email" runat="server" TextMode="Email" Class="input-area"></asp:TextBox>
            </div>
            <div class="form-items">
                <asp:Label ID="Label4" runat="server" Text="Password: " class="label-text"></asp:Label><br />
                <asp:TextBox ID="Password" runat="server" TextMode="Password" Class="input-area"></asp:TextBox>
            </div>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" Class="submit-btn" />
        </div>
    </form>
    <footer></footer>
</body>
</html>
