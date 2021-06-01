using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlannerApp.Client.Services;
using PlannerApp.Shared;

namespace PlannerApp.Client.Pages.Planner
{
    public class PlanIndexBase : ComponentBase
    {
        [Inject]
        public IPlanDataService PlanDataService { get; set; }
        public List<Plan> Plans { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Plans = (await PlanDataService.GetAllPlans()).ToList();

        }
    }
}
