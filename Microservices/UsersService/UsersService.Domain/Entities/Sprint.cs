using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace UsersService.Domain.Entities
{
    public class Sprint : AuditableBaseEntity
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
