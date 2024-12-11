<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatPlata.aspx.cs" Inherits="Proiect_TI_1.StatPlata" %>

<asp:Content ID="StatPlata" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5" id="printableContent">
        <style>
            @media print {
                .print-align-right {
                    float: right;
                }

                .right-align-print {
                    text-align: right !important;
                }


                .print-order-first {
                    order: -1;
                }

                .total-label {
                    text-align: right;
                    float: right;
                    clear: both;
                }

                @page {
                    size: 297mm 420mm; /*A3*/
                }
            }
        </style>
        <div class="container text-center">
            <div class="mt-5 print-hide">
                <h2>Stat de plată</h2>
            </div>
        </div>
        <br />
        <div class="row justify-content-end mb-3">
            <div class="col-auto">
                <asp:Label ID="lblCurrentDate" runat="server" Text="Data: " CssClass="print-align-right">"></asp:Label>
            </div>
        </div>
        <br />
        <div class="text-center mt-3 mb-3 print-hide">
            <asp:Button ID="btnPrintare" runat="server" Text="Tipărire" CssClass="btn btn-primary" OnClientClick="PrintContent();return false;" />
        </div>
        <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                CssClass="table" BorderStyle="None" Width="100%">
                <Columns>
                    <asp:BoundField DataField="nr_crt" HeaderText="Nr. Crt" SortExpression="nr_crt" />
                    <asp:BoundField DataField="nume" HeaderText="Nume" SortExpression="nume" />
                    <asp:BoundField DataField="prenume" HeaderText="Prenume" SortExpression="prenume" />
                    <asp:BoundField DataField="functie" HeaderText="Functie" SortExpression="functie" />
                    <asp:BoundField DataField="salar_baza" HeaderText="Salar Baza" SortExpression="salar_baza" />
                    <asp:BoundField DataField="spor" HeaderText="Spor" SortExpression="spor" />
                    <asp:BoundField DataField="premii_brute" HeaderText="Premii Brute" SortExpression="premii_brute" />
                    <asp:BoundField DataField="total_brut" HeaderText="Total Brut" SortExpression="total_brut" />
                    <asp:BoundField DataField="retineri" HeaderText="Retineri" SortExpression="retineri" />
                    <asp:TemplateField HeaderText="Imagine">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="50" Height="50"
                                ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("imagine")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Total Salary Display -->
            <asp:Label ID="Label1" runat="server" Text="Total Salar Baza: " />

            <asp:SqlDataSource runat="server" ID="SqlDataSource1"></asp:SqlDataSource>
            <br />
            <div class="row justify-content-end mt-3 right-align-print">
                <div class="col-auto">
                </div>
            </div>
        </div>
    </div>

    <script>
        function displayCurrentDate() {
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0');
            var yyyy = today.getFullYear();

            var currentDate = dd + '/' + mm + '/' + yyyy;
            document.getElementById('MainContent_lblCurrentDate').innerText = 'Data: ' + currentDate;
        }

        window.onload = function () {
            displayCurrentDate();
        };

        function PrintContent() {
            var printWindow = window.open('', '_blank');
            printWindow.document.write('<html><head><title>Stat de plată</title>');
            printWindow.document.write('<style>.print-hide { display: none; } .text-center { text-align: center; }</style>');
            printWindow.document.write('</head><body>');
            printWindow.document.write(document.getElementById("printableContent").innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
