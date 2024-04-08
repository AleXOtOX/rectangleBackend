using liteboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace liteboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private string path = "test.json";
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string? result;
            using(StreamReader reader = new StreamReader(path))
            {
                result = await reader.ReadLineAsync();
            }
            if (result == null)
            {
                return BadRequest("Dimension file is empty");
            }

            return Ok(result);
            
       
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Rectangle value)
        {
            string result = JsonSerializer.Serialize(value);
            using (StreamWriter writer = new StreamWriter(path,false))
            {
                await writer.WriteLineAsync(result);
            }
            return NoContent();
        }
    }
}
