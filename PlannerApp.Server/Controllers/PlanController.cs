using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerApp.Server.Data;
using PlannerApp.Server.Model;
using PlannerApp.Shared;

namespace PlannerApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanRepo _planrepo;

        public PlanController(IPlanRepo planRepository)
        {
            _planrepo = planRepository;
        }

        [HttpGet]
        public IActionResult GetAllPlans()
        {
            return Ok(_planrepo.GetAllPlans());
        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(int id)
        {
            return Ok(_planrepo.GetPlanById(id));
        }

        [HttpPost]
        public IActionResult CreatePlan([FromBody] Plan plan)
        {
            if (plan == null)
                return BadRequest();

            if (plan.Title == string.Empty || plan.Detail == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPlan = _planrepo.AddPlan(plan);

            return Created("plan", createdPlan);
        }

        [HttpPut]
        public IActionResult UpdatePlan([FromBody] Plan plan)
        {
            if (plan == null)
                return BadRequest();

            if (plan.Title == string.Empty || plan.Detail == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var planToUpdate = _planrepo.GetPlanById(plan.Id);

            if (planToUpdate == null)
                return NotFound();

            _planrepo.UpdatePlan(plan);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlan(int id)
        {
            if (id == 0)
                return BadRequest();

            var planToDelete = _planrepo.GetPlanById(id);
            if (planToDelete == null)
                return NotFound();

            _planrepo.DeletePlan(id);

            return NoContent();//success
        }
    }
}
