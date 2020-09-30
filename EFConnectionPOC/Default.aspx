<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="EFConnectionPOC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting Started</h2>
            <select id="testSelect" runat="server" clientidmode="Static" required>
                <option value="1" selected>Development</option>
                <option value="2">QA</option>
            </select>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            
            
       
        </div>
        <div class="col-md-4">
            <h2>Display connection string after done connect </h2>
            <p>
                <asp:Button ID="btnDisplay" runat="server" Text="Display connection" />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </p>
           
        </div>
       
    </div>

</asp:Content>
