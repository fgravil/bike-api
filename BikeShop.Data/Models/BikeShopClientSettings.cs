using System;
using BikeShop.Data.Interfaces;

namespace BikeShop.Data.Models
{
    public class BikeShopClientSettings : IConnectionInfo
    {
        public string ConnectionString { get ; set; }
    }
}

