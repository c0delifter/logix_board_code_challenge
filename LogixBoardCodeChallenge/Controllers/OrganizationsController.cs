using LogixBoardCodeChallenge.Domain.Interfaces;
using LogixBoardCodeChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixBoardCodeChallenge.Controllers
{
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IApi _api;
        public OrganizationsController(IApi api)
        {
            _api = api;
        }

        [HttpGet]
        [Route("api/organizations/{id}")]
        public async Task<Organization> Get(string id, CancellationToken cancellationToken)
        {
            var toReturn = await _api.GetOrganization(id, cancellationToken);
            return toReturn;
        }

        [HttpPost]
        [Route("api/organizations")]
        public async Task<bool> Post(Organization org, CancellationToken cancellationToken)
        {
            await _api.UpsertOrganization(org, cancellationToken);
            return true;
        }
    }
}
