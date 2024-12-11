<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adaugare.aspx.cs" Inherits="Proiect_TI_1.Adaugare" %>
<asp:Content ID="Adaugare" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="mt-5">
            <h2>Adăugare angajat în gestiune</h2>
            <br />
            <form>
                <div class="row">
                    <div class="col-md-6 offset-md-3">
                        <div class="form-group">
                            <label for="nume">Nume</label>
                            <input type="text" class="form-control" id="nume" name="nume" placeholder="Introduceți numele">
                        </div>
                        <div class="form-group">
                            <label for="prenume">Prenume</label>
                            <input type="text" class="form-control" id="prenume" name="prenume" placeholder="Introduceți prenumele">
                        </div>
                        <div class="form-group">
                            <label for="functie">Funcție</label>
                            <input type="text" class="form-control" id="functie" name="functie" placeholder="Introduceți funcția">
                        </div>
                        <div class="form-group">
                            <label for="salar">Salariu de bază</label>
                            <input type="text" class="form-control" id="salar" name="salar" placeholder="Introduceți salariul de bază">
                        </div>
                        <div class="form-group">
                            <label for="spor">Spor (%)</label>
                            <input type="text" class="form-control" id="spor" name="spor" placeholder="Introduceți sporul în procente">
                        </div>
                        <div class="form-group">
                            <label for="premii">Premii brute</label>
                            <input type="text" class="form-control" id="premii" name="premii" placeholder="Introduceți valoarea premiilor brute">
                        </div>
                        <div class="form-group">
                            <label for="retineri">Rețineri</label>
                            <input type="text" class="form-control" id="retineri" name="retineri" placeholder="Introduceți valoarea reținerilor">
                        </div>
                        <asp:Image runat="server"></asp:Image>Imagine
                        <div class="form-group">
                            <label for="imagine">Imagine</label>
                            <input id="imagine" class="form-control-file" name="imagine" type="file" accept=".jpg, .jpg, .png" runat="server" /><br />
                            
                        </div>
                        <asp:Image runat="server"></asp:Image>
                        <br />
                        <asp:Button ID="btnAdaugare" runat="server" Text="Adăugare" OnClick="AdaugaAngajat" CssClass="btn btn-primary" />
                </div>
            </form>
        </div>
    </div>  
</asp:Content>