using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Models;
using BlueberryMuffin.Contracts;
using AutoMapper;
using BlueberryMuffin.Data;
using Microsoft.AspNetCore.Authorization;

namespace BlueberryMuffin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository _hotelsRepository;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionsRepository hotelsRepository, IMapper mapper)
        {
            _hotelsRepository = hotelsRepository;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetQuestion>>> GetQuestions([FromQuery] QueryParameters queryParameters)
        {
            return await _hotelsRepository.GetAllAsync<GetQuestion>(queryParameters);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuestion>> GetQuestion(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetQuestion>(hotel);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, GetQuestion updateQuestion)
        {
            if (id != updateQuestion.Id)
            {
                return BadRequest();
            }

            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _mapper.Map(updateQuestion, hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(GetQuestion createQuestion)
        {
            var hotel = _mapper.Map<Question>(createQuestion);

            await _hotelsRepository.AddAsync(hotel);

            return CreatedAtAction("GetQuestion", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> QuestionExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}
