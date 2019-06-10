namespace APBDProject
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CarOwner")]
    public partial class CarOwner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarOwner()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int IdOwner { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(70)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }

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
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image) || !Image.StartsWith("http")) {
                HasErrors = true;
            } else
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
