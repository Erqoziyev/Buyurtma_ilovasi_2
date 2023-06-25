using System;
using System.IO;

namespace Buyurtma_ilovasi_2.Halpers;

public class ContentNameMarker
{
    public static string GetImageName(string filepath)
    {
        FileInfo fileInfo = new FileInfo(filepath);
        return "IMG_"+Guid.NewGuid().ToString()+fileInfo.Extension;
    } 
}
