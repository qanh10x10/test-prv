using System.Data.Linq.Mapping;

namespace Chiyoda.DB.Entity.Standard
{
  [Table]
  public class STD_DimensionOfFlangeHeight
  {
    [Column(IsPrimaryKey = true)]
    public int Standard { get; set; }

    [Column(IsPrimaryKey = true)]
    public int NPS { get; set; }
    
    [Column(IsPrimaryKey = true)]
    public int NP { get; set; }

    [Column(IsPrimaryKey = true)]
    public int EndPrep { get; set; }
    
    [Column]
    public double Y { get; set; }
  }
}