using PS.Azure.Web.Services;
using PS.Azure.Web.ViewModel;
using PS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace PS.Azure.Web.Controllers
{
    public class BackupsController : Controller
    {
        private readonly IBackupService _backupService = new PSService();

        //
        // GET: /Backups/

        public void FillHours(TimeSpan? selectedHour = null)
        {             
            var hours = new Dictionary<string, TimeSpan>();
            hours.Add("00.00", TimeSpan.FromHours(0.0));          
            hours.Add("00:30", TimeSpan.FromHours(0.5));
            hours.Add("01:00", TimeSpan.FromHours(1.0));            
            hours.Add("01:30", TimeSpan.FromHours(1.5));
            hours.Add("02:00", TimeSpan.FromHours(2.0));
            hours.Add("02:30", TimeSpan.FromHours(2.5));
            hours.Add("03:00", TimeSpan.FromHours(3.0));
            hours.Add("03:30", TimeSpan.FromHours(3.5));
            hours.Add("04:00", TimeSpan.FromHours(4.0));
            hours.Add("04:30", TimeSpan.FromHours(4.5));
            hours.Add("05:00", TimeSpan.FromHours(5.0));
            hours.Add("05:30", TimeSpan.FromHours(5.5));
            hours.Add("06:00", TimeSpan.FromHours(6.0));
            hours.Add("06:30", TimeSpan.FromHours(6.5));
            hours.Add("07:00", TimeSpan.FromHours(7.0));
            hours.Add("07:30", TimeSpan.FromHours(7.5));
            hours.Add("08:00", TimeSpan.FromHours(8.0));
            hours.Add("08:30", TimeSpan.FromHours(8.5));
            hours.Add("09:00", TimeSpan.FromHours(9.0));
            hours.Add("09:30", TimeSpan.FromHours(9.5));
            hours.Add("10:00", TimeSpan.FromHours(10.0));
            hours.Add("10:30", TimeSpan.FromHours(10.5));
            hours.Add("11:00", TimeSpan.FromHours(11.0));
            hours.Add("11:30", TimeSpan.FromHours(11.5));
            hours.Add("12:00", TimeSpan.FromHours(12.0));
            hours.Add("12:30", TimeSpan.FromHours(12.5));
            hours.Add("13:00", TimeSpan.FromHours(13.0));
            hours.Add("13:30", TimeSpan.FromHours(13.5));
            hours.Add("14:00", TimeSpan.FromHours(14.0));
            hours.Add("14:30", TimeSpan.FromHours(14.5));
            hours.Add("15:00", TimeSpan.FromHours(15.0));
            hours.Add("15:30", TimeSpan.FromHours(15.5));
            hours.Add("16:00", TimeSpan.FromHours(16.0));
            hours.Add("16:30", TimeSpan.FromHours(16.5));
            hours.Add("17:00", TimeSpan.FromHours(17.0));
            hours.Add("17:30", TimeSpan.FromHours(17.5));
            hours.Add("18:00", TimeSpan.FromHours(18.0));
            hours.Add("18:30", TimeSpan.FromHours(18.5));
            hours.Add("19:00", TimeSpan.FromHours(19.0));
            hours.Add("19:30", TimeSpan.FromHours(19.5));
            hours.Add("20:00", TimeSpan.FromHours(20.0));
            hours.Add("20:30", TimeSpan.FromHours(20.5));
            hours.Add("21:00", TimeSpan.FromHours(21.0));
            hours.Add("21:30", TimeSpan.FromHours(21.5));
            hours.Add("22:00", TimeSpan.FromHours(22.0));
            hours.Add("22:30", TimeSpan.FromHours(22.5));
            hours.Add("23:00", TimeSpan.FromHours(23.0));
            hours.Add("23:30", TimeSpan.FromHours(23.5));

            ViewBag.Hours = new SelectList(hours, "Value", "Key", selectedHour.HasValue ? selectedHour.Value : TimeSpan.FromHours(6));
        }

        public ActionResult Index()
        {
            var model = new BackupsViewModel();

            try
            {                         
                var tasksResult = _backupService.GetAllBackupTasks();
                if (!tasksResult.IsErrorReturned)
                    model.Tasks = tasksResult.Value;
                else
                    TempData["ErrorMessage"] = tasksResult.ErrorMessage;

                var actionsResult = _backupService.GetAllBackupActions();
                if (!actionsResult.IsErrorReturned)
                {
                    model.Actions = actionsResult.Value;
                    model.Actions.ForEach(a => a.BackupTask = model.Tasks.FirstOrDefault(t => t.Id == a.BackupTaskId));
                }
                else
                    TempData["ErrorMessage"] = actionsResult.ErrorMessage;                    
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View(model);
        }

        public ActionResult StartTask(string id)
        {
            try
            {
                //Task<bool>.Run(() =>
                //{
                // todo: implement async
                    var result = _backupService.StartBackupTask(id);
                //});

                //TempData["SuccessMessage"] = "Backup Started! Please update page after some time to see result in 'Backup History List'";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }            
        }

        //
        // GET: /Backups/Create

        public ActionResult CreateTask()
        {
            FillHours();
            var backupTask = new BackupTask();
            return View(backupTask);
        }

        public ActionResult BackupDetails(string id)
        {                        
            var backup = _backupService.GetBackupActionById(id).Value;
            backup.BackupTask = _backupService.GetBackupTaskById(backup.BackupTaskId).Value;
            return View(backup);
        }

        //
        // POST: /Backups/Create

        [HttpPost]
        public ActionResult CreateTask(BackupTask backupTask)
        {
            try
            {
                if (TryValidateModel(backupTask))
                {
                    var result = _backupService.InsertOrUpdateBackupTask(backupTask);
                    if (result.IsErrorReturned)
                    {
                        TempData["ErrorMessage"] = result.ErrorMessage;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Backup Task Successfully Added";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    FillHours(backupTask.BackupTime);
                    return View();
                }
            }
            catch
            {
                FillHours(backupTask.BackupTime);
                return View();
            }
        }

        //
        // GET: /Backups/Edit/5

        public ActionResult EditTask(string id)
        {
            var backupTask = _backupService.GetBackupTaskById(id).Value;
            FillHours(backupTask.BackupTime);
            return View(backupTask);
        }

        //
        // POST: /Backups/Edit/5

        [HttpPost]
        public ActionResult EditTask(BackupTask backupTask)
        {
            try
            {
                if (TryValidateModel(backupTask))
                {
                    var result = _backupService.InsertOrUpdateBackupTask(backupTask);
                    if (result.IsErrorReturned)
                    {
                        TempData["ErrorMessag"] = result.ErrorMessage;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Backup Task Successfully Updated";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    FillHours(backupTask.BackupTime);
                    return View();                
                }
            }
            catch
            {
                FillHours(backupTask.BackupTime);
                return View();
            }
        }

        //
        // GET: /Backups/Delete/5

        public ActionResult DeleteTask(string id)
        {
            var result = _backupService.DeleteBackupTask(id);
            if (result.IsErrorReturned)
            {
                TempData["ErrorMessage"] = result.ErrorMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["SuccessMessage"] = "Backup Task Successfully Deleted";
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteBackupHistory()
        {
            var result = _backupService.GetAllBackupActions();
            if (result.IsErrorReturned)
            {
                TempData["ErrorMessage"] = result.ErrorMessage;
                return RedirectToAction("Index");
            }
            else
            {
                _backupService.DeleteAllBackupActions();

                TempData["SuccessMessage"] = "Backups History Deleted";
                return RedirectToAction("Index");
            }
        }       
    }
}
