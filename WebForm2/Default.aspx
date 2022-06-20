<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <asp:DataGrid ID="movieGrid" runat="server" AlternatingItemStyle-BackColor="#0984ff" HorizontalAlign="Center" AlternatingItemStyle-ForeColor="White" HeaderStyle-Font-Size="Larger" OnSelectedIndexChanged="movieGrid_SelectedIndexChanged" Width="395px">
        <Columns>
            <asp:ButtonColumn
                runat="server"
                HeaderText="More Details"
                ButtonType="LinkButton"
                Text="Select"
                CommandName="Select"></asp:ButtonColumn>
                
        </Columns>
    </asp:DataGrid>

    <hr />
    <div style="text-align:center;" >
        <asp:TextBox ID="TextBox1" Text="None Selected" runat="server" CssClass="content" style="max-width:none; font-family:monospace;width :700px;"></asp:TextBox>
    </div>
    </asp:Content>
