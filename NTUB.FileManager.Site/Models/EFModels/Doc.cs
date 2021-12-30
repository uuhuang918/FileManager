namespace NTUB.FileManager.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doc
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(60)]
        public string Description { get; set; }

        [Required]
        [StringLength(40)]
        public string FileName { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
