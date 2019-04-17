using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model.Enums
{
    public enum EnumOrderStatus
    {
        Refused = -1,
        PurchaseRequest = 1,
        WaitingForPayment = 2,
        UnderPreparing = 3,
        ClientNotReached = 4,
        PartialPaidAndRecipient = 5,
        Delivered = 6,
        ReceivedConfirmed = 7
    }
}
