using System;

namespace FoodPool.Core
{
    public class Stall : IModel
    {
		public string Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
