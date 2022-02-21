using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FlowersForum.Api.Settings
{
    public class SettingParser
    {
        public static T Parse<T>(IConfiguration configuration, out T settings) where T : new()
        {
            var (settingsObj, errors) = ParseType(typeof(T), configuration);
            if (errors.Any())
                throw new InvalidSettingsException(errors);

            settings = (T)settingsObj;
            return settings;
        }

        private static (object, List<SettingsError>) ParseType(Type type, IConfiguration configuration)
        {
            var errors = new List<SettingsError>();

            var settings = Activator.CreateInstance(type);

            foreach (var property in type.GetProperties())
            {
                var propertyType = property.PropertyType;
                var typeToCheck = !propertyType.IsArray ? propertyType : propertyType.GetElementType();

                if (typeToCheck is { IsValueType: false } && typeToCheck != typeof(string))
                {
                    var (settingsObj, newErrors) = ParseType(propertyType, configuration.GetSection(property.Name));
                    errors.AddRange(newErrors);
                    property.SetValue(settings, settingsObj);
                    continue;
                }

                var config = !propertyType.IsArray
                    ? configuration.GetValue<object>(property.Name)
                    : configuration.GetSection(property.Name).GetChildren().Select(s => s.Value).ToArray();

                if (config == null)
                {
                    if (property.HasAttribute<SettingAllowEmptyAttribute>())
                        continue;

                    errors.Add(new SettingsError(property.Name, "missing"));
                    continue;
                }

                object value;
                try
                {
                    value = Convert.ChangeType(config, propertyType);
                }
                catch (Exception e)
                {
                    errors.Add(new SettingsError(property.Name, "invalid"));
                    continue;
                }

                property.SetValue(settings, value);
            }

            return (settings, errors);
        }
    }
}
