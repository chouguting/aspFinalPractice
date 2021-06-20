<%@ Page Language="VB" AutoEventWireup="false" CodeFile="final.aspx.vb" Inherits="final" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            一、
            <asp:Button ID="newCookieButton" runat="server" Text="新增多鍵Cookie" />
            &nbsp;
            <asp:Button ID="readCookieButton" runat="server" Text="讀取多鍵Cookie" />
            &nbsp;
            <asp:Button ID="deleteCookieButton" runat="server" Text="刪除多鍵Cookie" />
            <br/>
            <asp:Label ID="cookieLabel" runat="server" Text="" ForeColor="Blue"></asp:Label>
            <hr/>
            二、
            <asp:Label ID="dataSetLabel" runat="server" ForeColor="blue" Text=""></asp:Label>

            <hr />
            三、使用者名稱
            <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="loginButton" runat="server" Text="輸入" />
            <br/>

            <asp:CustomValidator ID="userNameCustomValidator" ForeColor="red" runat="server" ErrorMessage="不可包含root或以admin開頭!"></asp:CustomValidator>

            <br/>
            <asp:Label ID="userNameLabel" runat="server" ForeColor="blue" Text=""></asp:Label>
            <hr/>
            四、<asp:Button ID="showInstructorButton" runat="server" Text="顯示Instructors資料表" />
            <br/>
            <asp:Label ID="instructorLabel" runat="server" ForeColor="blue" Text=""></asp:Label>
            <hr/>
            五、
            <table style="height: 62px; width: 241px">
                <tr>
                    <td>
                        <asp:ListBox ID="leftListBox" runat="server" SelectionMode="Multiple" Height="210px" Width="128px" DataSourceID="SqlDataSource1" DataTextField="eid" DataValueField="eid">
                            
                        </asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [eid] FROM [Classes]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="toRightButton" runat="server" Text=">" Width="64px" />
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="toLeftButton" runat="server" Text="<" Width="64px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:ListBox ID="rightListBox" runat="server" SelectionMode="Multiple" Height="216px" Width="131px" DataSourceID="SqlDataSource2" DataTextField="sid" DataValueField="sid">
                        </asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [sid] FROM [Classes]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            <hr/>
            六、
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="departmentRadioButtonList" runat="server" DataSourceID="SqlDataSource3" DataTextField="major" DataValueField="major" AutoPostBack="True"></asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:GridView ID="dataGridView" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="sid" DataSourceID="SqlDataSource4">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="sid" HeaderText="sid" ReadOnly="True" SortExpression="sid" />
                                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                <asp:BoundField DataField="tel" HeaderText="tel" SortExpression="tel" />
                                <asp:BoundField DataField="birthday" HeaderText="birthday" SortExpression="birthday" />
                                <asp:BoundField DataField="major" HeaderText="major" SortExpression="major" />
                            </Columns>
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            


            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [major] FROM [Students]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [Students] WHERE ([major] = @major)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="departmentRadioButtonList" Name="major" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <hr />
            七、
            <br/>
            <asp:DropDownList ID="browserInfoDropDownList" runat="server" AutoPostBack="True">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>瀏覽器的名稱</asp:ListItem>
                <asp:ListItem>瀏覽器編號</asp:ListItem>
                <asp:ListItem>是否支援Cookies</asp:ListItem>
                <asp:ListItem>是否支援JavaApplets</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="showAll" runat="server" Text="全部顯示" />
            <br/>
            <asp:Label ID="browserInfoLabel" ForeColor="White" BorderStyle="Ridge" BackColor="Black" Width="200" runat="server" Text=""></asp:Label>

        </div>
        

    </form>
</body>
</html>
