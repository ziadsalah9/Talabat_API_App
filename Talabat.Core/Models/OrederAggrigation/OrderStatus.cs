﻿using System.Runtime.Serialization;

namespace Talabat.Core.Models.OrederAggrigation
{
    public enum OrderStatus
    {


        [EnumMember(Value="Pending")]
        Pending ,


        [EnumMember(Value ="Payment Recived")]
        PaymentRecived,


        [EnumMember(Value = "Payment Failed")]
        PaymentFailed

    }
}