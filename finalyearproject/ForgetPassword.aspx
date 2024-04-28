<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="finalyearproject.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="stylesheets/admin/Category.css" rel="stylesheet" />
    <title>Forget Password</title>
</head>
<body class="AddProduct-container-body">
    <form runat="server" class="AddProduct-container">
   
            <h1 class="container-heading" style="font-weight:500;">FORGOT PASSWORD</h1>
            <div class="form-items">
            <asp:Label ID="Label1" runat="server" Text="Email:" class="label-text"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" Class="input-area" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="*Enter your Email" ControlToValidate="TextBoxEmail" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
                </div>
            <asp:Button ID="ResetPassword" runat="server"  Text="Send" CssClass="submit-btn" OnClick="ResetPassword_Click" />
            <asp:Label ID="ResetPassMsg" runat="server"  class="label-text"></asp:Label>
        
   
        </form>
</body>
</html>
