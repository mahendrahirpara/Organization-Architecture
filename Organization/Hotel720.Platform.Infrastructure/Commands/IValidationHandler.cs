using Appspace.Infrastructure.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command, string strToken, bool bSkipTokenValidation);
        IEnumerable<ValidationResult> Validate(TCommand[] commands, string strToken, bool bSkipTokenValidation);
    }
}
