namespace DB_WorkEntity.Entity.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fuel")]
    public partial class Fuel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codfuel { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public short? F_stop { get; set; }
    }
}
