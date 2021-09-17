﻿using System.Threading;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.DataLayer.DbExtensions;
using AUA.ProjectName.DataLayer.Tools;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(AppConfiguration.GetConnectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            LoadConfigurations(modelBuilder);

            DataSeeding.Seeding(modelBuilder);

        }

        private static void LoadConfigurations(ModelBuilder modelBuilder)
        {

            ConfigurationTools.LoadConfigurations(modelBuilder);

        }

        #region IUnitOfWork Members

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            ApplyRules();
            return await base.SaveChangesAsync();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ApplyRules();
            return await base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        private void ApplyRules()
        {
            //Apply Correct Persian Format (Ye Ke) 

            // this.ApplyPersianFormat();
        }


    }
}
