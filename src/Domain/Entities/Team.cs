using Domain.Common;

namespace practice.Domain.Entities;

public class Team : BaseAuditableEntity
{
    public string Fullname { get; set; }
    public string Profession { get; set; }
    public decimal? Salary { get; set; }
    public int Age { get; set; }
}
