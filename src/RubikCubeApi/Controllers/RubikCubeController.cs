using Microsoft.AspNetCore.Mvc;
using RubikCubeApi.Enums;
using RubikCubeApi.Services.Interfaces;

namespace RubikCubeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubikCubeController : ControllerBase
    {
        private readonly IRubikCubeService _rubikCubeService;
        private readonly IPrintService _printService;

        public RubikCubeController(IRubikCubeService rubikCubeService, IPrintService printService)
        {
            _rubikCubeService = rubikCubeService;
            _printService = printService;
        }
        
        [HttpGet("rotate")]
        public async Task<IActionResult> RotateCube([FromQuery] Face face, [FromQuery] Rotation direction)
        {
            Dictionary<Face, Colors[,]> result;
            result = _rubikCubeService.Rotate(Face.Front, Rotation.Clockwise);
            result = _rubikCubeService.Rotate(Face.Right, Rotation.Inverted);
            result = _rubikCubeService.Rotate(Face.Up, Rotation.Clockwise);
            result = _rubikCubeService.Rotate(Face.Back, Rotation.Inverted);
            result = _rubikCubeService.Rotate(Face.Left, Rotation.Clockwise);
            result = _rubikCubeService.Rotate(Face.Down, Rotation.Inverted);
            
            return Ok( _printService.PrintFlat(result));
        }
    }
}