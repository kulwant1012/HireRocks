using PS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IPSService : IGroupsService, IQSpacesService, ITasksService, IBackupService, IInitializationService
    {
    
    }   
}