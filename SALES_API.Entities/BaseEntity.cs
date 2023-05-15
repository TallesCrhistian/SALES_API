namespace SALES_API.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime Update_at { get; set; }
    }
}
