using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApi.Data;
using DemoApi.ViewModel;
using Newtonsoft.Json;
using System.IO;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonViewModelsController : ControllerBase
    {
        private readonly DemoApiContext _context;

        public PersonViewModelsController(DemoApiContext context)
        {
            _context = context;
        }

        // GET: api/PersonViewModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPersonViewModel()
        {
            return await _context.PersonViewModel.ToListAsync();
        }

        // GET: api/PersonViewModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonViewModel>> GetPersonViewModel(string id)
        {
            var personViewModel = await _context.PersonViewModel.FindAsync(id);

            if (personViewModel == null)
            {
                return NotFound();
            }

            return personViewModel;
        }

        // PUT: api/PersonViewModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonViewModel(string id, PersonViewModel personViewModel)
        {
            if (id != personViewModel.FirstName)
            {
                return BadRequest();
            }

            _context.Entry(personViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonViewModelExists(id))
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

        // POST: api/PersonViewModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] PersonViewModel ViewModel)
        {
            List<PersonViewModel> Perlist = new List<PersonViewModel>();
            Perlist.Add(ViewModel);
            string json = JsonConvert.SerializeObject(Perlist);

            string path = @"C:\Users\Dell\Documents\jsonper.json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(json.ToString());
                tw.Close();

            }
            return StatusCode(StatusCodes.Status200OK, ViewModel);
        }

        // DELETE: api/PersonViewModels/5
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePersonViewModel(string id)
            {
                var personViewModel = await _context.PersonViewModel.FindAsync(id);
                if (personViewModel == null)
                {
                    return NotFound();
                }

                _context.PersonViewModel.Remove(personViewModel);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool PersonViewModelExists(string id)
            {
                return _context.PersonViewModel.Any(e => e.FirstName == id);
            }
        }
    }
