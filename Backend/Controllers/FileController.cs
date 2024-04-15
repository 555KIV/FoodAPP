using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/files")]
public class FileController(IFileService fileService) : ControllerBase
{
    private readonly IFileService _fileService = fileService;
    
    [HttpGet("get-file={id}")]
    public async Task<IActionResult> GetFile(long id)
    {
        var path = await _fileService.GetPath(id);
        
        return PhysicalFile(path, "image/jpg");
    }

    [HttpPost("add-file={idDish}")]
    public async Task<ActionResult> PostFile(IFormFile? uploadFile, int idDish)
    {
        if (uploadFile != null)
        {
            await _fileService.AddFile(uploadFile, idDish);
            return Ok();
        }

        return Problem();

    }

    
   
}