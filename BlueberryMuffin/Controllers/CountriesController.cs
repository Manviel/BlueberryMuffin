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
            return await _countriesRepositiry.GetDetails(id);
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

            try
            {
                await _countriesRepositiry.UpdateAsync(id, updateCountry);
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
            var country = await _countriesRepositiry.AddAsync<CreateCountry, Country>(createCountry);

            return CreatedAtAction(typeof(GetCountry).Name, new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _countriesRepositiry.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepositiry.Exists(id);
        }
    }
}
