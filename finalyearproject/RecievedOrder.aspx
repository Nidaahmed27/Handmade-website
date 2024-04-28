<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="RecievedOrder.aspx.cs" Inherits="finalyearproject.RecievedOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/admin/RecievedOrder.css" rel="stylesheet" />
    <div class="container">
    <h1 class="table-heading">RECIEVED ORDER DETAILS</h1>
    <table>
     
        <thead>
            <tr>
                <th>OrderId</th>
                <th>UserName</th>
                <th>UserEmail</th>
                <th>Mobile Number</th>
                <th>Address</th>
                <th>Pincode</th>
                <th>Order Date</th>
                <th>OrderItemId</th>
                <th>ProductID</th>
                <th>ProductName</th>
                <th>Price</th>
                <th>Order Status</th>
                <th>Edit</th>
            </tr>
        </thead>
        <tbody>
            
            <asp:Repeater ID="RepeaterRecievedOrders" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><asp:Literal ID="LiteralOrderID" runat="server" Text='<%# Eval("OrderID") %>'></asp:Literal></td>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("UserEmail") %></td>
                        <td><%# Eval("MobileNumber") %></td>
                        <td><%# Eval("Address") %></td>
                        <td><%# Eval("PinCode") %></td>
                        <td><%# Eval("OrderDate") %></td>
                        <td>
                            <asp:Literal ID="LiteralOrderItemID" runat="server" Text='<%# Eval("OrderItemID") %>'></asp:Literal></td>
                        <td><%# Eval("ProductID") %></td>
                        <td><%# Eval("ProductName") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%# Eval("OrderStatus") %></td>
                        <td>
                            <asp:Button ID="BtnOrderDeliverd" runat="server" Text="delivery done" OnClick="BtnOrderDeliverd_Click" class="Btn-delivered"/></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        
        </tbody>
    </table>
    

        </div>
</asp:Content>
