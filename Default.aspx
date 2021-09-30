<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReservationsDolphinDiscoveryII._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
    <div class="col-md-2"></div>
    <div class="col-lg-8 ">
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 4"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="Imagenes/Cancun.jpg" class="d-block w-100" alt="Cancun">
                </div>
                <div class="carousel-item">
                    <img src="Imagenes/Cuernavaca.jpg" class="d-block w-100" alt="Cuernavaca">
                </div>
                <div class="carousel-item">
                    <img src="Imagenes/Guanajuato.jpg" class="d-block w-100" alt="Guanajuato">
                </div>
                <div class="carousel-item">
                    <img src="Imagenes/Riviera maya.jpg" class="d-block  w-100" alt="Riviera Maya">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
    <form class="row g-3 needs-validation" novalidate>

               <div class="row text-center">
                    <p class="h3">Reservaciones</p>
                </div>
                <div class="row">
                    <div class="form-group col-md-6">
                        <label for="uxFechaInicio" class="form-label">Fecha inicio</label>
                        <input type="date" class="form-control" runat="server" ID="uxInputDateStart" aria-describedby="emailHelp">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="uxFechaFinal" class="form-label">Fecha fin</label>
                        <input type="date" class="form-control" runat="server" ID="uxInputDateEnd" aria-describedby="emailHelp">
                    </div>

                </div>

                <div class="form-group">
                    <div class="form-group col-lg-12">
                        <label for="uxinputState" class="form-label">Destino:</label>         
                        <asp:DropDownList ID="uxDropDownListCities" CssClass="form-select" class="dropdown" runat="server" 
                            OnSelectedIndexChanged="UxDropDownListCities_SelectedIndexChanged" AutoPostBack="true" DataValueField="pkCity" >
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <div class="form-group col-lg-12">
                        <label for="uxinputState" class="form-label">Hotel:</label>
                        <asp:UpdatePanel ID="UpdatePanelHotels" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="uxDropDownListHotels" CssClass="form-select" runat="server">
                                     <asp:ListItem Value="">- Seleccione -</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="uxDropDownListCities" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-6">
                        <label for="uxFechaInicio" class="form-label">Adultos</label>
                        <input type="number" runat="server" class="form-control" ID="uxInputAdult" aria-describedby="emailHelp">

                    </div>
                    <div class="form-group col-md-6">
                        <label for="uxFechaFinal" class="form-label">Menores</label>
                        <input type="number"  runat="server" class="form-control" ID="uxInputChilden" aria-describedby="emailHelp">
                    </div>

                </div>

                <div class="mt-3">
                    <asp:Button ID="uxButtonSubmit"
                        runat="server" 
                        CssClass="btn btn-success" 
                        Text="Consultar"  
                        OnClick="uxButtonSubmitReservation_Click"/>
                </div>

     </form>
</asp:Content>


