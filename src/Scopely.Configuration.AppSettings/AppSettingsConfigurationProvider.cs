using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace Scopely.Configuration
{
    public class AppSettingsConfigurationProvider : FileConfigurationProvider
    {
        public AppSettingsConfigurationProvider(AppSettingsConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            try
            {
                var data = new Dictionary<string, string>();
                var doc = XDocument.Load(stream);
                foreach (var node in doc.Element("appSettings").Elements())
                {
                    string key;
                    switch (node.Name.LocalName.ToLowerInvariant())
                    {
                        case "add":
                            key = node.Attribute("key")?.Value;
                            var value = node.Attribute("value")?.Value ?? string.Empty;
                            if (key != null)
                            {
                                data[key] = value;
                            }
                            break;
                        case "clear":
                            data.Clear();
                            break;
                        case "remove":
                            key = node.Attribute("key")?.Value;
                            if (key != null) data.Remove(key);
                            break;
                    }
                }
                MigrateSettings(data);
                Data = data;
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid format in appSettings xml", ex);
            }
        }

        void MigrateSettings(Dictionary<string, string> data)
        {
            if (data.TryGetValue("AWSRegion", out var value))
            {
                data[$"AWS{ConfigurationPath.KeyDelimiter}Region"] = value;
            }
        }
    }
}
