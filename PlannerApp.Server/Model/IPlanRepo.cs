using System.Collections.Generic;
using PlannerApp.Shared;

namespace PlannerApp.Server.Model
{
    public interface IPlanRepo
    {
        IEnumerable<Plan> GetAllPlans();
        Plan GetPlanById(int planId);
        Plan AddPlan(Plan plan);
        Plan UpdatePlan(Plan plan);
        void DeletePlan(int planId);
    }
}