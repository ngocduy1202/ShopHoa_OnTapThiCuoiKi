<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="ShopHoa_OnTapThiCuoiKi.ChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div id="item" style="display:inline-block; width:100%; border:1px solid red; padding:20px" >
                    <div class="img" style="float:left">
                        <asp:Image ID="Image1" ImageUrl='<%# "~/images/"+Eval("HinhAnh") %>' Width="200px" runat="server" />
                    </div>
                    <div class="mota" style=" float:right">
                        <div>
                            Mã hoa: <asp:Label ID="Label1" runat="server" Text='<%#Eval("MaHoa") %>'></asp:Label>
                            
                        </div>
                        <div>
                            Tên hoa: <asp:Label ID="Label2" runat="server" Text='<%#Eval("TenHoa") %>'></asp:Label>
                            
                        </div>
                        <div>
                            Mô tả hoa: <asp:Label ID="Label3" runat="server" Text='<%#Eval("MoTa") %>'></asp:Label>
                            
                        </div>
                        <div>
                            Đơn giá: <asp:Label ID="Label4" runat="server" Text='<%# Eval("DonGia","{0:0;0}")%>'></asp:Label>  vnđ
                        </div>
                        <div>
                            Số lượng: 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("MaHoa") %>' OnClick="Button1_Click" Text="Thêm vào giỏ hàng" />
                        </div>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("MaHoa") %>' OnClick="LinkButton1_Click" runat="server">Giỏ hàng</asp:LinkButton>
                        
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
