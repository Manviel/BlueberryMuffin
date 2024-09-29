using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;
using AutoMapper;
using BlueberryMuffin.Contracts;

namespace BlueberryMuffin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _countriesRepositiry;
        private readonly IMapper _mapper;

        public CountriesController(ICountriesRepository countriesRepositiry, IMapper mapper)
        {
            _countriesRepositiry = countriesRepositiry;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountry>>> GetCountries()
        {
            var countries = await _countriesRepositiry.GetAllAsync();

            return _mapper.Map<List<GetCountry>>(countries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetails>> GetCountry(int id)
        {
            var country = await _countriesRepositiry.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            return _mapper.Map<CountryDetails>(country);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, GetCountry updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest();
            }

            var country = await _countriesRepositiry.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountry, country);

            try
            {
                await _countriesRepositiry.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
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

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);

            await _countriesRepositiry.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepositiry.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepositiry.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepositiry.Exists(id);
        }
    }
}
