using Buyurtma_ilovasi_2.Constans;
using System;

namespace Buyurtma_ilovasi_2.Halpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstans.UTC);
        return dtTime;
    }
}
