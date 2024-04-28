<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="finalyearproject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/user/OrderDetail.css" rel="stylesheet" />
    <div class="body">
    <h1 class="heading" style="font-weight:500;">Order recieved sucessfully</h1>
    <h2 style="font-weight:500;">
        <asp:Label ID="LabelOrderID" runat="server" Text=""></asp:Label></h2>
        <div class="container-product">
            <asp:Repeater ID="repeaterOrders" runat="server">
                <ItemTemplate>

                    <div class="Product">
                        <img src="Images/ProductImages/<%# Eval("ProductID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" class="product-image " alt="<%# Eval("Name") %>">
                        <div class="product-content">
                            <h2 class="product-name"><%# Eval("ProductName") %></h2>
                            <h3 class="product-detail"><%# Eval("ProductDetails") %></h3>
                            <p class="product-price"><%# Eval("Price","{0:c}") %></p>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
