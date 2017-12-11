using MyStore.Domain.Account.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Respositories;
using MyStore.Infra.Transaction;
using DomainNotificationHelper.Events;
using MyStore.Domain.Account.Events.UserEvents;

namespace MyStore.ApplicationService.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private readonly IUserRepository _userRepository;

        public UserApplicationService(IUserRepository userRepository, IUnitOfWork uow) : base(uow)
        {
            _userRepository = userRepository;
        }
        public User Register(RegisterUserCommand command)
        {
            // Cria a instâcia do usuário
            var user = new User(command.Email, command.Username, command.Password);

            // Tenta registrar o usuário
            user.Register();

            _userRepository.Save(user);
            // Chama o commit
            if (Commit())
            {
                // Dispara o evento de usuário registrado
                DomainEvent.Raise(new OnUserRegisteredEvent(user));

                // Retorna o usuário
                return user;
            }

            // Se não comitou, retorna nulo
            return null;

        }
    }
}
