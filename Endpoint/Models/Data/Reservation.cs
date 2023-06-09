using Endpoint.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Endpoint.Models.Data
{
    [Table("reservation")]
    public class Reservation : IHasId
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
        [Column("contact")]
        public DateTime Contact { get; set; }

        [Required]
        [Column("begin")]
        public DateTime Begin { get; set; }

        [Required]
        [Column("end")]
        public DateTime End { get; set; }

        [Required]
        [Column("person")]
        public int Person { get; set; }

        [Required]
        [Column("table_id")]
        public string TableId { get; set; }

        [JsonIgnore]
        public virtual Table? Table { get; set; }

       
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
