using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PS.Azure.Web.Services
{
    public interface INotification
    {
        [OperationContract(IsOneWay = true)]
        void ActivityChanged(string Name);
    }
}
