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

    [HttpPost("add-file")]
    public async Task<IActionResult> PostFile()
    {
        
        
        return Problem();
    }

   
}