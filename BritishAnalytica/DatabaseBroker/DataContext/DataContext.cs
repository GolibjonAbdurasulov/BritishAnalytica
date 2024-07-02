using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Entity.Models.AboutBusinessModel;
using Entity.Models.Common;
using Entity.Models.Contact;
using Entity.Models.Contact.EmailModel;
using Entity.Models.Contact.LocationModel;
using Entity.Models.Contact.PhoneNumberModel;
using Entity.Models.FaqQuestion;
using Entity.Models.File;
using Entity.Models.HomeModel;
using Entity.Models.MessageModel;
using Entity.Models.Motto;
using Entity.Models.News;
using Entity.Models.OurServices;
using Entity.Models.PPS;
using Entity.Models.PPS.PlaningModel;
using Entity.Models.PPS.ProjectModel;
using Entity.Models.PPS.SuccessModel;
using Entity.Models.ServicePercent;
using Entity.Models.TeamMember;
using Entity.Models.Users;
using Entity.Models.Translation;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public  DbSet<FileModel> Files { get; set; }
    
    public  DbSet<Translation> Translations { get; set; }
    
    public  DbSet<Message> Messages { get; set; }

    public  DbSet<AboutBusinessModel> AboutBusinessModels { get; set; }

    public  DbSet<Contact> Contacts { get; set; }

    public  DbSet<FaqQuestions> FaqQuestions { get; set; }

    public  DbSet<HomeModel> HomeModels { get; set; }

    public  DbSet<Motto> Mottoes { get; set; }

    public  DbSet<News> News { get; set; }

    public  DbSet<OurService> OurServices { get; set; }

    public  DbSet<PpsModel> PpsModels { get; set; }

    public  DbSet<ServicePercent> ServicePercents { get; set; }

    public  DbSet<TeamMember> TeamMembers { get; set; }

    public  DbSet<User> Users { get; set; }

    public  DbSet<Email> Emails { get; set; }
    public  DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public  DbSet<Location> Locations { get; set; }
    public  DbSet<Project> Projects { get; set; }
    public  DbSet<Planing> Planings { get; set; }
    public  DbSet<Success> Successes { get; set; }


    private void TrackActionsAt()
    {
        foreach (var entity in this.ChangeTracker.Entries()
                     .Where(x => x.State == EntityState.Added && x.Entity is AuditableModelBase<int>))
        {
            var model = (AuditableModelBase<int>)entity.Entity;
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = model.CreatedAt;
        }

        foreach (var entity in this.ChangeTracker.Entries()
                     .Where(x => x.State == EntityState.Modified && x.Entity is AuditableModelBase<int>))
        {
            var model = (AuditableModelBase<int>)entity.Entity;
            model.UpdatedAt = DateTime.Now;
        }
    }

    public override int SaveChanges()
    {
        TrackActionsAt();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        TrackActionsAt();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
        TrackActionsAt();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        TrackActionsAt();
        return base.SaveChangesAsync(cancellationToken);
    }
   
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Configurations related to MultiLanguageField

        //Configuring all MultiLanguage fields over entities
        var mlfs = this.GetType().GetProperties()
            .Where(x => x.PropertyType.IsGenericType)
            .Where(x => x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .Select(x => x.PropertyType.GetGenericArguments().FirstOrDefault())
            .SelectMany(x => x.GetProperties())
            .Where(x => x.PropertyType == typeof(MultiLanguageField));

        foreach (var multiLanguageField in mlfs)
            modelBuilder
                .Entity(multiLanguageField.ReflectedType!)
                .Property(multiLanguageField.PropertyType, multiLanguageField.Name)
                .HasColumnType("jsonb");

        #endregion
        
        modelBuilder.Entity<Contact>()
            .HasOne(c => c.Email)
            .WithMany()
            .HasForeignKey(c => c.EmailId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete sozlash

        modelBuilder.Entity<Contact>()
            .HasOne(c => c.PhoneNumber)
            .WithMany()
            .HasForeignKey(c => c.PhoneNumberId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Contact>()
            .HasOne(c => c.Location)
            .WithMany()
            .HasForeignKey(c => c.LocationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        
    
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<PpsModel>()
             .HasOne(p => p.Project)
             .WithMany()
             .HasForeignKey(p => p.ProjectId)
             .OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<PpsModel>()
             .HasOne(p => p.Planing)
             .WithMany()
             .HasForeignKey(p => p.PlaningId)
             .OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<PpsModel>()
             .HasOne(p => p.Success)
             .WithMany()
             .HasForeignKey(p => p.SuccessId)
             .OnDelete(DeleteBehavior.Cascade);
   
        
   
        
       
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //    
    //     var mlfs = this.GetType().GetProperties()
    //         .Where(x => x.PropertyType.IsGenericType)
    //         .Where(x => x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
    //         .Select(x => x.PropertyType.GetGenericArguments().FirstOrDefault())
    //         .SelectMany(x => x.GetProperties())
    //         .Where(x => x.PropertyType == typeof(MultiLanguageField));
    //
    //     foreach (var multiLanguageField in mlfs)
    //         modelBuilder
    //             .Entity(multiLanguageField.ReflectedType!)
    //             .Property(multiLanguageField.PropertyType, multiLanguageField.Name)
    //             .HasColumnType("jsonb");
    //     
    //     var helpers = modelBuilder
    //         .Model
    //         .GetEntityTypes()
    //         .Where(x => x.ClrType.BaseType is not null && x.ClrType.BaseType!.IsGenericType &&
    //                     x.ClrType.BaseType?.GetGenericTypeDefinition() == typeof(HelperModelBase<>));
    //
    //     foreach (var helperType in helpers)
    //         modelBuilder
    //             .Entity(helperType.ClrType)
    //             .HasIndex(nameof(HelperModelBase<long>.Code))
    //             .IsUnique();
    //
    // }
    //
}