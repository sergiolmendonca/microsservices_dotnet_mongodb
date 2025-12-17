using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.API.Entities;
using MongoDB.Driver;

namespace catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static List<Product> Products { get; } = new List<Product>()
        {
            new()
            {
                Id = "66f01a2c9d1b4a8b9c001001",
                Name = "Teclado Mecânico RGB",
                Category = "Periféricos",
                Description = "Teclado mecânico com switches blue e iluminação RGB configurável.",
                Image = "https://example.com/images/teclado-rgb.jpg",
                Price = 349.90m
            },
            new()
            {
                Id = "66f01a2c9d1b4a8b9c001002",
                Name = "Mouse Gamer 16000 DPI",
                Category = "Periféricos",
                Description = "Mouse gamer ergonômico com sensor óptico de alta precisão.",
                Image = "https://example.com/images/mouse-gamer.jpg",
                Price = 199.99m
            },
            new()
            {
                Id = "66f01a2c9d1b4a8b9c001003",
                Name = "Headset Surround 7.1",
                Category = "Áudio",
                Description = "Headset com som surround 7.1 e microfone com redução de ruído.",
                Image = "https://example.com/images/headset-7-1.jpg",
                Price = 429.50m
            },
            new()
            {
                Id = "66f01a2c9d1b4a8b9c001004",
                Name = "Monitor Full HD 24\"",
                Category = "Monitores",
                Description = "Monitor LED 24 polegadas, Full HD, 144Hz e 1ms de resposta.",
                Image = "https://example.com/images/monitor-24.jpg",
                Price = 1099.00m
            },
            new()
            {
                Id = "66f01a2c9d1b4a8b9c001005",
                Name = "SSD NVMe 1TB",
                Category = "Armazenamento",
                Description = "SSD NVMe de 1TB com altas taxas de leitura e gravação.",
                Image = "https://example.com/images/ssd-nvme-1tb.jpg",
                Price = 589.90m
            }
        };

        public static void Seed(IMongoCollection<Product> productCollection)
        {
            if (!productCollection.Find(p => true).Any())
            {
                productCollection.InsertManyAsync(Products);
            }
        }
    }
}