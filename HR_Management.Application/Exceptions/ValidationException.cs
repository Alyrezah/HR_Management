using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ErrorMessages { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ErrorMessages = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ErrorMessages.Add(error.ErrorMessage);
            }
        }
    }
}
