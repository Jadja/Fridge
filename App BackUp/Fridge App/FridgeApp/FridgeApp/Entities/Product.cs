using System;

namespace FridgeApp.Entities
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Expiration_time { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
