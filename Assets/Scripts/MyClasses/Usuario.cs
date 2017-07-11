using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        string Senha { get; set; }


        public Usuario(int id,string email, string nome, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;

        }

        public bool ChecarLogin(string login, string senha)
        {
            bool retorno = false;

            if (login == Nome && senha == Senha)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public string AtualizarConta(string nome, string senha, string email)
        {
            if (nome != Nome && nome != "")
                Nome = nome;
            else
                //mensagem de usuário já existente
                return null;

            if (senha != Senha && senha != "")
                Senha = senha;
            else
                //mensagem de senha já existente
                return null;

            if (email != Email && email != "")
                Email = email;
            else
                //mensagem de email já existente
                return null;

            return "Sua conta foi atualizada:\nNome do Usuário: " + Nome + "\nEmail: " + Email/*Depois vem a senha*/;
        }
    }
}
