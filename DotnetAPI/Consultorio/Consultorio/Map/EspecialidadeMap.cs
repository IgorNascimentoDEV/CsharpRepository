using Consultorio.Map;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Map
{
    public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap() : base("tb_especialidades")
        {}

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);

            builder.ToTable("tb_especialidades");

            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Ativa).HasColumnName("ativa");
        }
    }
}
