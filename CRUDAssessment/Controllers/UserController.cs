using CRUDAssessment.Helper;
using CRUDAssessment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBAccess _dbAccess;

        public UserController(DBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
            if (_dbAccess.Users == null)
            {
                return NotFound();
            }
            return await _dbAccess.Users.ToListAsync();
        }

        [HttpGet("{userID}")]
        public async Task<ActionResult<User>> GetUser(int userID)
        {
            if (_dbAccess.Users == null)
            {
                return NotFound();
            }
            var user = await _dbAccess.Users.FindAsync(userID);
            if(user == null)
                return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
             _dbAccess.Users.Add(user);
            await _dbAccess.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { userID = user.userID}, user);
        }

        [HttpPut("{userID}")]
        public async Task<IActionResult> PutUser(int userID, User user)
        {
            if(userID != user.userID)
                return BadRequest();

            _dbAccess.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbAccess.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!UserAvailable(userID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool UserAvailable(int userID)
        {
            return (_dbAccess.Users?.Any(user => user.userID == userID)).GetValueOrDefault();
        }

        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteUser(int userID)
        {
            if (_dbAccess.Users == null)
                return NotFound();

            var user = _dbAccess.Users.FindAsync(userID);
            if (user == null || user.Result == null)
                return NotFound();

            _dbAccess.Users.Remove(user.Result);

            await _dbAccess.SaveChangesAsync();
            return Ok();
        }
    }
}
