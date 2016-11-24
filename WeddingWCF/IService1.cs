using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeddingWCF.Class;

namespace WeddingWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here


        [OperationContract]
        string Login (string Email,string Password);

        [OperationContract]
        bool Register(string user);

        [OperationContract]
        string addBooking(string booking);

        [OperationContract]
        int sum(int num1,int num2);

        [OperationContract]
        string Getdistrict();

        [OperationContract]
        string saercHallsAvailable(int ID_City, string date);

        [OperationContract]
        string GetHallDescription(int ID_Hall, string date);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
