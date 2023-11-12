using Image_Processor.Models;
using Image_Processor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    [Route("images")]
    [ApiController]
    public class ImagesController : Controller
    {
        public Image Image { get; set; }
        public ActionResult GetImage([FromQuery] QueryParameters parameters)
        {
            string validation = parameters.QueryValidation();

            if(validation == "" || validation == "GET")
            {
                string path = "";
                if(validation == "GET")
                {
                    Image = new Image(parameters.FileName);
                    path = Image.GetPathToImage();
                } 
                else
                {
                    Image = new Image(parameters.FileName, Int32.Parse(parameters.Width), Int32.Parse(parameters.Height));
                    if (!Image.VerifyPath("images"))
                    {
                        return BadRequest("File not found!");
                    }

                    if (!Image.VerifyPath("thumbnails"))
                    {
                        Image.ResizeImage();
                    }
                    path = Image.CreatePathToThumbnails();
                }   
                var ImageBytes = System.IO.File.ReadAllBytes(path);
                return File(ImageBytes, "image/jpeg");
            } 
            else
            {
                return BadRequest(validation);
            }
        }
    }
}
