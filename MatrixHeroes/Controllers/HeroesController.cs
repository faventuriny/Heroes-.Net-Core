using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using System.Threading.Tasks;
using MatrixHeroes.Data;
using MatrixHeroes.Models.Dtos;
using MatrixHeroes.Models.Dtos.Responses;

namespace MatrixHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepo _repository;
        private readonly IMapper _mapper;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HeroesController(IHeroesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET /api/heroes
        [HttpGet]
        public async Task<ActionResult> GetAllHeroes()
        {
            try
            {
                var heroesList = _repository.GetHeroes();
                log.Info("GetAllHeroes() - Succeed");
                return Ok(new HeroResult<IEnumerable<HeroDto>>
                {
                    IsSuccess = true,
                    Payload = _mapper.Map<IEnumerable<HeroDto>>(heroesList)
                });
            }
            catch
            {
                log.Info("GetAllHeroes() - Failed to retrieve hero List ");
                return NotFound(new HeroResult<string>
                {
                    IsSuccess = false,
                    Payload = "Failed to retrieve hero List"
                });
            }
        }

        // GET /api/heroes/trainer/{id}
        [HttpGet("trainer/{id}", Name = "GetTrainersHeroes")]
        public async Task<ActionResult> GetHeroesByTrainerId(string id)
        {
            try
            {
                var heroesList = _repository.GetHeroesByTrainerId(id);
                log.Info("GetHeroesByTrainerId() - Succeed ");
                return Ok(new HeroResult<IEnumerable<HeroDto>>
                {
                    IsSuccess = true,
                    Payload = _mapper.Map<IEnumerable<HeroDto>>(heroesList)
                });

            }
            catch
            {
                log.Error("GetHeroesByTrainerId(): Wrong Id, Heroes couldn't be found");
                return NotFound(new HeroResult<string>
                {
                    IsSuccess = false,
                    Payload = "Failed to retrieve hero List"
                });
            }

        }

        // PATCH /api/heroes/trainHero/{id}
        [HttpPatch("trainHero/{id}")]
        public async Task<ActionResult> TrainHeroController(int id)
        {
            try
            {
                var heroModelFromRepo = _repository.GetHero(id);

                bool status = _repository.TrainHero(id);

                if (status)
                {
                    _repository.SaveChanges();
                    log.Info("TrainHeroController() - succeed");
                    return Ok(new HeroResult<HeroDto>
                    {
                        IsSuccess = true,
                        Payload = _mapper.Map<HeroDto>(heroModelFromRepo)
                    });
                }
                else
                {
                    log.Error("TrainHeroController() - Couldn't Train the hero");
                    return BadRequest(new HeroResult<string>
                    {
                        IsSuccess = false,
                        Payload = "Couldn't train the hero"
                    });
                }

            }
            catch
            {
                log.Error("TrainHeroController() - couldn't train the hero");
                return BadRequest(new HeroResult<string>
                {
                    IsSuccess = false,
                    Payload = "Couldn't train the hero"
                });
            }
        }
    }
}
