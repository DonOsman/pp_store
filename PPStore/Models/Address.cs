﻿namespace PPStore.Models
{
    public class Address : BaseModel
    {
        public string StreetAddress { get; set; }
        public string Town { get; set; }
        public string Telephone { get; set; }
    }
}