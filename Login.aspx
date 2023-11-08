<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KarateSchoolProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">Login</div>
                    <div class="card-body">
                        <asp:Label runat="server"  ID="lblErrorMessage"></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-2" placeholder="Username" />
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control mb-2" placeholder="Password" />
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary btn-block" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
