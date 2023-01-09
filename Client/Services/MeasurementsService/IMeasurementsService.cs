﻿using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.MeasurementsService
{
    public interface IMeasurementsService
    {
        List<Measurement> Measurements { get; set; }

        Task GetMeasurements();
        Task<Measurement> GetSingleMeasurement(int id);
        Task CreateMeasurement(Measurement measurement);
        Task UpdateMeasurement(Measurement measurement);
        Task DeleteMeasurement(int id);
    }
}