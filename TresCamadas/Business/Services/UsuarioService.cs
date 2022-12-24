using Business.Models;
using Database;
using Database.Repositorios;
using Database.Repositorios.Interfaces;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    internal class UsuarioService
    {
        private Repositorio<Usuario> _repo;
        public UsuarioService(Repositorio<Usuario> repo) { _repo = repo; }

        public void Gravar(Usuario usuario)
        {
            _repo.Gravar(usuario);
        }
        public static List<Usuario> Busca()
        { 
            return _repo.Busca();
        }
    }
}
