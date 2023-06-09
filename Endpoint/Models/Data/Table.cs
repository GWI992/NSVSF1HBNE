using Endpoint.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Models.Data
{
    [Table("tables")]
    public class Table : IHasId
    {
        [Key]
        [Required]
        [Column("id")]
        public string? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("name")]
        public string Name{ get; set; }

        [Required]
        [Column("capacity")]
        public int Capacity { get; set; }

        public Table()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
