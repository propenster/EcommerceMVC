using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [JsonProperty("category_id")]
        public int Id { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [JsonProperty("customer")]
        public User Customer { get; set; } //AuthUser
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("shipping_address")]
        public string ShippingAddress { get; set; }
        [JsonProperty("order_address")]
        public string OrderAddress { get; set; }
        [JsonProperty("order_email")]
        public string OrderEmail { get; set; }
        [JsonProperty("order_date")]
        public DateTime OrderDate { get; set; }
        [JsonProperty("order_status")]
        public OrderStatus OrderStatus { get; set; }
    }
}
