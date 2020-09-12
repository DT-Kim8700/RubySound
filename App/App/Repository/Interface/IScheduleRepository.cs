﻿using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleListViewModel> GetAllSchedules();
    }
}