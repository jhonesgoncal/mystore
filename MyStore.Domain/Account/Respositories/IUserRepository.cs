﻿using MyStore.Domain.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Respositories
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        User GetUserByUsername(string username);
        User GetByAuthorizationCode(string authorizationCode);
    }
}
