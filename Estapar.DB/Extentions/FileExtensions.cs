using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.DB.Extentions
{
    public static class FileExtensions
    {
        public static async Task<string> GetContentAsync(this Type type, string path)
        {
            var fileContent = type.Assembly.GetManifestResourceStream($"{type.Assembly.GetName().Name}.{path}");
            if (fileContent == null) return null;

            using var reader = new StreamReader(fileContent);
            return await reader.ReadToEndAsync();
        }
    }
}
