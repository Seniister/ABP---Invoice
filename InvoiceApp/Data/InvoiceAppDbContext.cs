using InvoiceApp.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace InvoiceApp.Data;

public class InvoiceAppDbContext : AbpDbContext<InvoiceAppDbContext>
{
    public InvoiceAppDbContext(DbContextOptions<InvoiceAppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Invoice> Invoice { get; set; }
    public DbSet<InvoiceItem> InvoiceItem { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        /* Configure your own entities here */
        builder.Entity<Invoice>(b =>
        {
            b.ToTable("Invoice");
        });
        builder.Entity<InvoiceItem>(b =>
        {
          
            b.ToTable("InvoiceItem");
        });
      
    }
}
