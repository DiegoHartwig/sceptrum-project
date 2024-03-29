﻿// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using System.Threading.Tasks;

namespace SceptrumProject.Domain.SecurityAccount
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
