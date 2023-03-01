using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class AverageResults
    {
        public double CurrentAverage { get; set; }
        public int CurrentCount { get; set; }
        public double PreviousAverage { get; set; }
        public int PreviousCount { get; set; }
        public double Difference { get; set; }
        public bool ChangeDirection { get; set; }

        public AverageResults(double currentAverage, int currentCount, double previousAverage)
        {
            CurrentAverage = Math.Round(currentAverage, 2);
            CurrentCount = currentCount;
            PreviousAverage = Math.Round(previousAverage, 2);
            Difference = Math.Round(Math.Abs(CurrentAverage - PreviousAverage),2);
            ChangeDirection = CurrentAverage > PreviousAverage;
        }
    }


}