using System.ComponentModel.DataAnnotations;

namespace Test.DF.Infrastructure.DataAnnotations;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class PastAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is DateOnly date && date < DateOnly.FromDateTime(DateTime.Now);
    }
}
