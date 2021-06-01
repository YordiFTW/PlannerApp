using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlannerApp.Client.Services;
using PlannerApp.Shared;

namespace PlannerApp.Client.Pages.Planner
{
    public class PlanAddBase : ComponentBase
    {
        [Inject]
        public IPlanDataService PlanDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Plan Plan { get; set; } = new Plan();


        [Parameter]
        public int Id { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Plan = new Plan
            {
                Date = DateTime.Now
            };

        }

        protected async Task HandleValidSubmit()
        {
            if (Plan.Id == 0) //new
            {
                Plan.Id = Id;

                var addedPlan = await PlanDataService.AddPlan(Plan);
                if (addedPlan != null)
                {
                    StatusClass = "alert-success";
                    Message = "Nieuwe afspraak succesvol toegevoegd.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Er is iets misgegaan tijdens het aanmaken van een nieuwe afspraak. Probeer het opnieuw.";
                    Saved = false;
                }
            }
            else
            {
                await PlanDataService.UpdatePlan(Plan);
                StatusClass = "alert-success";
                Message = "Afspraakgegevens zijn succesvol bijgewerkt.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeletePlan()
        {
            await PlanDataService.DeletePlan(Plan.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Planner/PlanIndex");
        }
    }
}
