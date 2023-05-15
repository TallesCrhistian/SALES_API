namespace SALES_API.Shared.DTOs
{
    public class BaseEntityDTO
    {
        public Guid Id { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime Update_at { get; set; }
    }
}
