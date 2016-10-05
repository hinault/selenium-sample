namespace SeleniumApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Etudiant")]
    public partial class Etudiant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [DisplayName("Prénom")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Sexe { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de Naissance")]
        public DateTime? DateNais { get; set; }
    }
}
