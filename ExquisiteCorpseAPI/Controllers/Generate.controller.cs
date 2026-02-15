using ExquisiteCorpseAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExquisiteCorpseAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GenerateController(IGenerateService generateService) : ControllerBase
  {
    private readonly IGenerateService _generateService = generateService;

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Generate([FromQuery] string acronym) => Ok(await _generateService.Generate(acronym));
  }
}