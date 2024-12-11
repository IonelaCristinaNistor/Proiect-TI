<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fluturasi.aspx.cs" Inherits="Proiect_TI_1.Fluturasi" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Fluturasi" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="mt-5">
            <h2>Fluturași de salariu</h2>
        </div>
        <br />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BorderStyle="Solid" Height="50px" Width="350px" ToolPanelView="None" />
    </div>
</asp:Content>
