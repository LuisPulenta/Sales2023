namespace Sales2023.Shared.DTOs
{
    public class TemporalSaleDTO
    {
        public int ProductId { get; set; }

        public float Quantity { get; set; } = 1;

        public string Remarks { get; set; } = string.Empty;
    }
}
