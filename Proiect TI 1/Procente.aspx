<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Procente.aspx.cs" Inherits="Proiect_TI_1.Procente" %>

<asp:Content ID="Procente" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="container text-center">
            <div class="mt-5">
                <h2>Modificare procente salarizare</h2>
            </div>
        </div>
        <br />
        <br />
        <center>
            <asp:Label ID="InfoLabel" runat="server" Text="Zonă protejată: Pentru a modifica valorile procentuale ale grilei de salarizare, introduceți parola."></asp:Label>
            <br />
            <asp:Panel ID="LoginPanel" runat="server">
                <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Autentificare" OnClick="LoginButton_Click" />
                <br />
                <br />
                <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>

            </asp:Panel>
            <br />
            <br />

            <asp:Panel ID="DataPanel" runat="server" Visible="false">
                <asp:GridView ID="ProcenteGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowDataBound="ProcenteGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="cas_procent" HeaderText="CAS (%)" />
                        <asp:BoundField DataField="cass_procent" HeaderText="CASS (%)" />
                        <asp:BoundField DataField="impozit_procent" HeaderText="Impozit (%)" />
                    </Columns>
                    <RowStyle CssClass="gridview-row" />
                </asp:GridView>
                <br />
                <asp:Button ID="BackButton" runat="server" Text="Înapoi" OnClick="BackButton_Click" />

            </asp:Panel>
        </center>
    </div>

    <script type="text/javascript">

        function editCell(element, columnName, columnIndex) {
            var newValue = prompt("Introduceți o valoare nouă (în procente):");
            console.log("Coloană:", columnName, "Noua valoare:", newValue);
            if (newValue) {
                $.ajax({
                    type: "POST",
                    url: "Procente.aspx/UpdateProcenteValue",
                    data: JSON.stringify({ columnName: columnName, newValue: parseFloat(newValue) }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert(response.d);
                        location.reload();
                    },
                    error: function (xhr, status, error) {
                        alert("A apărut o eroare: " + error);
                    }
                });
            }
        }

    </script>
</asp:Content>
