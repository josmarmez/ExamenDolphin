<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="ReservationsDolphinDiscoveryII.Servicios.Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
    <div class="col-lg-6 ">
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 4"></button>
            </div>
            <div class="carousel-inner">
                     <div class="carousel-item active">
                    <img src="../Imagenes/Cancun.jpg" class="d-block w-100" alt="Cancun">
                </div>
                <div class="carousel-item">
                    <img src="../Imagenes/Cuernavaca.jpg" class="d-block w-100" alt="Cuernavaca">
                </div>
                <div class="carousel-item">
                    <img src="../Imagenes/Guanajuato.jpg" class="d-block w-100" alt="Guanajuato">
                </div>
                <div class="carousel-item">
                    <img src="../Imagenes/Riviera maya.jpg" class="d-block  w-100" alt="Riviera Maya">
                </div>
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
    
    <div class="col-md-6 p-6">
        <div class="text-right">
            <h3 class="h3"></h3>
            <div class="p">                
                <asp:Label ID="uXLabelHotelName" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="text-body">            
            <asp:Label ID="uXLabelDescription" runat="server" Text="Label"></asp:Label>       
        </div>

        <div>            
           
                <div class="form-check">          
                        
                        <asp:RadioButton ID="uxRadioButtonSencilla" Cssclass="form-check-input" runat="server"/> 
                        <label class="form-check-label"  ID="uXLabelSencilla"  runat="server"></label>
                        <label class="form-check-label"  ID="uXLabelhabitSenc"  runat="server"></label>
                </div>
               <div class="form-check">          
                        
                        <asp:RadioButton ID="uxRadioButtonDoble" Cssclass="form-check-input" runat="server" />  
                         <label class="form-check-label" ID="uXLabelDoble"  runat="server"></label>
                         <label class="form-check-label"  ID="uXLabelhabitDoble"  runat="server"></label>
                </div>
      
        </div>
        <div>
             <label class="form-check-label" ID="uXLabelServicio"  runat="server"></label>
        </div>


        <div class="glyphicon-align-center">
            <button class="btn btn-warning" >Reservar</button>

        </div>
        
    </div>


</asp:Content>
