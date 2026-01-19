using System.Security.Claims;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetTask8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class FileMetadataController : ControllerBase
    {
        private readonly IFileMetadataService _fileService;

        public FileMetadataController(IFileMetadataService fileService)
        {
            _fileService = fileService;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var file = await _fileService.GetFileDetailsAsync(id);

            if (file == null)
                return NotFound(new { Message = $"الملف رقم {id} غير موجود" });

            return Ok(file);
        }

        
        
       
        [HttpPost("{fileId}/approve")]
        public async Task<IActionResult> Approve(int fileId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var success = await _fileService.ApproveFileAsync(fileId, userId);

            if (!success)
            {
                return BadRequest(new
                {
                    Message = "لا يمكن إتمام الاعتماد. تأكد أن الملف موجود، وأنك صاحب الدور الحالي."
                });
            }

            return Ok(new
            {
                Message = "تم اعتماد الملف بنجاح"
            });
        }
    }
}







    
