<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="SanPhamHoa.aspx.cs" Inherits="ShopHoa_OnTapThiCuoiKi.SanPhamHoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" CellPadding="5" runat="server" RepeatColumns="3">
        <ItemTemplate>
            <div id="item" style="display:inline-block; border:1px solid blue; width:150px; height:250px">
                <div class="masp">
                    Mã hoa: <%#Eval("MaHoa") %>
                </div>
                <div class ="ten">
                    Tên hoa: <%#Eval("TenHoa") %>
                </div>
                <div class="hinh">
                    <asp:Image ID="Image1" ImageUrl ='<%# "~/images/"+Eval("HinhAnh") %>' Width="100px" runat="server" />
                </div>
                <div class="gia">
                    Đơn giá: <%#Eval("DonGia","{0:0;0}") %>
                </div>
                <div class ="mota">
                    Mô tả: <%# Eval("MoTa") %>
                </div>
                <div class="chitiet">
                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("MaHoa") %>' OnClick="LinkButton1_Click" runat="server">Chi tiết</asp:LinkButton>
                </div>
                
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
