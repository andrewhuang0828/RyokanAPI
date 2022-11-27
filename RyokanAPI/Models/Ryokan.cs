using System;
namespace RyokanAPI.Models
{
    public class Ryokan
    {
       public int RyokanId { get; set; }
       public string ryokan_name { get; set; }
       public string prefecture { get; set; }
       public bool has_onsen { get; set; }
       public bool half_board { get; set; }
    }
}

