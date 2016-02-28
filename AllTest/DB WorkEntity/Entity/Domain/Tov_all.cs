namespace DB_WorkEntity.Entity.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tov_all
    {
        public int Id { get; set; }

        public int Nomchk { get; set; }

        public short Depart { get; set; }

        public DateTime Datepay { get; set; }

        public short? Num { get; set; }

        public int Numend { get; set; }

        public int Codfuel { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public int Pay { get; set; }

        public int Scpay { get; set; }

        public short Kind { get; set; }

        public short Divide { get; set; }

        [StringLength(25)]
        public string Cardcode { get; set; }

        [StringLength(7)]
        public string Kod_city { get; set; }

        [StringLength(7)]
        public string Klient { get; set; }

        public int? Amountr { get; set; }

        public int Termkind { get; set; }

        public int? Bonuscurr { get; set; }

        public int? Bonussumm { get; set; }

        [StringLength(4)]
        public string Kod_pred { get; set; }
    }
}
