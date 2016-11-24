using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WeddingWCF.Class
{
    public class Booking
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        public int ID_BOOKING { get; set; }
        public int ID_HALL { get; set; }
        public string ID_Email { get; set; }
        public String DATE_BOOKING { get; set; }
        public int STATUE_BOOKING { get; set; }
        public string NOTE_BOOKING { get; set; }
        public List<Hall> HallListing = new List<Hall>();


        public string addBooking(Booking booking)
        {
            DataSet1TableAdapters.BOOKINGTableAdapter UDA = new DataSet1TableAdapters.BOOKINGTableAdapter();
            int IsAdd = 0;
            String Message = "";
            bool IsBooking = check_Booking(booking.ID_HALL, booking.DATE_BOOKING);
            if (IsBooking == false)
            {
                Boolean sucess = InsertNewBooking(booking);
                if (sucess == true)
                {
                    Message = "تم تسجيل حجزكم بنجاح";
                    IsAdd = 1;
                }
                else
                {
                    //"cannot add your infromation"
                    IsAdd = 0;
                    Message = "can not add your  Booking ";
                }
            }
            else { Message = "يوجد لديكم حجز سابق !!!!"; }
            var jsonData = new
            {
                IsAdd = IsAdd,
                Message = Message
            };
            return ser.Serialize(jsonData);
        }

        //Mehod to check do hava any booking in  hall  in same data
        public bool check_Booking(int ID_HALL, string DATE_BOOKING)
        {
            bool succes = false;
            DataSet1TableAdapters.BOOKINGTableAdapter UDA = new DataSet1TableAdapters.BOOKINGTableAdapter();
            DataSet1.BOOKINGDataTable UTable;
            DataSet1.BOOKINGRow URow;
            UTable = UDA.GetDataBooking();

            if (UTable.Rows.Count > 0) // we hava account
            {
                for (int i = 0; i <= UTable.Rows.Count - 1; i++)
                {
                    URow = UTable.Rows[0] as DataSet1.BOOKINGRow;
                    if (URow.ID_HALL == ID_HALL)
                    {
                        succes = true;
                    }
                    else
                    {
                        succes = false;

                    }
                }
            }
            return succes;
        }
        //---------------------------------------------------------------------
        //Methoed to insert New booking
        public Boolean InsertNewBooking(Booking booking)
        {

            DataSet1TableAdapters.BOOKINGTableAdapter UDA = new DataSet1TableAdapters.BOOKINGTableAdapter();
            int STATUE_BOOKING = 1;
            bool sucess = false;
            try
            {
                UDA.InsertBooking(booking.ID_Email, booking.ID_HALL, booking.DATE_BOOKING, STATUE_BOOKING, booking.NOTE_BOOKING);
                sucess = true;
            }
            catch (Exception ex)
            {
                sucess = false;
                //"cannot add your infromation" 
            }
            return sucess;
        }
        //---------------------------------------------------------------------
        // Method to git list of district to serch by district or city
        public string Getdistrict()
        {
            DataSet1TableAdapters.CityTableAdapter UDA = new DataSet1TableAdapters.CityTableAdapter();
            DataSet1.CityDataTable UTable;
            DataSet1.CityRow URow;

            District[] DistrictData = null;
            String Message = "";
            try
            {
                UTable = UDA.GetCtiy();
                DistrictData = new District[UTable.Rows.Count];
                if (UTable.Rows.Count > 0) // we hava district
                {
                    int cont = 0;
                    for (int i = 0; i < UTable.Rows.Count; i++)
                    {
                        URow = UTable.Rows[0] as DataSet1.CityRow;
                        DistrictData[cont] = new District();
                        DistrictData[cont].iDdistrict = Convert.ToInt32(UTable.Rows[i]["ID_Ctiy"]);
                        DistrictData[cont].namedistrict = Convert.ToString(UTable.Rows[i]["Name_Ctiy"]);
                        cont++;
                    }
                }
                else
                {
                    Message = "Not found Ctiy !!!!";

                }
            }
            catch (Exception ex)
            {
                Message = "Noting !!!!";
                //"cannot Get  infromation about district" 
            }
            var jsonData = new
            {
                districtData = DistrictData,
                Message = Message
            };
            return ser.Serialize(jsonData);
        }
        //---------------------------------------------------------------------
        //git list of saercHallsAvailable  to GetHallListing to serch by id and date
        public string saercHallsAvailable(int ID_City, string date)
        {
            DataSet1TableAdapters.View_1TableAdapter UDA = new DataSet1TableAdapters.View_1TableAdapter();
            DataSet1.View_1DataTable UTable;
            DataSet1.View_1Row URow;
            Hall[] hallData = null; String Message = ""; int hasHall = 0;
            try
            {
                UTable = UDA.GetDataByCITYandDATE(ID_City, date);
                hallData = new Hall[UTable.Rows.Count];
                if (UTable.Rows.Count > 0) // we hava district
                {
                    int cont = 0;
                    for (int i = 0; i < UTable.Rows.Count; i++)
                    {
                        URow = UTable.Rows[0] as DataSet1.View_1Row;
                        hallData[cont] = new Hall();
                        hallData[cont].hallId = Convert.ToInt32(UTable.Rows[i]["ID_HALL"]);
                        hallData[cont].hallName = Convert.ToString(UTable.Rows[i]["NAME_HALL"]);
                        hallData[cont].price = Convert.ToDouble(UTable.Rows[i]["Price"]);
                        hallData[cont].phone = Convert.ToString(UTable.Rows[i]["PHON_HALL"]);
                        hallData[cont].Img = Convert.ToString(UTable.Rows[i]["IMG_HALL"]);
                        hallData[cont].Dis_Hall = Convert.ToString(UTable.Rows[i]["Dis_Hall"]);
                        hallData[cont].Street = Convert.ToString(UTable.Rows[i]["Street_Hall"]);
                        hallData[cont].Men_Capacity = Convert.ToDouble(UTable.Rows[i]["Men_Capacity"]);
                        hallData[cont].Women_Capacity = Convert.ToDouble(UTable.Rows[i]["Women_Capacity"]);
                        cont++;
                        Message = "There are " + cont + "halls";
                        hasHall = cont;
                    }
                }
                else
                {

                    Message = "Not found hall !!!!";
                    hasHall = 0;
                }

            }
            catch (Exception ex)
            {
                hasHall = 0;
                Message = "error !!!!";
                //"cannot Get  infromation about district" 
            }
            var jsonData = new
            {
                hallData = hallData,
                Message = Message,
                hasHall = hasHall
            };
            return ser.Serialize(jsonData);

        }
        //--------------------------------------------------------
        // Get HallDescription to search by id hall and date
        public string GetHallDescription(int ID_Hall, String date)
        {
            DataSet1TableAdapters.View_1TableAdapter UDA = new DataSet1TableAdapters.View_1TableAdapter();
            DataSet1.View_1DataTable UTable;
            DataSet1.View_1Row URow;
            Hall[] hallData = null; String Message = ""; int hasHall = 0;
            try
            {
                UTable = UDA.GetDataByIDHALLAndData(ID_Hall, date);
                hallData = new Hall[UTable.Rows.Count];
                if (UTable.Rows.Count > 0) // we hava district
                {
                    int cont = 0;
                    for (int i = 0; i < UTable.Rows.Count; i++)
                    {
                        URow = UTable.Rows[0] as DataSet1.View_1Row;
                        hallData[cont] = new Hall();
                        hallData[cont].hallId = Convert.ToInt32(UTable.Rows[i]["ID_HALL"]);
                        hallData[cont].CH_ID = Convert.ToInt32(UTable.Rows[i]["CH_ID"]);
                        hallData[cont].hallName = Convert.ToString(UTable.Rows[i]["NAME_HALL"]);
                        hallData[cont].hallDesc = Convert.ToString(UTable.Rows[i]["Des_HALL"]);
                        hallData[cont].price = Convert.ToDouble(UTable.Rows[i]["Price"]);
                        hallData[cont].phone = Convert.ToString(UTable.Rows[i]["PHON_HALL"]);
                        hallData[cont].Img = Convert.ToString(UTable.Rows[i]["IMG_HALL"]);
                        hallData[cont].Services_Hall = Convert.ToString(UTable.Rows[i]["Services_Hall"]);
                        hallData[cont].Latitle = Convert.ToDouble(UTable.Rows[i]["Latitle"]);
                        hallData[cont].Logtii = Convert.ToDouble(UTable.Rows[i]["Logtii"]);
                        hallData[cont].Dis_Hall = Convert.ToString(UTable.Rows[i]["Dis_Hall"]);
                        hallData[cont].Street = Convert.ToString(UTable.Rows[i]["Street_Hall"]);
                        hallData[cont].Men_Capacity = Convert.ToDouble(UTable.Rows[i]["Men_Capacity"]);
                        hallData[cont].Women_Capacity = Convert.ToDouble(UTable.Rows[i]["Women_Capacity"]);
                        cont++;
                        Message = "There are " + cont + "halls";
                        hasHall = cont;
                    }
                }
                else
                {

                    Message = "Not found hall !!!!";
                    hasHall = 0;
                }

            }
            catch (Exception ex)
            {
                hasHall = 0;
                Message = "error !!!!";
                //"cannot Get  infromation about district" 
            }
            var jsonData = new
            {
                hallData = hallData,
                Message = Message,
                hasHall = hasHall
            };
            return ser.Serialize(jsonData);

        }
        //-----------------------------------------------------------------------
        public class District
        {
            public int iDdistrict;
            public String namedistrict;
        }

        public bool updateDateBooking()
        {
            bool sucess = false;

            return sucess;

        }
        public bool UpdateStatuesBooking(int idBooking)
        {
            
           bool sucess = false;
           if (idBooking == 2112454)
            {

                sucess = true;
            }
            else
                sucess = false;

            return sucess;
        }

        public bool CancalBooking( int idBooking)
        {
            bool sucess = false;
            if (idBooking == 123434)
            {

                sucess = true;
            }
            else
                sucess = false;

            return sucess;

             
        }
    }

}
