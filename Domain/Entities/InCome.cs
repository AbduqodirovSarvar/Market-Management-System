﻿using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InCome : AudiTableEntity
    {
        public Guid OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
        public int InComeAmount { get; set; }
        public decimal Price { get; set; }
        public DateOnly ExpirationAt { get; set; }
        public string QrCodeFileName { get; set; } = string.Empty;
    }
}
