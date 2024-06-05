using FluentValidation;

namespace FullMono.Service.Validators
{
    public static class ValidationHelper
    {
        public static async Task ValidateDtoAsync<T>(T dto, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException(errorMessage);
            }
        }
    }
}
