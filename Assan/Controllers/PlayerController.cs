using Assan.DataDbcontext;
using Assan.Domain;
using Assan.DTO;
using Assan.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly AssanDbContext dbContext;
        private readonly IPlayerRepositories playerRepositories;
        private readonly IMapper mapper;
        private readonly ILogger<PlayerController> logger;

        public PlayerController(AssanDbContext dbContext,
            IPlayerRepositories playerRepositories,
            IMapper mapper,
            ILogger<PlayerController> logger)
        {
            this.dbContext = dbContext;
            this.playerRepositories = playerRepositories;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var playerDomain = await playerRepositories.GetAllAsync();

            // Return DTOs
            return Ok(mapper.Map<List<PlayersDto>>(playerDomain));
        }




        // GET SINGLE REGION (Get Region By ID)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            // Get Region Domain Model From Database
            var playerDomain = await playerRepositories.GetByIdAsync(id);

            if (playerDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<PlayersDto>(playerDomain));
        }

        // POST To Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
     
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddPlayerRequestDto addPlayerRequestDto)
        {
            // Map or Convert DTO to Domain Model
            var playerDomain = mapper.Map<Player>(addPlayerRequestDto);

            // Use Domain Model to create Region
            playerDomain = await playerRepositories.CreateAsync(playerDomain);

            // Map Domain model back to DTO
            var playerdto = mapper.Map<PlayersDto>(playerDomain);

            return CreatedAtAction(nameof(GetById), new { id = playerdto.Id }, playerdto);
        }

    }
}
