<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="ShopHoa_OnTapThiCuoiKi.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:inline-block">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="203px" Width="582px" OnRowCommand="GridView1_RowCommand" >
        <Columns>
            <%--<asp:BoundField HeaderText="Tên ĐN" DataField="TenDN"/>--%>
            <asp:BoundField HeaderText="Mã Hoa" DataField="MaHoa"/>
            <asp:BoundField HeaderText="Số Lượng" DataField="SoLuong"/>            
            <asp:BoundField HeaderText="Đơn Giá" DataField="DonGia"/>
            <asp:BoundField HeaderText="Thành Tiền" DataField="ThanhTien"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CommandName="btdel" runat="server">Xoá</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Height="203px" Width="582px" OnRowDeleting="GridView2_RowDeleting" >
        <Columns>
            <asp:BoundField HeaderText="Tên ĐN" DataField="TenDN"/>
            <asp:BoundField HeaderText="Mã Hoa" DataField="MaHoa"/>
            <asp:BoundField HeaderText="Số Lượng" DataField="SoLuong"/>            
            <asp:BoundField HeaderText="Đơn Giá" DataField="DonGia"/>
            <asp:BoundField HeaderText="Thành Tiền" DataField="ThanhTien"/>
            <asp:CommandField DeleteText="Xoá" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    Tong tien: <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    
    
</asp:Content>
