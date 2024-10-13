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
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _countriesRepositiry;
        private readonly IMapper _mapper;

        public CountriesController(ICountriesRepository countriesRepositiry, IMapper mapper)
        {
            _countriesRepositiry = countriesRepositiry;
            _mapper = mapper;
        }

        // GET: api/Countries/?StartIndex=0&PageNumber=1
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<PagedResult<GetCountry>>> GetCountries([FromQuery] QueryParameters queryParameters)
        {
            return await _countriesRepositiry.GetAllAsync<GetCountry>(queryParameters);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetails>> GetCountry(int id)
        {
            var country = await _countriesRepositiry.GetDetails(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }

            return _mapper.Map<CountryDetails>(country);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, GetCountry updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest();
            }

            var country = await _countriesRepositiry.GetAsync(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(PutCountry), id);
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
                    throw new NotFoundException(nameof(PutCountry), id);
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
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);

            await _countriesRepositiry.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepositiry.GetAsync(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(DeleteCountry), id);
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
