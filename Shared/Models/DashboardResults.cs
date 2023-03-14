using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class DashboardResults
    {
        public List<AverageResults> MeasurementAverages { get; set; }
        public List<AverageResults> MealsAverages { get; set; }
        public Dictionary<int, List<AverageResults>> WorkoutsAverages { get; set; }

        public DashboardResults(List<AverageResults> measurementAverages,
            List<AverageResults> mealsAverages,
            Dictionary<int, List<AverageResults>> workoutsAverages)
        {
            MeasurementAverages = measurementAverages;
            MealsAverages = mealsAverages;
            WorkoutsAverages = workoutsAverages;
        }
    }
}

