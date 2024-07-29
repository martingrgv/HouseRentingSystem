using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseRentingSystem.ModelBinders;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ValueProviderResult valueResult = bindingContext.ValueProvider
            .GetValue(bindingContext.ModelName);

        if (valueResult != ValueProviderResult.None &&
            !string.IsNullOrEmpty(valueResult.FirstValue))
        {
            decimal result = default;
            bool success = false;

            try
            {
                string decimalValue = valueResult.FirstValue;
                decimalValue = decimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                decimalValue = decimalValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                result = Convert.ToDecimal(decimalValue, CultureInfo.CurrentCulture);
                success = true;
            }
            catch (FormatException e)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
            }

            if (success)
            {
                bindingContext.Result = ModelBindingResult.Success(result);
            }
        }

        return Task.CompletedTask;
    }
}
