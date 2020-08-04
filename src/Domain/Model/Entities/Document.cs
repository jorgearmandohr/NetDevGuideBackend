using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model.Entities
{
    [Table("DOCUMENT")]
    public class Document : EntityBase
    {
        [Key]
        [Column("DOCUMENT_ID")]
        public int Id { get; set; }

        [Column("DOCUMENT_REFERENCE")]
        public string Reference { get; set; }

        [Column("DOCUMENT_NAME")]
        public string Name { get; set; }
    }
}