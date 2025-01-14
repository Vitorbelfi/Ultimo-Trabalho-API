﻿using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> InsertUsuario(UsuarioModel user)
        {
            await _dbContext.Usuario.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UsuarioModel> Login(string email, string password)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioEmail == email && x.UsuarioSenha == password);
        }
        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel user, int id)
        {
            UsuarioModel users = await GetById(id);
            if(users == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                users.UsuarioNome = user.UsuarioNome;
                users.UsuarioEmail = user.UsuarioEmail;
                users.UsuarioTelefone = user.UsuarioTelefone;
                users.UsuarioSenha = user.UsuarioSenha;
                _dbContext.Usuario.Update(users);
                await _dbContext.SaveChangesAsync();
            }
            return users;
           
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel users = await GetById(id);
            if (users == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(users);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
