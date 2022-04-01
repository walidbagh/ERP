using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.EntityFramework
{
    public class ERPDbContextFactory : IDesignTimeDbContextFactory<ERPDbContext>
    {
        public ERPDbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<ERPDbContext>();
            options.UseSqlServer(@"Server=.\SQLExpress;Database=ERP_DB;Trusted_Connection=True;");

            return new ERPDbContext(options.Options);
        }
    }
}
