using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RealEstateFilterDto:IDto
    {
        public int? RealEstateId { get; set; } // Spesifik bir taşınmazı bulmak için
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? NeighborhoodId { get; set; }
        public string? ParcelNumber { get; set; } // Ada
        public string? LotNumber { get; set; }    // Parsel
        public string? Address { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? OwnerId { get; set; }

    }
}
