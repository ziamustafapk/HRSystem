using FluentValidation.Results;

namespace HRSystem.Server.DataTransferObjects.Exceptions
{

    public class ValidationErrorsException : Exception
    {
        public List<string> ValidationErrors { get; }
        public Dictionary<string, string> ValidationErrorsWithName { get; }

        public ValidationErrorsException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            ValidationErrorsWithName = new Dictionary<string, string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);

                if (ValidationErrorsWithName.ContainsKey(validationError.PropertyName))
                {
                   
                    ValidationErrorsWithName[validationError.PropertyName] += "; " + validationError.ErrorMessage;
                }
                else
                {
                    
                    ValidationErrorsWithName[validationError.PropertyName] = validationError.ErrorMessage;
                }
            }
        }
    }



}
