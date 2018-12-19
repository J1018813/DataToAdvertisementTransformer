using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataToAdvertisementTransformer.Data;
using DataToAdvertisementTransformer.DataTransferObjects;
using DataToAdvertisementTransformer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataToAdvertisementTransformer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace DataToAdvertisementTransformer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<BubbleHub> _hubContext;

        public KeywordsController(ApplicationDbContext context, IHubContext<BubbleHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        
        // GET
        public IActionResult Index()
        {
            return
                null;
        }
        
        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KeywordLocationDto keywordLocationDto)
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

            var keywords = await _context.Keywords.Select(k => new KeywordDto(k.Text, k.Amount)).ToListAsync();
            
            await _hubContext.Clients.All.SendAsync(JsonConvert.SerializeObject(keywords));

            return Ok();
        }
        
        // POST
        [HttpPost("many")]
        public async Task<IActionResult> Post([FromBody] List<KeywordLocationDto> keywordLocationDtos)
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
            
            var keywords = await _context.Keywords.Select(k => new KeywordDto(k.Text, k.Amount)).ToListAsync();
            
            await _hubContext.Clients.All.SendAsync(JsonConvert.SerializeObject(keywords));
            
            return Ok();
        }
    }
}