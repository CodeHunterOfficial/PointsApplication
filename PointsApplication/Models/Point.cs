using System;
namespace PointsApplication.Models
{
    public partial class Point
    {
        public int Id { get; set; }
        public int? XCoordinate { get; set; }
        public int? YCoordinate { get; set; }
        public string Descriptions { get; set; }
        public DateTime? Dt { get; set; }
    }
}
