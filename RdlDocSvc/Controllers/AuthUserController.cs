using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlDocSvc.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private IRepositoryWrapper _repo;

        public AuthUserController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get All AuthUsers
        /// </summary>
        /// <returns>List of AuthUser objects</returns>
        // GET: api/v1/AuthUser
        [HttpGet]
        public async Task<IEnumerable<AuthUser>> GetAuthUser()
        {
            return await _repo.AuthUser.GetAllAuthUsersAsync();
        }

        /// <summary>
        /// Get AuthUser By Guid
        /// </summary>
        /// <returns>AuthUser object corresponding to the Guid</returns>
        // GET: api/v1/AuthUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authUserItems = await _repo.AuthUser.GetAuthUserByIdAsync(id);

            if (authUserItems == null)
            {
                return NotFound();
            }

            return Ok(authUserItems);
        }

        /// <summary>
        /// Update AuthUser
        /// </summary>
        /// <param name="id">AuthUser Guid</param>
        /// <param name="authUser">Modified AuthUser object</param>
        /// <returns>IActionResult</returns>
        // PUT: api/v1/AuthUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUser([FromRoute] Guid id, [FromBody] AuthUser authUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authUser.AuthUserId)
            {
                return BadRequest();
            }

            try
            {
                await _repo.AuthUser.UpdateAuthUserAsync(authUser);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserExists(id))
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

        /// <summary>
        /// Add AuthUser
        /// </summary>
        /// <param name="authUser">Modified AuthUser object</param>
        /// <returns></returns>
        // POST: api/v1/AuthUser
        [HttpPost]
        public async Task<IActionResult> PostAuthUser([FromBody] AuthUser authUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.AuthUser.CreateAuthUserAsync(authUser);

            return CreatedAtAction("GetAuthUser", new { id = authUser.AuthUserId }, authUser);
        }

        private bool AuthUserExists(Guid id)
        {
            return (_repo.AuthUser.GetAuthUserByIdAsync(id) != null);
        }

        /// <summary>
        /// Get Token
        /// </summary>
        /// <returns>Token String</returns>
        // GET: api/v1/AuthUser
        [HttpGet]
        [Route("GetToken")]
        public async Task<TokenData> GetToken()
        {
            return await _repo.AuthUser.GetToken();
        }

    }
}