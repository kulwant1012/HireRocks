using PS.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IGroupsService
    {     
        [OperationContract]
        OperationResult<ICollection<Group>> GetAllGroups();

        [OperationContract]
        OperationResult InsertOrUpdateGroup(Group group);

        [OperationContract]
        OperationResult DeleteGroup(Group group);
    }
}