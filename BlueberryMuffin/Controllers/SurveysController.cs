using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;
using AutoMapper;
using BlueberryMuffin.Contracts;
using Microsoft.AspNetCore.Authorization;
using BlueberryMuffin.Exceptions;
using Microsoft.AspNetCore.OData.Query;
using System.Security.Claims;
using BlueberryMuffin.Data.Relation;

namespace BlueberryMuffin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveysRepository _surveysRepository;
        private readonly IMapper _mapper;

        public SurveysController(ISurveysRepository surveysRepository, IMapper mapper)
        {
            _surveysRepository = surveysRepository;
            _mapper = mapper;
        }

        // GET: api/Surveys/?StartIndex=0&PageNumber=1
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<PagedResult<GetSurvey>>> GetSurveys([FromQuery] QueryParameters queryParameters)
        {
            return await _surveysRepository.GetAllAsync<GetSurvey>(queryParameters);
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyDetails>> GetSurvey(int id)
        {
            return await _surveysRepository.GetDetails(id);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutSurvey(int id, [FromBody] GetSurvey updateSurvey)
        {
            if (id != updateSurvey.Id)
            {
                return BadRequest();
            }

            try
            {
                await _surveysRepository.UpdateAsync(id, updateSurvey);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SurveyExists(id))
                {
                    throw new NotFoundException(nameof(PutSurvey), id);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Surveys
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Survey>> PostSurvey([FromBody] GetSurvey createSurvey)
        {
            var userId = User.FindFirstValue(IdTypes.User);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not recognized.");
            }

            var survey = _mapper.Map<Survey>(createSurvey);
            survey.CreatedById = userId;

            var entity = await _surveysRepository.AddAsync(survey);

            return CreatedAtAction(typeof(GetSurvey).Name, new { id = entity.Id }, entity);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _surveysRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SurveyExists(int id)
        {
            return await _surveysRepository.Exists(id);
        }
    }
}
