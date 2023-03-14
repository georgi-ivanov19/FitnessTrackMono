using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.DashboardService
{
    public interface IDashboardService
    {
        public Task<DashboardResults> GetDashboardData(DateTime date);
    }
}
