using ReservationsDolphinDiscoveryII.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservationsDolphinDiscoveryII
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uxDropDownListCities.DataTextField = Cities.DisplayMember;
                uxDropDownListCities.DataValueField = Cities.ValueMember;
                uxDropDownListCities.DataSource = Cities.GetCities();
                uxDropDownListCities.DataBind();
                uxDropDownListCities.Items.Insert(0, new System.Web.UI.WebControls.ListItem("- Seleccionar -", String.Empty));

                uxDropDownListHotels.Enabled = false;
             }

        }


        protected void UxDropDownListCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pkCity = 0;

            if (((DropDownList)sender).SelectedIndex > 0)
            {
                uxDropDownListHotels.Enabled = true;
                uxDropDownListHotels.DataSource = null;
                uxDropDownListHotels.DataBind();
                pkCity = int.Parse(((DropDownList)sender).SelectedValue);

                uxDropDownListHotels.DataTextField = Hotels.DisplayMember;
                uxDropDownListHotels.DataValueField = Hotels.ValueMember;
                uxDropDownListHotels.DataSource = Hotels.GetHotel(Convert.ToInt32(pkCity));
                uxDropDownListHotels.DataBind();
                UpdatePanelHotels.Update();
            }
            else {
                uxDropDownListHotels.Enabled = false;
                uxDropDownListHotels.Items.Clear();
                uxDropDownListHotels.Items.Insert(0, new System.Web.UI.WebControls.ListItem("- Seleccionar -", String.Empty));
                UpdatePanelHotels.Update();
            }

        }

        protected void uxButtonSubmitReservation_Click(object sender, EventArgs e)
        {

            //DateTime startDate = Convert.ToDateTime(Request.QueryString["uxInputDateStart"].ToString());
            //DateTime endDate = Convert.ToDateTime(Request.QueryString["uxInputDateEnd"].ToString());
            //int pkCity = Convert.ToInt32(Request.QueryString["uxDropDownListCities"].ToString());
            //int pkHotel = Convert.ToInt32(Request.QueryString["uxDropDownListHotels"].ToString());
            //int nAdult = Convert.ToInt32(Request.QueryString["uxInputAdult"].ToString());
            //int nChildren = Convert.ToInt32(Request.QueryString["uxInputChilden"].ToString());
            Response.Redirect(
                "~/Servicios/Services.aspx?uxInputDateStart=" + uxInputDateStart.Value.ToString() + 
                "&uxInputDateEnd=" + uxInputDateEnd.Value.ToString() + "&uxDropDownListCities=" + uxDropDownListCities.SelectedValue.ToString() +
                "&uxDropDownListHotels=" + uxDropDownListHotels.SelectedValue.ToString() + "&uxInputAdult=" + uxInputAdult.Value.ToString()+
                "&uxInputChilden=" + uxInputChilden.Value.ToString()
                );
        }
    }
}