namespace Image_Processor.Models.Interfaces
{
    public class QueryParameters: IQueryParameters
    {
        public string? FileName { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }

        public string QueryValidation()
        {
            try
            {
                string result = "";
                if (string.IsNullOrEmpty(FileName) && string.IsNullOrEmpty(Width) && string.IsNullOrEmpty(Height))
                {
                    return "Images";
                }

                if(!string.IsNullOrEmpty(FileName) && string.IsNullOrEmpty(Width) && string.IsNullOrEmpty(Height))
                {
                    return "GET";
                }

                if (string.IsNullOrEmpty(Width))
                {
                    result += "width is missing\n";
                }
                if (string.IsNullOrEmpty(Height))
                {
                    result += "height is missing\n";
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "Incorrect Format";
            }
        }
    }
}
