using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ReservationsDolphinDiscoveryII.Clases
{
    public class Cities
    {
        public static string ValueMember
        {
            get { return "pkCity"; }
        }

        public static string DisplayMember
        {
            get { return "name"; }
        }

        #region

        public static DataTable GetCities()
        {
            try
            {
                ParamTable param = new ParamTable(1);
                DataBase db = new DataBase();

                //param.Add("pkCustomer", _id);
                var tmpData = db.GetProcedure("spGetCyties", ref param);
                if (tmpData.Tables.Count > 0)
                {
                    return tmpData.Tables[0];
                }
                else
                {
                    return null;
                }

                //return db.GetProcedure("spGetInvoicingContact", ref param).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        #endregion

    }


}