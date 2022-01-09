using System;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }
}
