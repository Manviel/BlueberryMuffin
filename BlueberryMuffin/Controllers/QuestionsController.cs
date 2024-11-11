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
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetQuestion>>> GetQuestions([FromQuery] QueryParameters queryParameters)
        {
            return await _questionsRepository.GetAllAsync<GetQuestion>(queryParameters);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuestion>> GetQuestion(int id)
        {
            var entity = await _questionsRepository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetQuestion>(entity);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, GetQuestion updateQuestion)
        {
            if (id != updateQuestion.Id)
            {
                return BadRequest();
            }

            var entity = await _questionsRepository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _mapper.Map(updateQuestion, entity);

            try
            {
                await _questionsRepository.UpdateAsync(entity);
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
            var entity = _mapper.Map<Question>(createQuestion);

            await _questionsRepository.AddAsync(entity);

            return CreatedAtAction("GetQuestion", new { id = entity.Id }, entity);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var entity = await _questionsRepository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            await _questionsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> QuestionExists(int id)
        {
            return await _questionsRepository.Exists(id);
        }
    }
}
