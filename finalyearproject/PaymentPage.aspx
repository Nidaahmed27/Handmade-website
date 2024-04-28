<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="finalyearproject.PaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/admin/Category.css" rel="stylesheet" />
    <style>
        .form-items{
            margin-bottom: 5px;
        }
    </style>
    <div class="AddProduct-container-body">
        <div class="AddProduct-container">
            <h2 class="container-heading">CUSTOMER DETAILS</h2>
            <div class="form-items">
                <asp:Label ID="Label1" runat="server" Text="Name:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="TxtName" runat="server" Class="input-area"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName" ErrorMessage="*Please Provide Your Name" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:Label ID="Label2" runat="server" Text="Email:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="TxtEmail" runat="server" CausesValidation="True" TextMode="Email" Class="input-area"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtEmail" ErrorMessage="*Please Provide Your Email" ForeColor="#ffe4e1"> </asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:Label ID="Label3" runat="server" Text="Mobile Number:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="TxtNumber" runat="server" TextMode="Number" Class="input-area"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtNumber" ErrorMessage="*Please Provide Your Number" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtNumber" ErrorMessage="*Mobile number must be 10 digits" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
            </div>
            <div class="form-items">
                <asp:Label ID="Label4" runat="server" Text="Address:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="TxtAddress" runat="server" TextMode="MultiLine" Class="input-area"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtAddress" ErrorMessage="*Please Provide Your Address" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:Label ID="Label5" runat="server" Text="Pincode:" class="label-text"></asp:Label><br />
                <asp:TextBox ID="TxtPincode" runat="server" TextMode="Number" Class="input-area"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPincode" ErrorMessage="*Please Provide Your PinCode" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:CheckBox ID="COD" runat="server" Checked="true" Enabled="false" />
                <asp:Label ID="Label6" runat="server" Text="COD[cash on delivery]" class="label-text"></asp:Label>
            </div>
            <asp:Button ID="BtnPlaceOrder" runat="server" Text="Place Order" OnClick="BtnPlaceOrder_Click" class="delete-btn" />
        </div>

    </div>
</asp:Content>
