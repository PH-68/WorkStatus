using System.Web.Mvc;

namespace WorkStatus.ASP.NET.MVC
{
    public class CSharpViewEngine : RazorViewEngine
    {
        private const string _fileExtensions = "cshtml";

        public CSharpViewEngine()
        {
            base.AreaViewLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}." + _fileExtensions, "~/Areas/{2}/Views/Shared/{0}." + _fileExtensions };
            base.AreaMasterLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}." + _fileExtensions, "~/Areas/{2}/Views/Shared/{0}." + _fileExtensions };
            base.AreaPartialViewLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}." + _fileExtensions, "~/Areas/{2}/Views/Shared/{0}." + _fileExtensions };
            base.ViewLocationFormats = new string[] { "~/Views/{1}/{0}." + _fileExtensions, "~/Views/Shared/{0}." + _fileExtensions };
            base.MasterLocationFormats = new string[] { "~/Views/{1}/{0}." + _fileExtensions, "~/Views/Shared/{0}." + _fileExtensions };
            base.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}." + _fileExtensions, "~/Views/Shared/{0}." + _fileExtensions };
            base.FileExtensions = new string[] { _fileExtensions };
        }
    }
}