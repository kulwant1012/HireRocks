using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web.ServiceInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISyncHoursInformationWithOTN" in both code and config file together.
    [ServiceContract]
    public interface ISyncHoursInformationWithOTN
    {
        [OperationContract]
        void SyncHoursInformationWithOTN();
    }
}
