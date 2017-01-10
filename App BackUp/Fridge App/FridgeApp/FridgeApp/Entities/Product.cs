using System;

namespace FridgeApp.Entities
{
    public class Product
    {
        public char ID { get; set; }
        public string Name { get; set; }
        public DateTime Expiration_time { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
