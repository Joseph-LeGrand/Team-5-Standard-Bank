using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private DummyModel _dummy;

        public DummyModelsController(DummyContext context)
        {
            _context = context;
        }

        //public DummyModelsController()
        //{
        //}

        // GET: api/DummyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyModel>>> GetTodoItems()
        {
            return await _context.UserTest.ToListAsync();
        }

        // GET: api/DummyModels/5
        [HttpGet("{id}")]
        [Route("users/getUser")]
        public async Task<ActionResult<DummyModel>> GetDummyModel([FromQuery]long id)
        {
            var dummyModel = await _context.UserTest.FindAsync(id);

            if (dummyModel == null)
            {
                return NotFound();
            }

            return dummyModel;
        }

        // PUT: api/DummyModels/5
        [HttpPut("{id}")]
        [Route("users/editUser")]
        public async Task<IActionResult> PutDummyModel(long id,[FromBody] DummyModel dummyModel)
        {
            var entry = _context.UserTest.FirstOrDefault(x => x.Id == id);
            entry.FirstName = dummyModel.FirstName;
            entry.LastName = dummyModel.LastName;
            entry.Username = dummyModel.Username;
            entry.Password = dummyModel.Password;

            await _context.SaveChangesAsync();

            return NoContent();
            
        }
        [HttpPost]
        [Route("users/register")]
        public async Task<ActionResult<DummyModel>> Register(DummyModel dummyModel)
        {
            string salt = Salt.Create();
            string passwordHash = Hash.Create(dummyModel.Password, salt);
            dummyModel.Password = passwordHash;
            dummyModel.Salt = salt;


            var user = _context.UserTest.FirstOrDefault(x => x.Username == dummyModel.Username);

            if (user == null)
            {
                _context.UserTest.Add(dummyModel);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDummyModel", new { id = dummyModel.Id }, dummyModel);
            }
            else
                return Conflict("User already exists");


            
        }

        // POST: api/DummyModels
        [HttpPost]
        [Route("users/Login")]
        public async Task<ActionResult<DummyModel>> Login(string username, string pass)
        {
            var user = _context.UserTest.FirstOrDefault(x => x.Username == username);
            string passwordHash = Hash.Create(pass, user.Salt);
            //var password = _authentication.VerifyPassword(passwordHash, user.Password);


            if (passwordHash != user.Password)
            {

               return  Conflict("The username/password is incorrect");
            }
            return Ok(user);
            //return CreatedAtAction("User logged in", new { id = user.Id }, user);
        }
        // DELETE: api/DummyModels/5
        [HttpDelete("{id}")]
        [Route("users/delete")]
        public async Task<ActionResult<DummyModel>> DeleteDummyModel(long id)
        {
            var dummyModel = await _context.UserTest.FindAsync(id);
            if (dummyModel == null)
            {
               return NotFound();
            }

            _context.UserTest.Remove(dummyModel);
            await _context.SaveChangesAsync();

            return dummyModel;
        }

        private bool DummyModelExists(long id)
        {
            return _context.UserTest.Any(e => e.Id == id);
        }


    }
}
