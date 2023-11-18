<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="KarateSchoolProject.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <h1>Welcome, <asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label></h1>
            
           <asp:GridView ID="gvPayments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
    <Columns>
        <asp:BoundField DataField="SectionName" HeaderText="Section Name" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" >
<HeaderStyle CssClass="col-md-4"></HeaderStyle>

<ItemStyle CssClass="col-md-4"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="SectionStartDate" HeaderText="Section Start Date" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" >
<HeaderStyle CssClass="col-md-4"></HeaderStyle>

<ItemStyle CssClass="col-md-4"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="InstructorName" HeaderText="Instructor Name" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" >
<HeaderStyle CssClass="col-md-4"></HeaderStyle>

<ItemStyle CssClass="col-md-4"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="SectionFee" HeaderText="Section Fee" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" >
<HeaderStyle CssClass="col-md-4"></HeaderStyle>

<ItemStyle CssClass="col-md-4"></ItemStyle>
        </asp:BoundField>
    </Columns>
               <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
               <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
               <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
               <SortedAscendingCellStyle BackColor="#F7F7F7" />
               <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
               <SortedDescendingCellStyle BackColor="#E5E5E5" />
               <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>

        <h4>Total Fees: <asp:Label runat="server" ID="lblTotalFee"></asp:Label></h4>
        </div>

</asp:Content>
