<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="finalyearproject.RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover Password</title>
    <link href="stylesheets/admin/Category.css" rel="stylesheet" />
   </head>
<body class="AddProduct-container-body">
    <form id="form1" runat="server" class="AddProduct-container">
         <h1 class="container-heading" style="font-weight:500;">RESET PASSWORD</h1>
        <div class="form-items">
             <asp:Label ID="Label1" runat="server" Text="New Password" class="label-text"></asp:Label>
        <asp:TextBox ID="txtNewPassword" runat="server" Class="input-area"></asp:TextBox>
        </div>
      <div class="form-items">
            <asp:Label ID="Label2" runat="server" Text="Confirm New Password" class="label-text"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" Class="input-area"></asp:TextBox>
        </div>
        <asp:Button ID="btnSave_Click" runat="server" OnClick="Button1_Click" Text="Save" CssClass="submit-btn" />
        <asp:Label ID="lblMessage" runat="server" class="label-text"></asp:Label>
    </form>
</body>
</html>
