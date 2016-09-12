using Hotel720.Platform.Infrastructure.Commands;
using Hotel720.Platform.Infrastructure.Data;
using HotelCommerce.Core.Domain.Entities.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCommerce.Core.Commands.Tokens
{
	public sealed class TokenHandler : ICommandHandler<CreateToken>
	{
		private readonly IUnitOfWork unitOfWork;

		private readonly IRepositoryFactory repositoryFactory;

		private readonly IRepository<Token> tokenRepository;

		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public TokenHandler(IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repositoryFactory)
		{
			this.repositoryFactory = repositoryFactory;
			tokenRepository = repositoryFactory.Get<Token>();
		}

		public ICommandResponse Execute(CreateToken command)
		{
			ICommandResponse response = null;
			//try
			//{
			//	unitOfWork.BeginTransaction();

			//	Token token = new Token();
			//	token.SessionStartTime = token.LastActivityTime = DateTime.UtcNow;
			//	token.Username = command.Username;
			//	if (command.ExpiryDate.HasValue)
			//		token.SessionExpiredTime = command.ExpiryDate.Value;
			//	token = tokenRepository.Create(token);
			//	if (token.Ticket != Guid.Empty)
			//		response = new TokenCreated { CommandGuid = command.Id };
			//	else
			//		response = new TokenNotCreated { CommandGuid = command.Id };
			//	unitOfWork.Commit();
			//}
			//catch (Exception ex)
			//{
			//	unitOfWork.Rollback();
			//	throw;
			//}
			return response;
		}
	}
}
