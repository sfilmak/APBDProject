namespace APBDProject
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [Key]
        public int IdCar { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(1000)]
        public string Review { get; set; }

        [StringLength(100)]
        public string Color { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        public int ProductionYear { get; set; }

        public int? IdCarType { get; set; }

        public int? IdOwner { get; set; }

        public virtual CarType CarType { get; set; }

        public virtual CarOwner CarOwner { get; set; }

        //Validation
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || (!HasErrors))
                return null;

            return new List<string>() { "Invalid credentials." };

        }

        [NotMapped]
        public bool HasErrors { get; set; } = false;

        public bool CheckCredentials()
        {
            if (string.IsNullOrEmpty(Manufacturer) || string.IsNullOrWhiteSpace(Manufacturer) || string.IsNullOrEmpty(Model) || string.IsNullOrWhiteSpace(Model) || string.IsNullOrEmpty(Review) || string.IsNullOrWhiteSpace(Review)
                || string.IsNullOrEmpty(Color) || string.IsNullOrWhiteSpace(Color)
                || string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image) || !Image.StartsWith("http"))
            {
                HasErrors = true;
            }
            else
            {
                HasErrors = false;
            }

            if (!HasErrors)
            {
                return true;
            }
            return false;
        }
    }
}
