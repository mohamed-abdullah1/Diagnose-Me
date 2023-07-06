using System;
using MedicalServices.Application.Common.Interfaces.Services;

namespace MedicalServices.Infrastructure.Services;



public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}