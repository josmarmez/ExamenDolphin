using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservationsDolphinDiscoveryII.Servicios
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
                if (!IsPostBack)
                {

                        //DateTime startDate = Request.QueryString["uxInputDateStart"].ToString());
                        //DateTime endDate = Request.QueryString["uxInputDateEnd"].ToString());
                        //int pkCity = Convert.ToInt32(Request.QueryString["uxDropDownListCities"].ToString());
                        //int pkHotel = Convert.ToInt32(Request.QueryString["uxDropDownListHotels"].ToString());
                        //int nAdult = Convert.ToInt32(Request.QueryString["uxInputAdult"].ToString());
                        //int nChildren = Convert.ToInt32(Request.QueryString["uxInputChilden"].ToString());


                        string a = Request.QueryString["uxInputDateStart"];
                        string b = Request.QueryString["uxInputDateEnd"];
                        string c = Request.QueryString["uxDropDownListCities"];
                        string d = Request.QueryString["uxDropDownListHotels"];
                        string e = Request.QueryString["uxInputAdult"];
                        string f = Request.QueryString["uxInputChilden"];




                uXLabelServicio.InnerText = " Aire acondicionado, alberca, cafetería, restaurante, tabaqueria, wifi(con costo),cable TV.";
                        uXLabelhabitSenc.InnerText = "Habitación con 1 cama Matrimonial.";
                        uXLabelhabitDoble.InnerText = "Habitación con 2 camas matrimoniales o bien una king size";

                        if (pkCity == 1 || pkCity == 2)
                        {
                            uXLabelDescription.Text = " En sus instalaciones, ideales para familias, hay dos piscinas, una de ellas para niños, jacuzzi solo para adulto, un bar y dos restaurantes, incluyendo uno con vista al mar Caribe. El hotel dispone de un área de lectura y ofrece estacionamiento.";
                        }
                        else if (pkCity == 3 || pkCity == 4)
                        {
                            uXLabelDescription.Text = "Impresionante arquitectura colonial. Para viajeros de placer o de negocios, poseé todos los servicios y amenidades que te permitirán disfrutar tu estadía al máximo.";

                         }

                }
         
        }

       
    }
}