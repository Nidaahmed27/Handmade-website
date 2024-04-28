<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="finalyearproject.AddProduct" MasterPageFile="~/admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/admin/AddProduct.css" rel="stylesheet" />
    <div class="AddProduct-container-body">
    <div class="AddProduct-container">
    <h2 class="container-heading">ADD PRODUCT</h2>
    <div class="form-items">
        <asp:Label ID="Label1" runat="server" Text="Product Name:" class="label-text"></asp:Label><br />
        <asp:TextBox ID="TxtProductName" runat="server" Class="input-area"></asp:TextBox>
        <br />
    </div>

     <div class="form-items">
        <asp:Label ID="Label2" runat="server" Text="Price:" class="label-text"></asp:Label><br />
        <asp:TextBox ID="TxtPrice" runat="server" Class="input-area"></asp:TextBox>
         <br />
    </div>
     <div class="form-items">
        <asp:Label ID="Label3" runat="server" Text="Sell Price:" class="label-text"></asp:Label><br />
        <asp:TextBox ID="TxtSellPrice" runat="server" Class="input-area"></asp:TextBox>
         <br />
    </div>
     <div class="form-items">
        <asp:Label ID="Label4" runat="server" Text="Brand:" class="label-text"></asp:Label><br />
         <asp:DropDownList ID="DdlBrand" runat="server"  Class="input-area"></asp:DropDownList>
         <br />
    </div>
     <div class="form-items">
        <asp:Label ID="Label5" runat="server" Text="Category:" class="label-text"></asp:Label><br />
         <asp:DropDownList ID="DdlCategory" runat="server"  AutoPostBack="true" Class="input-area" OnSelectedIndexChanged="DdlCategory_SelectedIndexChanged" ></asp:DropDownList>
         <br />
    </div>
     <div class="form-items">
        <asp:label id="label6" runat="server" text="Sub Category:" class="label-text"></asp:label><br />
         <asp:dropdownlist id="Ddlsubcategory" runat="server" Class="input-area"></asp:dropdownlist>
         <br />
    </div>
    <div class="form-items">
        <asp:Label ID="Label14" runat="server" Text="Quantity:" class="label-text"></asp:Label><br />
        <asp:TextBox ID="TxtProductQuantity" runat="server" Class="input-area"></asp:TextBox>
    </div>
     <div class="form-items">
        <asp:Label ID="Label7" runat="server" Text="Description:" class="label-text"></asp:Label><br />
        <asp:TextBox ID="TxtDescription" TextMode="MultiLine" runat="server" Class="input-area"></asp:TextBox>
         <br />
    </div>
     <div class="form-items">
        <asp:Label ID="Label8" runat="server" Text="Product Detail:" class="label-text"></asp:Label><br />
        <asp:TextBox ID="TxtPdetail" TextMode="MultiLine" runat="server" Class="input-area"></asp:TextBox>
         <br />
    </div>
     <div class="form-items">
        <asp:Label ID="Label9" runat="server" Text="Upload Image:" class="label-text"></asp:Label><br />
         <asp:FileUpload ID="FileUploadImg1" runat="server" Class="input-area" />
    </div>
    <div class="form-items">
        <asp:Label ID="Label10" runat="server" Text="Upload Image:" class="label-text"></asp:Label><br />
         <asp:FileUpload ID="FileUploadImg2" runat="server" Class="input-area" />
    </div>
    <div class="form-items">
        <asp:Label ID="Label11" runat="server" Text="Upload Image:" class="label-text"></asp:Label><br />
         <asp:FileUpload ID="FileUploadImg3" runat="server" Class="input-area" />
    </div>
     <div class="form-items">
         <asp:CheckBox ID="CheckReturnPolicy" runat="server" />
        <asp:Label ID="Label12" runat="server" Text="30 Days Return" class="label-text"></asp:Label>
    </div>
    <div class="form-items">
        <asp:CheckBox ID="CheckCOD" runat="server" />
        <asp:Label ID="Label13" runat="server" Text="Cash On Delivery[COD]" class="label-text"></asp:Label>
    </div>
    <div>
        <asp:Button ID="BtnAddProduct" runat="server" Text="Add Product" CssClass="submit-btn" OnClick="BtnAddProduct_Click" />
    </div>
        </div>
   </div>
</asp:Content>

