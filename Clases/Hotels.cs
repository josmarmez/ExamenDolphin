using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ReservationsDolphinDiscoveryII.Clases
{
    public class Hotels
    {

        public static string ValueMember
        {
            get { return "pkHotel"; }
        }

        public static string DisplayMember
        {
            get { return "name"; }
        }

        #region

        public static DataTable GetHotel(int fkCity)
        {
            try
            {
                ParamTable param = new ParamTable(fkCity);
                DataBase db = new DataBase();

                param.Add("fkCity", fkCity);
                var tmpData = db.GetProcedure("spGetHotel", ref param);
                if (tmpData.Tables.Count > 0)
                {
                    return tmpData.Tables[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
    #endregion
}