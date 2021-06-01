using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerApp.Server.Data;
using PlannerApp.Shared;

namespace PlannerApp.Server.Model
{
    public class PlanRepo : IPlanRepo
    {
        private readonly ApplicationDbContext _mBDbContext;

        public PlanRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Plan AddPlan(Plan plan)
        {
            var addPlan = _mBDbContext.Plans.Add(plan);
            _mBDbContext.SaveChanges();
            return addPlan.Entity;
        }

        public void DeletePlan(int planId)
        {
            var Plan = _mBDbContext.Plans.FirstOrDefault(e => e.Id == planId);
            if (Plan == null) return;

            _mBDbContext.Plans.Remove(Plan);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Plan> GetAllPlans()
        {
            return _mBDbContext.Plans;
        }

        public Plan GetPlanById(int planId)
        {
            return _mBDbContext.Plans.FirstOrDefault(c => c.Id == planId);
        }

        public Plan UpdatePlan(Plan plan)
        {
            var updatePlan = _mBDbContext.Plans.FirstOrDefault(e => e.Id == plan.Id);

            if (updatePlan != null)
            {
                updatePlan.Catagory = plan.Catagory;
                updatePlan.Detail = plan.Detail;
                updatePlan.Date = plan.Date;
                updatePlan.Title = plan.Title;

                _mBDbContext.SaveChanges();

                return updatePlan;
            }
            return null;
        }
    }
}

