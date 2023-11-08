<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="KarateSchoolProject.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <h1>Welcome, <asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label></h1>
            
            <asp:GridView ID="gvPayments" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SectionName" HeaderText="Section Name" />
                    <asp:BoundField DataField="InstructorFirstName" HeaderText="Instructor First Name" />
                    <asp:BoundField DataField="InstructorLastName" HeaderText="Instructor Last Name" />
                    <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>

</asp:Content>
