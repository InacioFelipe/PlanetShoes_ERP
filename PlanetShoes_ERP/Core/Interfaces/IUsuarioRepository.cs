﻿using PlanetShoes.Infrastructure.Data;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByUsernameAsync(string username);
    }
}