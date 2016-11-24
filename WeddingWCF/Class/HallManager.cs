using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WeddingWCF.Class
{
    public class HallManager: User
    {

        JavaScriptSerializer ser = new JavaScriptSerializer();
        public string AddHall(Hall hall)
        {
            DataSet1TableAdapters.HALLSTableAdapter UDA = new DataSet1TableAdapters.HALLSTableAdapter();
            int IsAdd = 1; bool IsActive = true; String Message = "";
            try
            {
                UDA.InsertNewHall(hall.hallName, hall.hallDesc, hall.phone, hall.Img, hall.Logtii, hall.Latitle, hall.City_Id,
                    hall.Dis_Hall, hall.Street, hall.Men_Capacity, hall.Women_Capacity, hall.Services_Hall, IsActive, hall.ID_Email);
                    
                Message = "Your Wedding Hall is created succefully";
                IsAdd = 1;
            }
            catch (Exception ex)
            {
                IsAdd = 0;
                Message = ex.Message;//"cannot add your infromation" 
            }
            var jsonData = new
            {
                IsAdd = IsAdd,
                Message = Message
            };
            return ser.Serialize(jsonData);
        }

    }
    //---------------------------------------------

}