using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlannerApp.Client.Services;
using PlannerApp.Shared;

namespace PlannerApp.Client.Pages.Planner
{
    public class PlanDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Plan Plan { get; set; } = new Plan();

        public IEnumerable<Plan> Plans { get; set; }
        [Inject]
        public IPlanDataService PlanDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Plan = await PlanDataService.GetPlanDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/Planner/PlanIndex");
        }
    }
}
