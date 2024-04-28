<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandName.aspx.cs" Inherits="finalyearproject.BrandName" MasterPageFile="~/admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/admin/Category.css" rel="stylesheet" />
    <div class="AddProduct-container-body">
    <div class="AddProduct-container">
        <h2 class="container-heading">ADD BRAND</h2>
  <div class="form-items">
        <asp:Label ID="lblBrandName" runat="server" Text="BRAND NAME:" class="label-text"></asp:Label>
        <asp:TextBox ID="TxtBrandName" runat="server" Class="input-area"></asp:TextBox>
     </div>
         <asp:Button ID="BtnAddBrand" runat="server" Text="Add" OnClick="BtnAddBrand_Click" CssClass="submit-btn" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" runat="server" ErrorMessage="*please provide BrandName" ControlToValidate="TxtBrandName" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
 </div>
    <div class="Category-Table">
        <h1 class="table-heading">BRANDS</h1>
        <asp:Repeater ID="RepeaterBrand" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Brand</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("BrandID") %></td>
                    <td><%# Eval("Name") %></td>
                    <asp:HiddenField ID="HiddenFieldBrandID" runat="server" Value='<%# Eval("BrandID") %>' />
                    <td><asp:Button ID="BtnRemoveBrand" runat="server" Text="Remove Brand" class="delete-btn" OnClick="BtnRemoveBrand_Click" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
        </div>
</asp:Content>
