using System.Collections.Generic;
using System.Threading.Tasks;
using DataToAdvertisementTransformer.Data;
using DataToAdvertisementTransformer.DataTransferObjects;
using DataToAdvertisementTransformer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataToAdvertisementTransformer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeywordsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            return
                null;
        }
        
        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KeywordLocationDTO keywordLocationDto)
        {
            // Check if keywordLocation is already found
            var keyword = await _context.Keywords.FirstOrDefaultAsync(k => k.Text.Equals(keywordLocationDto.Keyword));
           
            // Create new keywordLocation
            if (keyword == null)
            {
                keyword = new Keyword
                {
                    Text = keywordLocationDto.Keyword
                };

                _context.Keywords.Add(keyword);
                await _context.SaveChangesAsync();
            }
            
            // Update existing keyword
            var newKeywordLocation = new KeywordLocation
            {
                KeywordId = keyword.Id,
                Location = keywordLocationDto.Location,
                DateTime = keywordLocationDto.DateTime,
                Amount = keywordLocationDto.Amount
            };

            _context.KeywordLocations.Add(newKeywordLocation);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        // POST
        [HttpPost("many")]
        public async Task<IActionResult> Post([FromBody] List<KeywordLocationDTO> keywordLocationDtos)
        {
            var keywordLocations = new List<KeywordLocation>();
            
            foreach (var keywordLocationDto in keywordLocationDtos)
            {
                // Check if keywordLocation is already found
                var keyword = await _context.Keywords.FirstOrDefaultAsync(k => k.Text.Equals(keywordLocationDto.Keyword));
           
                // Create new keywordLocation
                if (keyword == null)
                {
                    keyword = new Keyword
                    {
                        Text = keywordLocationDto.Keyword
                    };

                    _context.Keywords.Add(keyword);
                    await _context.SaveChangesAsync();
                }
                
                // Update existing keyword
                keywordLocations.Add(new KeywordLocation
                {
                    KeywordId = keyword.Id,
                    Location = keywordLocationDto.Location,
                    DateTime = keywordLocationDto.DateTime,
                    Amount = keywordLocationDto.Amount
                });
            }

            _context.KeywordLocations.AddRange(keywordLocations);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}