using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trains.Shared;

namespace Trains.Server.DataModels
{
    public class TrainConfiguration : IEntityTypeConfiguration<TrainEntity>
    {
        public virtual void Configure(EntityTypeBuilder<TrainEntity> builder)
        {
        }
    }
}
