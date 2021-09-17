using System.Linq;
using AUA.ProjectName.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DataLayer.DbExtensions
{
    public static class FixValuesExtension
    {

        public static void ApplyPersianFormat(this DbContext dbContext)
        {
            var entities = dbContext
                           .ChangeTracker
                           .Entries()
                           .Select(p => p.Entity)
                           .ToList();

            foreach (var entity in entities)
                         entity.ApplyCorrectYeKe();

        }
    }


}
