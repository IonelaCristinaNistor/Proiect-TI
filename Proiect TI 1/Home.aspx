<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proiect_TI_1.Home" %>
<asp:Content ID="HomePage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-lg-8 col-md-8">
                <h2 class="display-4">Bine ați venit la Aplicația de Calcul al Salariilor</h2>
                <p class="lead">
                    Această aplicație permite calculul salariilor într-o companie și gestionarea datelor angajaților.
                </p>
                <p>
                    <strong>Descoperiți opțiunile aplicației:</strong>
                </p>
                <div class="list-group">
                    <div class="list-group-item list-group-item-info bg-info rounded-4 m-1">
                        <h5 class="mb-1"><strong>1. ADĂUGARE / ȘTERGERE / MODIFICARE DATE ANGAJAT</strong></h5>
                        <p class="mb-1">Pentru a adăuga, șterge sau modifica datele unui angajat, accesați secțiunea "Introducere date" și selectați opțiunea dorită. Aici veți găsi următoarele opțiuni:</p>
                        <ul class="list-unstyled">
                            <li><strong>Actualizare date:</strong> Modificați informațiile angajaților, căutându-i după nume sau prenume, și salvați modificările sau renunțați.</li>
                            <li><strong>Adăugare:</strong> Adăugați un nou angajat completând detaliile sale și calculând salariul pe baza câmpurilor corespunzătoare.</li>
                            <li><strong>Ștergere:</strong> Căutați angajații și selectați persoana pe care doriți să o ștergeți, confirmând acțiunea.</li>
                        </ul>
                    </div>
                    <div class="list-group-item list-group-item-warning bg-warning  rounded-4 m-1">
                        <h5 class="mb-1"><strong>2. RAPOARTE - STAT DE PLATĂ / FLUTURAȘI ANGAJAȚI</strong></h5>
                        <p class="mb-1">Pentru a vizualiza rapoartele cu statul de plată și fluturașii angajaților, accesați secțiunea "Rapoarte" și selectați opțiunea dorită.</p>
                        <ul class="list-unstyled">
                            <li><strong>Stat de plată:</strong> Vizualizați raportul cu datele angajaților și totalurile salariale relevante.</li>
                            <li><strong>Fluturași:</strong> Vizualizați fluturașul de salariu pentru fiecare angajat în parte.</li>
                        </ul>
                    </div>
                    <div class="list-group-item list-group-item-success bg-success  rounded-4 m-1">
                        <h5 class="mb-1"><strong>3. MODIFICARE PROCENTE SALARIZARE</strong></h5>
                        <p class="mb-1">Modificați procentele salariale conform noii grile de salarizare, accesând secțiunea "Procente".</p>
                    </div>
                </div>
            </div>


            <div class="col-lg-4 col-md-4 text-center">
                <img src="images/salary-calculation.jpg" alt="Salary Calculation" class="img-fluid rounded mb-4" />
            </div>
        </div>


        <div class="text-center mt-5">
            <asp:Button ID="btnCreateTables" runat="server" Text="Creare și populare tabele" CssClass="btn btn-primary btn-lg rounded-5" OnClick="btnCreateTables_Click" />
        </div>
    </div>
</asp:Content>
