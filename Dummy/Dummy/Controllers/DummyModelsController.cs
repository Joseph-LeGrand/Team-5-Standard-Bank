using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telerik.JustMock;
using Microsoft.EntityFrameworkCore;
using Dummy.Models;

namespace Dummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyModelsController : ControllerBase
    {
        private DummyContext _context;
        private Authentication _authentication;

        public DummyModelsController(DummyContext context)
        {
            _context = context;
        }


        public string Init()
        {
            return "Intial Test works";
        }

        [HttpPost]
        [Route("users/register")]
        public  ActionResult Register(DummyModel dummyModel)
        {
            
                string salt = Salt.Create();
            string passwordHash = Hash.Create(dummyModel.Password, salt);
            dummyModel.Password = passwordHash;
            dummyModel.Salt = salt;

            _context.Add(dummyModel);
            
            var x = _context.SaveChanges();


            if (x  == 0)
            {
                return Conflict();
            }

            return Ok();
        }

        // GET: api/DummyModels
        [HttpGet]
        [Route("users/login")]
        public ActionResult<DummyModel> Login(string username, string pass)
        {
            var user = _context.DummyModel.Find(username);
            string passwordHash = Hash.Create(pass, user.Salt);

            if (passwordHash != user.Password)
            {
                ModelState.AddModelError("", "The username/password is incorrect");
                return Unauthorized();
            }

            return Ok(user);
        }


        // GET: api/DummyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyModel>>> GetTodoItems()
        {
            return await _context.DummyModel.ToListAsync();
        }

        // GET: api/DummyModels/5
        [HttpGet("{id}")]
        [Route("users/getUser")]
        public async Task<ActionResult<DummyModel>> GetDummyModel(long id)
        {
            var dummyModel = await _context.DummyModel.FindAsync(id);

            if (dummyModel == null)
            {
                return NotFound();
            }

            return dummyModel;
        }

        // PUT: api/DummyModels/5
        [HttpPut("{id}")]
        [Route("users/editUser")]
        public async Task<IActionResult> PutDummyModel(long id, [FromBody] DummyModel dummyModel)
        {


            var entry = _context.DummyModel.FirstOrDefault(x => x.Id == id);
            entry.FirstName = dummyModel.FirstName;
            entry.LastName = dummyModel.LastName;
            entry.Username = dummyModel.Username;
            entry.Password = dummyModel.Password;

            await _context.SaveChangesAsync();

            return NoContent();

        }

       


        // DELETE: api/DummyModels/5
        [HttpDelete("{id}")]
        [Route("users/delete")]
        public async Task<ActionResult<DummyModel>> DeleteDummyModel(long id)
        {
            var dummyModel = await _context.DummyModel.FindAsync(id);
            if (dummyModel == null)
            {
                return NotFound();
            }

            _context.DummyModel.Remove(dummyModel);
            await _context.SaveChangesAsync();

            return dummyModel;
        }

        private bool DummyModelExists(long id)
        {
            return _context.DummyModel.Any(e => e.Id == id);
        }

        
    }
}
