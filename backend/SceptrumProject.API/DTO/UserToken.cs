// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using System;

namespace SceptrumProject.API.DTO
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
