namespace WorkStatus.ASP.NET.MVC.Models
{
    public class WorkStatusDataModel
    {
        private enum Languages
        {
            English,
            Chinese
        }

        public string GetStatusData(Languages language)
        {
            return "";
        }

        public string StatusData { get; set; }
    }
}