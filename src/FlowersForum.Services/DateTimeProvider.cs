using FlowersForum.Domain.Abstractions.Services;
using System;

namespace FlowersForum.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}
