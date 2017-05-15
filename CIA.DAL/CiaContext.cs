namespace CIA.DAL
{
    using DTO;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CiaContext : DbContext
    {
        // Your context has been configured to use a 'CiaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CIA.DAL.CiaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CiaContext' 
        // connection string in the application configuration file.
        public CiaContext()
            : base("name=CiaContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<EntityPersonne> Employes { get; set; }
        public virtual DbSet<EntitySociete> Employeurs { get; set; }

        public void HackEntityFramework()
        {
            System.Data.Entity.SqlServer.SqlProviderServices hack = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}