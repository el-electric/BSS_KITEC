using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;

namespace EL_BSS
{
    public class Setting_AutoStart
    {
        public const string NAME_SERVICE = "elbss";
        public const string DESCRIPTION = "elbss application excute";

        public string Auto_Start_Add()
        {
            string result = taskManager_AddTask(NAME_SERVICE, DESCRIPTION);
            return result;
        }

        public string Auto_Start_Remove()
        {
            string result = taskManager_RemoveTask(NAME_SERVICE);
            return result;
        }

        public string Auto_Start_Confirm()
        {
            string result = "";
            if (taskManager_IsExistTask(NAME_SERVICE))
                result = "서비스가 등록되어 있습니다.";
            else
                result = "서비스가 등록되어 있지 않습니다..";

            return result;
        }

        public bool taskManager_IsExistTask(string serviceName)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.RootFolder.Tasks.Exists(serviceName))
                {
                    return true;
                }
            }
            return false;

        }

        public string taskManager_AddTask(string serviceName, string description)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.RootFolder.Tasks.Exists(serviceName))
                {
                    return "이미 '" + serviceName + "' 가 존재합니다.";
                }

                using (TaskDefinition td = ts.NewTask())
                {
                    td.RegistrationInfo.Description = description;

                    td.Principal.UserId = string.Concat(Environment.UserDomainName, "\\", Environment.UserName); //계정
                    td.Principal.LogonType = TaskLogonType.InteractiveToken;
                    td.Principal.RunLevel = TaskRunLevel.Highest;
                    td.RegistrationInfo.Author = "ElElectric";

                    LogonTrigger lt = new LogonTrigger(); //로그인할때 실행
                    lt.Enabled = true;
                    td.Triggers.Add(lt);

                    td.Actions.Add(new ExecAction(AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName, null, AppDomain.CurrentDomain.BaseDirectory)); //프로그램, 인자등록.

                    ts.RootFolder.RegisterTaskDefinition(serviceName, td); //MyScheduler란 이름으로 등록.
                    return "'" + serviceName + "' 을 등록하였습니다.";
                }
            }
        }

        public string taskManager_RemoveTask(string serviceName)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.RootFolder.Tasks.Exists(serviceName))
                {
                    ts.RootFolder.DeleteTask(serviceName);
                    return "'" + serviceName + "' 제거 완료";
                }
                else
                {
                    return "'" + serviceName + "' 없음";
                }
            }
        }

        public bool IsRunAsAdmin()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }


    }
}
