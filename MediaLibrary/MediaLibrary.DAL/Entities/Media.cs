namespace MediaLibrary.DAL.Entities
{
    using MediaLibrary.DAL.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Media
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Media()
        {
            CATEGORY = new HashSet<Category>();
        }

        public int id { get; set; }

        [StringLength(42)]
        public string name { get; set; }

        [StringLength(42)]
        public string url { get; set; }

        [StringLength(42)]
        public string path { get; set; }

        public MediaType type { get; set; }

        public bool? done { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> CATEGORY { get; set; }
    }
}