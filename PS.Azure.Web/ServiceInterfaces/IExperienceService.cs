using PS.Data.Entities;
using Raven.Client.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IExperienceService
    {
        [OperationContract]
        OperationResult<Experience> GetExperienceById(string id);

        [OperationContract]
        OperationResult<IRavenQueryable<Experience>> GetExperiencesByNameStartWith(string nameStartWithString);

        [OperationContract]
        OperationResult<IRavenQueryable<Experience>> GetAllExperiences();

        [OperationContract]
        OperationResult CreateExperience(Experience experience);

        [OperationContract]
        OperationResult DeleteExperience(Experience experience);
    }
}