using PS.HireRocks.Data.Database;
using PS.HireRocks.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
    public class DefaultDataSeedingRepository
    {
        public void SeedDefaultData()
        {
            using (var entities = new Entities())
            {
                #region Default Roles
                var roleSupervisor = entities.AspNetRoles.FirstOrDefault(x => x.Id == RoleIdConstants.Supervisor);
                if (roleSupervisor == null)
                {
                    roleSupervisor = new AspNetRole();
                    roleSupervisor.Id = RoleIdConstants.Supervisor;
                    roleSupervisor.Name = RoleConstants.Supervisor;
                    entities.AspNetRoles.Add(roleSupervisor);
                }
                var roleClient = entities.AspNetRoles.FirstOrDefault(x => x.Id == RoleIdConstants.Client);
                if (roleClient == null)
                {
                    roleClient = new AspNetRole();
                    roleClient.Id = RoleIdConstants.Client;
                    roleClient.Name = RoleConstants.Client;
                    entities.AspNetRoles.Add(roleClient);
                }
                var roleWorker = entities.AspNetRoles.FirstOrDefault(x => x.Id == RoleIdConstants.Worker);
                if (roleWorker == null)
                {
                    roleWorker = new AspNetRole();
                    roleWorker.Id = RoleIdConstants.Worker;
                    roleWorker.Name = RoleConstants.Worker;
                    entities.AspNetRoles.Add(roleWorker);
                }
                #endregion

                #region Default Job Types
                var hourlyJob = entities.JobTypes.FirstOrDefault(x => x.JobTypeId == (int)JobTypeEnum.Hourly);
                if (hourlyJob == null)
                {
                    hourlyJob = new JobType();
                    hourlyJob.JobTypeId = (int)JobTypeEnum.Hourly;
                    hourlyJob.JobTypeName = JobTypeConstants.Hourly;
                    hourlyJob.IsActive = true;
                    entities.JobTypes.Add(hourlyJob);
                }
                var fixedJob = entities.JobTypes.FirstOrDefault(x => x.JobTypeId == (int)JobTypeEnum.Fixed);
                if (fixedJob == null)
                {
                    fixedJob = new JobType();
                    fixedJob.JobTypeId = (int)JobTypeEnum.Fixed;
                    fixedJob.JobTypeName = JobTypeConstants.Fixed;
                    fixedJob.IsActive = true;
                    entities.JobTypes.Add(fixedJob);
                }
                #endregion

                #region Default Degree Types
                var bachelorDegree = entities.DegreeTypes.FirstOrDefault(x => x.DegreeTypeId == (int)DegreeTypeEnum.Bachelor);
                if (bachelorDegree == null)
                {
                    bachelorDegree = new DegreeType();
                    bachelorDegree.DegreeTypeId = (int)DegreeTypeEnum.Bachelor;
                    bachelorDegree.DegreeTypeName = DegreeTypeConstants.Bachelor;
                    bachelorDegree.IsActive = true;
                    entities.DegreeTypes.Add(bachelorDegree);
                }
                var masterDegree = entities.DegreeTypes.FirstOrDefault(x => x.DegreeTypeId == (int)DegreeTypeEnum.Masters);
                if (masterDegree == null)
                {
                    masterDegree = new DegreeType();
                    masterDegree.DegreeTypeId = (int)DegreeTypeEnum.Masters;
                    masterDegree.DegreeTypeName = DegreeTypeConstants.Masters;
                    masterDegree.IsActive = true;
                    entities.DegreeTypes.Add(masterDegree);
                }
                #endregion

                #region Default Experience Levels
                var experienceLevelFresher = entities.ExperienceLevels.FirstOrDefault(x => x.ExperianceLevelId == (int)ExperienceLevelEnum.Fresher);
                if (experienceLevelFresher == null)
                {
                    experienceLevelFresher = new ExperienceLevel();
                    experienceLevelFresher.ExperianceLevelId = (int)ExperienceLevelEnum.Fresher;
                    experienceLevelFresher.LevelName = ExperienceLevelConstants.Fresher;
                    experienceLevelFresher.ExperienceLowerRange = 0;
                    experienceLevelFresher.ExperienceHigherRange = 2;
                    experienceLevelFresher.IsActive = true;
                    entities.ExperienceLevels.Add(experienceLevelFresher);
                }
                var experienceLevelIntermediate = entities.ExperienceLevels.FirstOrDefault(x => x.ExperianceLevelId == (int)ExperienceLevelEnum.InterMediate);
                if (experienceLevelIntermediate == null)
                {
                    experienceLevelIntermediate = new ExperienceLevel();
                    experienceLevelIntermediate.ExperianceLevelId = (int)ExperienceLevelEnum.InterMediate;
                    experienceLevelIntermediate.LevelName = ExperienceLevelConstants.InterMediate;
                    experienceLevelIntermediate.ExperienceLowerRange = 3;
                    experienceLevelIntermediate.ExperienceHigherRange = 5;
                    experienceLevelIntermediate.IsActive = true;
                    entities.ExperienceLevels.Add(experienceLevelIntermediate);
                }
                var experienceLevelExpert = entities.ExperienceLevels.FirstOrDefault(x => x.ExperianceLevelId == (int)ExperienceLevelEnum.Expert);
                if (experienceLevelFresher == null)
                {
                    experienceLevelFresher = new ExperienceLevel();
                    experienceLevelFresher.ExperianceLevelId = (int)ExperienceLevelEnum.Expert;
                    experienceLevelFresher.LevelName = ExperienceLevelConstants.Expert;
                    experienceLevelFresher.ExperienceLowerRange = 6;
                    experienceLevelFresher.ExperienceHigherRange = short.MaxValue;
                    experienceLevelFresher.IsActive = true;
                    entities.ExperienceLevels.Add(experienceLevelFresher);
                }
                #endregion

                #region Default Time Units
                var timeUnitYear = entities.TimeUnits.FirstOrDefault(x => x.TimeUnitId == (int)TimeUnitsEnum.Year);
                if (timeUnitYear == null)
                {
                    timeUnitYear = new TimeUnit();
                    timeUnitYear.TimeUnitId = (int)TimeUnitsEnum.Year;
                    timeUnitYear.UnitName = TimeUnitsConstants.Year;
                    timeUnitYear.IsActive = true;
                    entities.TimeUnits.Add(timeUnitYear);
                }
                var timeUnitMonth = entities.TimeUnits.FirstOrDefault(x => x.TimeUnitId == (int)TimeUnitsEnum.Month);
                if (timeUnitMonth == null)
                {
                    timeUnitMonth = new TimeUnit();
                    timeUnitMonth.TimeUnitId = (int)TimeUnitsEnum.Month;
                    timeUnitMonth.UnitName = TimeUnitsConstants.Month;
                    timeUnitMonth.IsActive = true;
                    entities.TimeUnits.Add(timeUnitMonth);
                }
                var timeUnitDay = entities.TimeUnits.FirstOrDefault(x => x.TimeUnitId == (int)TimeUnitsEnum.Day);
                if (timeUnitYear == null)
                {
                    timeUnitDay = new TimeUnit();
                    timeUnitDay.TimeUnitId = (int)TimeUnitsEnum.Day;
                    timeUnitDay.UnitName = TimeUnitsConstants.Day;
                    timeUnitDay.IsActive = true;
                    entities.TimeUnits.Add(timeUnitDay);
                }
                var timeUnitHour = entities.TimeUnits.FirstOrDefault(x => x.TimeUnitId == (int)TimeUnitsEnum.Hour);
                if (timeUnitHour == null)
                {
                    timeUnitHour = new TimeUnit();
                    timeUnitHour.TimeUnitId = (int)TimeUnitsEnum.Hour;
                    timeUnitHour.UnitName = TimeUnitsConstants.Hour;
                    timeUnitHour.IsActive = true;
                    entities.TimeUnits.Add(timeUnitHour);
                }
                var timeUnitMinute = entities.TimeUnits.FirstOrDefault(x => x.TimeUnitId == (int)TimeUnitsEnum.Minute);
                if (timeUnitMinute == null)
                {
                    timeUnitMinute = new TimeUnit();
                    timeUnitMinute.TimeUnitId = (int)TimeUnitsEnum.Minute;
                    timeUnitMinute.UnitName = TimeUnitsConstants.Minute;
                    timeUnitMinute.IsActive = true;
                    entities.TimeUnits.Add(timeUnitMinute);
                }
                #endregion

                entities.SaveChanges();
            }
        }

        public void InitializeMembership()
        {

        }
    }
}
