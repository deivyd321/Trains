using Microsoft.EntityFrameworkCore;
using Trains.Shared;

namespace Trains.Server.DataModels
{
    public class TrainContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<TrainEntity> Trains { get; set; }

        public static string Schema = "Train";

        public TrainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TrainConfiguration());
        }
    }
}
