using DataLayer.Assistant.Enums;

namespace DataLayer;
public class DefaultPaginationFilter : PaginationFilter
{
    public DefaultPaginationFilter(int pageNumber = 1, int pageSize = 10) : base(pageNumber, pageSize) { }
    public DefaultPaginationFilter() { }

    public string? Keyword { get; set; }
    public bool? BoolFilter { get; set; }
    public bool? BoolFilter2 { get; set; }
    public bool? BoolFilter3 { get; set; }
    public bool? BoolFilter4 { get; set; }
    public bool? BoolFilter5 { get; set; }
    public bool? BoolFilter6 { get; set; }
    public bool? BoolFilter7 { get; set; }
    public bool? BoolFilter8 { get; set; }
    public double? Min { get; set; }
    public double? Max { get; set; }
    public SortByEnum SortBy { get; set; } = SortByEnum.CreationDate;
}