using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;

namespace WeddingWCF.Class
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string ID_Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public int? ID_UserType { get; set; }
        [DataMember]
        public string Logtii { get; set; }
        [DataMember]
        public string Latitle { get; set; }

        JavaScriptSerializer ser = new JavaScriptSerializer();
        DataSet1TableAdapters.UserTableAdapter UDA = new DataSet1TableAdapters.UserTableAdapter();
        DataSet1.UserDataTable UTable;
        DataSet1.UserRow URow;
        //Method to Register User ,admin and Hallmnager
        public bool Register(User user)
        {
            // inistailz the data Users
            int IsAdd = 1;
            String Message = "";
            //Check if We have this account already
            if (IsAvailableEmail(ID_Email) == 0)
            {
                try
                {
                    UDA.InsertUser(user.ID_Email, user.Password, user.FirstName, user.LastName, user.Mobile, user.ID_UserType.Value, user.Logtii, user.Latitle);

                    Message = "Your account is created succefully";
                }
                catch (Exception ex)
                {
                    IsAdd = 0;
                    Message = ex.Message;//"cannot add your infromation" 
                }
            }
            else
            {
                IsAdd = 0;
                Message = "Email is reservad";
            }
            return IsAdd == 1 ? true : false;
        }
        //------------------------------------------------------------
        //Method to login to the system
        public string Login(String ID_Email, String password)
        {

            bool isVialed = false;
            String Message = "";
            int UserType = 0;
            try
            {
                UTable = UDA.GetDataByID_Email(ID_Email);

                {
                    URow = UTable.Rows[0] as DataSet1.UserRow;
                    if (URow.ID_Email == ID_Email && URow.Password == password)
                    {
                        UserType = URow.ID_UserType;
                        isVialed = true;
                        Message = "Welcom " + URow.FirstName + " " + URow.LastName;
                    }
                    else
                    {
                        UserType = 0;
                        isVialed = false;
                        Message = "Email or password Not correct !!!!";

                    }
                }

            }
            catch (Exception ex)
            {
                //"cannot add your infromation" 
                UserType = 0;
                isVialed = false;
                Message = "Email or password Not correct !!!!";
               

            }

            var jsonData = new
            {
                isVialed = isVialed,
                UserType = UserType,
                Message = Message
            };
            return ser.Serialize(jsonData);

        }
        //--------------------------------------------------------
        //Method to chack Email ther is in DB or not
        public int IsAvailableEmail(String ID_Email)
        {
            int userID = 0;
            try
            {
                UTable = UDA.GetDataByID_Email(ID_Email);

                if (UTable.Rows.Count > 0) // we hava account
                {
                    for (int i = 0; i <= UTable.Rows.Count - 1; i++)
                    {
                        URow = UTable.Rows[0] as DataSet1.UserRow;
                        if (URow.ID_Email == ID_Email)
                        {
                            userID = 1;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                userID = 0;
                //"cannot add your infromation" 
            }
            return userID;

        }

        //----------------------------------------
        //Methoed to chack Email is valid or not
        public bool IsValidEmail(string ID_Email)
        {
            try
            {
                MailAddress m = new MailAddress(ID_Email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}