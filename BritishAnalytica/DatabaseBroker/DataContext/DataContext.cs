using System.Net.Mime;
using Entity.Models.Common;
using Entity.Models.File;
using Entity.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker;

public class DataContext : DbContext
{
    #region File

    public DbSet<FileModel> Files { get; set; }

    #endregion

    #region Auth

    public DbSet<User> Users { get; set; }

    #endregion


   

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }


    protected void TrackActionsAt()
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

        #region Helpers Configuration

        var helpers = modelBuilder
            .Model
            .GetEntityTypes()
            .Where(x => x.ClrType.BaseType is not null && x.ClrType.BaseType!.IsGenericType &&
                        x.ClrType.BaseType?.GetGenericTypeDefinition() == typeof(HelperModelBase<>));

        foreach (var helperType in helpers)
            modelBuilder
                .Entity(helperType.ClrType)
                .HasIndex(nameof(HelperModelBase<long>.Code))
                .IsUnique();

        #endregion
        
    }
    // public class Database
    // {
    //     public static List<Region> GetRegionsAndDistricts()
    //     {
    //         List<Region> regions = new List<Region>();
    //
    //         using (NpgsqlConnection connection=new NpgsqlConnection(connectionString:))
    //         {
    //             string query = "SELECT r.name AS region_name, d.name AS district_name " +
    //                            "FROM region r " +
    //                            "JOIN district d ON r.id = d.region_id";
    //             using (NpgsqlCommand command=new NpgsqlCommand(query, connection))
    //             {
    //               connection.Open();
    //               NpgsqlDataReader reader = command.ExecuteReader();
    //               Region currentRegion = null;
    //               while (reader.Read())
    //               {
    //                   string regionName = reader["region_name"].ToString();
    //                   string districtName = reader["district_name"].ToString();
    //                   if (currentRegion == null || currentRegion.Name != regionName)
    //                   {
    //                       currentRegion = new Region {Name = regionName, Districts = new List<District>()};
    //                       regions.Add(currentRegion);
    //                   }
    //
    //                   currentRegion.Districts.Add(new District {Name = districtName});
    //               }
    //               reader.Close();
    //             }
    //         }
    //
    //         return regions;
    //     }

    //}
}