﻿using System;
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

        public DummyModelsController(DummyContext context)
        {
            _context = context;
        }

        // GET: api/DummyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyModel>>> GetTodoItems()
        {
            return await _context.UserTest.ToListAsync();
        }

        // GET: api/DummyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DummyModel>> GetDummyModel(long id)
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

        // POST: api/DummyModels
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<DummyModel>> PostDummyModel(DummyModel dummyModel)
        {
            var user = _context.UserTest.FirstOrDefault(x => x.Username == dummyModel.Username);
            var password = _authentication.VerifyPassword(dummyModel.Password, user?.Password);

            if (!password) {

                ModelState.AddModelError("", "The username/password is incorrect");
            }

            return CreatedAtAction("my loggin", user);
        }
        // DELETE: api/DummyModels/5
        [HttpDelete("{id}")]
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
