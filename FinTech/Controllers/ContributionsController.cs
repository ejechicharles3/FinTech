using AutoMapper;
using FinTech.Data;
using FinTech.IRepository;
using FinTech.Models;
using Microsoft.AspNetCore.Authorization;
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
   //[Route("api/[controller]/[action]")]
    [ApiController]
    public class ContributionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContributionsController> _logger;
        private readonly IMapper _mapper;

        public ContributionsController(IUnitOfWork unitOfWork, ILogger<ContributionsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
           _mapper = mapper;
        }

        [HttpGet]
       //[ActionName("GetContribution")]
        public async Task<IActionResult> GetContributions()
        {
            try
            {
                var contributions = await _unitOfWork.Contributions.GetAll();
                var results = _mapper.Map<IList<ContributionDTO>>(contributions);
              return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(GetContributions)}");
                return StatusCode(500,"Internal server error");
            }
        }

        [Authorize]
        [HttpGet("{id=int}", Name = "GetContribution")]
        //[ActionName("GetContribution")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetContribution(int id)
        {
            try
            {
                var contribution = await _unitOfWork.Contributions.Get(q => q.Id == id, new List<string> { "ContributionType","Customer" });
                var result = _mapper.Map<ContributionDTO>(contribution);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Something went wrong in the {nameof(GetContribution)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetSummary")]
        //[ActionName("GetSummary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSummary()
        {
            try
            {
                var contributions = await _unitOfWork.Contributions.GetAll();
                var results = _mapper.Map<IList<ContributionDTO>>(contributions);
                var summary = results.GroupBy(i => i.ContributionTypeId).Select(
                    s => new
                    {
                        type = s.Select(i => i.ContributionTypeId).Take(1),
                        Amount = s.Sum(i => i.Amount) 
                    });
                return Ok(summary);
                //return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(GetSummary)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateContribution([FromBody] CreateContributionDTO createContributionDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateContribution)}");
                return BadRequest(ModelState);
            }
            try
            {
                var contribution = _mapper.Map<Contribution>(createContributionDTO);
                await _unitOfWork.Contributions.Insert(contribution);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetContribution", new { id = contribution.Id }, contribution);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateContribution)}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
