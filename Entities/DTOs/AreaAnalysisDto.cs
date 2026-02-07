using NetTopologySuite.Geometries;
using System.Text.Json.Serialization;

namespace Entities.DTOs
{
    public class AreaAnalysisDto
    {
        [JsonPropertyName("geometryA")]
        public Geometry GeometryA { get; set; } // { get; set; } eklendi

        [JsonPropertyName("geometryB")]
        public Geometry GeometryB { get; set; } // { get; set; } eklendi

        [JsonPropertyName("geometryC")]
        public Geometry GeometryC { get; set; } // { get; set; } eklendi

        [JsonPropertyName("operationType")]
        public string OperationType { get; set; } // { get; set; } eklendi

        [JsonPropertyName("description")]
        public string Description { get; set; } // { get; set; } eklendi
    }
}