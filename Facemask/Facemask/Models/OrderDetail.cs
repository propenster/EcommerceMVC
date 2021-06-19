using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facemask.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [JsonProperty("product_id")]
        public int ProductId { get; set; }
        [JsonProperty("product")]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("sku")]
        public string Sku { get; set; }
    }

}
