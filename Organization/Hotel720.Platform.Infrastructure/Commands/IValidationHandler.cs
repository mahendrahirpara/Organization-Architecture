using Hotel720.Platform.Infrastructure.Validations;
using System.Collections.Generic;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command, string strToken, bool bSkipTokenValidation);
        IEnumerable<ValidationResult> Validate(TCommand[] commands, string strToken, bool bSkipTokenValidation);
    }
}
