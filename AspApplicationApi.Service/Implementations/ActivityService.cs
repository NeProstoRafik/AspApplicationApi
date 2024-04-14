using AspApplication.Application.Interfaces;
using AspApplication.Domain.Entity;
using System.Collections.Generic;

namespace AspApplication.Application.Implementations;

public class ActivityService : IActivityService
{
    public List<TypeActivity> GetAllActivity()
    {
          List<TypeActivity> activities = new List<TypeActivity>
    {
        new TypeActivity { Activity = "Report", Description = "Доклад, 35-45 минут" },
        new TypeActivity { Activity = "Masterclass", Description = "Мастеркласс, 1-2 часа" },
        new TypeActivity { Activity = "Discussion", Description = "Дискуссия / круглый стол, 40-50 минут" }
    };           
        
        return activities;
    }
}
