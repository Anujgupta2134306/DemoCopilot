using AutoMapper;
using DemoCopilot.Data;
using DemoCopilot.Model.Domain;
using DemoCopilot.Model.Dto;
using DemoCopilot.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCopilot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerDbcontext dbcontext;
        private readonly IPlayerRepository playerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<PlayerController> logger;

        public PlayerController(PlayerDbcontext dbcontext , IPlayerRepository playerRepository,IMapper mapper , ILogger<PlayerController> logger)
        {
            this.dbcontext = dbcontext;
            this.playerRepository = playerRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        //create HttpGet method with Public Asynchronous Task<IActionResult> GetPlayers() method.
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var players = await playerRepository.GetAllPlayerAsync();
                var results = mapper.Map<IEnumerable<PlayerDto>>(players);
                return Ok(results);
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Exception while getting players {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //create HttpGet method with Public Asynchronous Task<IActionResult> GetPlayerById(int id) method.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            try
            {
                var player = await playerRepository.GetPlayerByIdAsync(id);
                if (player == null)
                {
                    return NotFound();
                }
                else
                {
                    var result = mapper.Map<PlayerDto>(player);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Exception while getting player by id {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        //create HttpPost method with Public Asynchronous Task<IActionResult> AddPlayer(PlayerDto playerDto) method.
        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] PlayerRequestDto playerRequestDto)
        {
            try
            {
                var player = mapper.Map<Player>(playerRequestDto);
                var result = await playerRepository.AddPlayerAsync(player);
                var playerDto = mapper.Map<PlayerDto>(result);
                return CreatedAtAction(nameof(GetPlayerById), new { id = playerDto.Id }, playerDto);
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Exception while adding player {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
       

       
       
       
        
    }
}
