using System.Collections.Generic;
using System.Threading.Tasks;
using PlannerApp.Shared;

namespace PlannerApp.Client.Services
{
    public interface IPlanDataService
    {
        Task<IEnumerable<Plan>> GetAllPlans();
        Task<Plan> GetPlanDetails(int planId);
        Task<Plan> AddPlan(Plan plan);
        Task UpdatePlan(Plan plan);
        Task DeletePlan(int planId);

    }
}
