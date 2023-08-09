using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjAjaxhomework.Models;

namespace prjAjaxhomework.Controllers
{
    public class ApiController : Controller
    {
        //注入方式
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(Members members, IFormFile file)
        {
            //return Content($"{_host.ContentRootPath}");  //C:\shared\Ajax\MSIT150Site\
            //   return Content($"{_host.WebRootPath}");  //C:\shared\Ajax\MSIT150Site\wwwroot

            string filePath = Path.Combine(_host.WebRootPath, "images", file.FileName);
            //C:\shared\Ajax\MSIT150Site\wwwroot\uploads\walk.gif

            //上傳檔案到uploads資料夾中路徑的存法
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            //將團片轉成二進位
            byte[]? image = null;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                image = memoryStream.ToArray();
            }
            //  return Content($"{file.FileName} - {file.Length} - {file.ContentType}"); //檢查是否傳送到
            //return Content($"上傳檔案到 {filePath}");
            members.FileData = image;
            members.FileName = file.FileName;
            _context.Members.Add(members);
            _context.SaveChanges();
            return Content("新增成功");
        }
        public IActionResult CheckAccount(string username)
        {
            bool accountExists = _context.Members.Any(m => m.Name == username);
            return Json(new { exists = accountExists });
        }
    }
}
