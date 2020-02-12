using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Scopely.Configuration
{
    public static class AppSettingsConfigurationExtensions
    {
        public static IConfigurationBuilder AddAppSettingsFile(this IConfigurationBuilder builder, string path)
            => builder.AddAppSettingsFile(null, path, false, false);
        public static IConfigurationBuilder AddAppSettingsFile(this IConfigurationBuilder builder, string path, bool optional)
            => builder.AddAppSettingsFile(null, path, optional, false);
        public static IConfigurationBuilder AddAppSettingsFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
            => builder.AddAppSettingsFile(null, path, optional, reloadOnChange);
        public static IConfigurationBuilder AddAppSettingsFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            var source = new AppSettingsConfigurationSource
            {
                FileProvider = provider ?? builder.GetFileProvider(),
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
            return builder.Add(source);
        }
    }
}
