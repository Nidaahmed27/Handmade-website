<%@ Page   Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="finalyearproject.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/user/Cart.css" rel="stylesheet" />

    <div class="cart-item">
        <div class="right-content">
            <asp:Label ID="LblItemCount" runat="server" Text="Label" class="item-count"></asp:Label>
            <div class="cart-products">
                <asp:Repeater ID="RepeaterCartItems" runat="server">
                    <ItemTemplate>

                        <div class="cart-item-inside">
                            <img class="product-image" src="Images/ProductImages/<%# Eval("ProductID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" />
                            <div class="product-details">
                                <div>
                                    <h2 class="product-name"><%# Eval("ProductName") %></h2>
                                    <h3 class="brand-name">by <%# Eval("BrandName") %></h3>
                                    <p class="product-description"><%# Eval("ProductDescription") %></p>
                                </div>
                                <div class="product-price">Just at <%# Eval("ProductSellPrice","{0:c}") %>/-</div>
                                <asp:HiddenField ID="HiddenCartId" runat="server" Value='<%# Eval("CartID") %>' />
                                <asp:Button ID="BtnRemove" runat="server" Text="remove" class="remove-from-cart" OnClick="BtnRemove_Click" />
                            </div>
                        </div>


                    </ItemTemplate>


                </asp:Repeater>
            </div>
        </div>
        <div class="subtotal-section">
            <h1 class="cart-total-heading">Cart Item Total</h1>
            <div class="total-section">
            <asp:Label ID="Label1" runat="server" class="Label1" Text="Cart Total:"></asp:Label>
            <asp:Label ID="LblCartTotal" class="LblCartTotal" runat="server" ></asp:Label>
            <span>/- Only</span><br />
                </div>
            <asp:Button ID="BtnCheckout" CssClass="BtnCheckout" runat="server" Text="Place order" OnClick="BtnCheckout_Click" />
        </div>

    </div>


</asp:Content>
