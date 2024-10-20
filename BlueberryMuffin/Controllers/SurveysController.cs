using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;
using AutoMapper;
using BlueberryMuffin.Contracts;
using Microsoft.AspNetCore.Authorization;
using BlueberryMuffin.Exceptions;
using Microsoft.AspNetCore.OData.Query;

namespace BlueberryMuffin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveysRepository _countriesRepositiry;
        private readonly IMapper _mapper;

        public SurveysController(ISurveysRepository countriesRepositiry, IMapper mapper)
        {
            _countriesRepositiry = countriesRepositiry;
            _mapper = mapper;
        }

        // GET: api/Surveys/?StartIndex=0&PageNumber=1
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<PagedResult<GetSurvey>>> GetSurveys([FromQuery] QueryParameters queryParameters)
        {
            return await _countriesRepositiry.GetAllAsync<GetSurvey>(queryParameters);
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyDetails>> GetSurvey(int id)
        {
            return await _countriesRepositiry.GetDetails(id);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutSurvey(int id, GetSurvey updateSurvey)
        {
            if (id != updateSurvey.Id)
            {
                return BadRequest();
            }

            try
            {
                await _countriesRepositiry.UpdateAsync(id, updateSurvey);
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
        public async Task<ActionResult<Survey>> PostSurvey(CreateSurvey createSurvey)
        {
            var country = await _countriesRepositiry.AddAsync<CreateSurvey, Survey>(createSurvey);

            return CreatedAtAction(typeof(GetSurvey).Name, new { id = country.Id }, country);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _countriesRepositiry.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SurveyExists(int id)
        {
            return await _countriesRepositiry.Exists(id);
        }
    }
}
