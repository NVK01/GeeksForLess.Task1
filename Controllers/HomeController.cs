using GeeksForLess.Task1.DB;
using GeeksForLess.Task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace GeeksForLess.Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;;
        }

        public async Task<IActionResult> Index()
        {
            var currentFolderId = 1;
            var currentFolder = await _context.Cataloges
                .FirstOrDefaultAsync(catalog => catalog.Id == currentFolderId);

            if (currentFolder == null)
            {
                return NotFound();
            }

            ViewData["FolderName"] = $"Folder - {currentFolder.Name}";

            var childFolders = await _context.Cataloges
                .Where(catalog => catalog.ParentId == currentFolderId)
                .ToListAsync();

            return View(childFolders);
        }

        public async Task<IActionResult> ViewFolder(int folderId)
        {
            var currentFolderId = folderId;
            var currentFolder = await _context.Cataloges
                .FirstOrDefaultAsync(catalog => catalog.Id == currentFolderId);

            if (currentFolder == null)
            {
                return NotFound();
            }

            ViewData["FolderName"] = $"Folder - {currentFolder.Name}";

            var childFolders = await _context.Cataloges
                .Where(catalog => catalog.ParentId == currentFolder.Id)
                .ToListAsync();

            return View("FolderView", childFolders);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
