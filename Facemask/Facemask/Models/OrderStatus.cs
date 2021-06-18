using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Models
{
    public enum OrderStatus
    {
        Pending,
        AwaitingPayment,
        AwaitingFulfillment,
        AwaitingShipping,
        AwaitingPickup,
        PartiallyShipped,
        Completed,
        Shipped,
        Cancelled,
        Declined,
        Refunded,
        Disputed,
        ManualVerificationRequired,
        PartiallyRefunded
    }
}
