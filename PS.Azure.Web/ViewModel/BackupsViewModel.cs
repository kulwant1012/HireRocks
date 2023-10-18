using PS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Azure.Web.ViewModel
{
    public class BackupsViewModel
    {
        public List<BackupTask> Tasks { get; set; }
        public List<BackupAction> Actions { get; set; }

        public BackupsViewModel()
        {
            Tasks = new List<BackupTask>();
            Actions = new List<BackupAction>();
        }
    }
}