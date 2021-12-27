using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace hello_asp_identity.Extensions;

public static class SwaggerExtensions
{
    public static void AdjustSchemaIds(this SwaggerGenOptions swaggerGenOptions)
    {
        swaggerGenOptions.CustomSchemaIds(currentClass =>
        {
            string customSuffix = "Response";
            var tmpDisplayName = currentClass.ShortDisplayName().Replace("<", "").Replace(">", "");
            var removedSuffix = tmpDisplayName.EndsWith(customSuffix) ? tmpDisplayName.Substring(0, tmpDisplayName.Length - customSuffix.Length) : tmpDisplayName;
            return removedSuffix;
        });
    }
}