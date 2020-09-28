using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanckOfClothesServer.Enum
{
    public enum OrderStatus
    {
        New = 0,
        Approved = 1,
        Completed = 2,
        Rejected = 3 ,
        Cancled = 4,
        Deleted = 5,
    }
}