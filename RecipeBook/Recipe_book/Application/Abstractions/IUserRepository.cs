﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void RemoveUser(User user);
        void GetUsers();
    }
}
