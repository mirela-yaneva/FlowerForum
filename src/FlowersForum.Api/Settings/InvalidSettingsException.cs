using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowersForum.Api.Settings
{
    public class InvalidSettingsException : Exception
    {
        public InvalidSettingsException(List<SettingsError> errors)
            : base($"Settings invalid: {string.Join(' ', errors.Select(e => $"{e.FieldName} is {e.Cause}."))}")
        {
        }
    }
}
