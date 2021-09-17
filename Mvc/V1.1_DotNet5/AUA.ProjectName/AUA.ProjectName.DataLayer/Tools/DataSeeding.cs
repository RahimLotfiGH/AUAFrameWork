using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DataLayer.Tools
{
    public static class DataSeeding
    {

        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id = 1, IsActive = true, FirstName = "Rahim", LastName = "Lotfi", UserName = "admin", Password = "3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2", Phone = "+989199906342", Email = "Mr_lotfi@ymail.com" });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, IsActive = true, Title = "Admin", CreatorUserId = AppConsts.SystemUserId, Description = "AUA default role" });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, AppUserId = 1, RoleId = 1, IsActive = true });

            modelBuilder.Entity<UserAccess>().HasData(
                new UserAccess { Id = 1, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.AppUser, Title = "User Management", Url = "../Accounting/AppUser", PageTitle = "User Management", PageDescription = "User Management", IsIndirect = true },
                new UserAccess { Id = 2, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.Role, Title = "Access level management", Url = "../Accounting/UserAccess", PageTitle = "Access level management", PageDescription = "Access level management", IsIndirect = true },
                new UserAccess { Id = 3, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.UserAccess, Title = "Role Management", Url = "../Accounting/Role", PageTitle = "Role Management", PageDescription = "Role Management", IsIndirect = true },
                new UserAccess { Id = 4, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.UserRoleAccess, Title = "Report access to users", Url = "../reports/UserAccessReport", PageTitle = "Report access to users", PageDescription = "Report access to users", IsIndirect = true },
                new UserAccess { Id = 5, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.ResetPassword, Title = "Reset Password", PageTitle = "Reset User Password", PageDescription = "Reset Password", IsIndirect = false },
                new UserAccess { Id = 6, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.UserAccessReport, Title = "User Access Report", PageTitle = "Assign access to roles", PageDescription = "Assign access to roles", IsIndirect = true },
                new UserAccess { Id = 7, CreatorUserId = AppConsts.SystemUserId, IsActive = true, ParentId = 0, AccessCode = EUserAccess.Dashboard, Title = "Dashboard", PageTitle = "Assign access to roles", PageDescription = "Assign access to roles", IsIndirect = true }
            );

            modelBuilder.Entity<UserRoleAccess>().HasData(
                new UserRoleAccess { Id = 1, RoleId = 1, UserAccessId = 1, CreatorUserId = AppConsts.SystemUserId, IsActive = true },
                new UserRoleAccess { Id = 2, RoleId = 1, UserAccessId = 2, CreatorUserId = AppConsts.SystemUserId, IsActive = true },
                new UserRoleAccess { Id = 3, RoleId = 1, UserAccessId = 3, CreatorUserId = AppConsts.SystemUserId, IsActive = true },
                new UserRoleAccess { Id = 4, RoleId = 1, UserAccessId = 4, CreatorUserId = AppConsts.SystemUserId, IsActive = true },
                new UserRoleAccess { Id = 5, RoleId = 1, UserAccessId = 5, CreatorUserId = AppConsts.SystemUserId, IsActive = true },
                new UserRoleAccess { Id = 6, RoleId = 1, UserAccessId = 6, CreatorUserId = AppConsts.SystemUserId, IsActive = true },
                new UserRoleAccess { Id = 7, RoleId = 1, UserAccessId = 7, CreatorUserId = AppConsts.SystemUserId, IsActive = true }
            );



        }
    }
}
