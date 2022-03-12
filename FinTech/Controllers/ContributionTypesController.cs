using AutoMapper;
using FinTech.IRepository;
using FinTech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContributionTypesController> _logger;
        private readonly IMapper _mapper;

        public ContributionTypesController(IUnitOfWork unitOfWork, ILogger<ContributionTypesController> logger, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContributionTypes()
        {
            try
            {
                var contributionTypes = await _unitOfWork.ContributionTypes.GetAll();
                var results = _mapper.Map<IList<ContributionTypeDTO>>(contributionTypes);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContributionTypes)}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id=int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContributionType(int id)
        {
            try
            {
                var contribution = await _unitOfWork.ContributionTypes.Get(q => q.Id == id);
                var result = _mapper.Map<ContributionTypeDTO>(contribution);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContributionType)}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
