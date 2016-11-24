using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using WeddingWCF.Class;

namespace WeddingWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}



        User _user = new User();
        Booking _booking = new Booking();
        JavaScriptSerializer ser = new JavaScriptSerializer();


        [WebInvoke(UriTemplate = "/Login?Email={Email}&Password={Password}", Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string Login(string Email, string Password)
        {
            return _user.Login(Email, Password);
        }
         [WebInvoke(UriTemplate = "/sum?num1={num1}&num2={num2}", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public int sum(int num1, int num2) {

            return num1 + num2;
        }

        [WebInvoke(UriTemplate = "/Register?user={user}", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool Register(string user)
        {
            return _user.Register(ser.Deserialize<User>(user));
        }

        [WebInvoke(UriTemplate = "/addBooking?Booking={Booking}", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string addBooking(string booking)
        {
            return _booking.addBooking(ser.Deserialize<Booking>(booking));
                

        }
        [WebInvoke(UriTemplate = "/Getdistrict?", Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string Getdistrict()
        {
            return _booking.Getdistrict();
        }
        [WebInvoke(UriTemplate = "/saercHallsAvailable?ID_City={ID_City}&date={date}", Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string saercHallsAvailable(int ID_City, string date)
        {
            return _booking.saercHallsAvailable(ID_City, date);
                
        }
        [WebInvoke(UriTemplate = "/GetHallDescription?ID_Hall={ID_Hall}&date={date}", Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string GetHallDescription(int ID_Hall, string date)
        {
            return _booking.GetHallDescription(ID_Hall, date);

        }

    }
}
