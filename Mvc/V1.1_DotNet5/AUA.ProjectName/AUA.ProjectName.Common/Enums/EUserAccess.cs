﻿using System.ComponentModel;

namespace AUA.ProjectName.Common.Enums
{
    public enum EUserAccess
    {
        #region Accounting
        [Description("Non Selected")]
        None = 0,

        [Description("User management")]
        AppUser = 1,

        [Description("Access level management")]
        UserAccess = 2,

        [Description("Role management")]
        Role = 3,

        [Description("Manage the access level of roles")]
        UserRoleAccess = 4,

        [Description("Reset Password")]
        ResetPassword = 5,

        #endregion


        #region BaseInformation
        [Description("Dashboard")]
        Dashboard = 6,
        #endregion

        #region Reports

        [Description("User reports and access levels")]
        UserAccessReport = 7,

        #endregion



    }
}
