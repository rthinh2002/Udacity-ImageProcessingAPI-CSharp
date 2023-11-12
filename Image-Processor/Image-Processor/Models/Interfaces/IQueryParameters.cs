namespace Image_Processor.Models
{
    public interface IQueryParameters
    {
        string FileName { get; set; }
        string Width { get; set; }
        string Height { get; set; }
    }
}
