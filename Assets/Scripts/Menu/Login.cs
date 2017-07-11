using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System.Net.Sockets;

public class Login : MonoBehaviour
{
    string source;
    MySqlConnection conexao;
    public InputField login, senha;


    // Use this for initialization
    private void Start()
    {
        source = "Server=localhost;" +
         "Database=knowledgerun;" +
         "User ID=root;" +
         "Pooling=false;" +
         "Password=;";

        try
        {
            ConectarBanco(source);
        }
        catch (Exception)
        {
            Debug.Log("Servidor offline");
        }
    }

    void ConectarBanco(string source)
    {
        conexao = new MySqlConnection(source);
        conexao.Open();
    }

    public void ChecarLogin()
    {
        MySqlCommand select = conexao.CreateCommand();
        select.CommandText = "SELECT * FROM cadastros WHERE (nome = '" + login.text + "' OR email = '" + login.text + "')";

        MySqlDataReader reader = select.ExecuteReader();
        string nome = "", email = "", senha = "";
        int id = 0;
        while (reader.Read())
        {
            id = (int)reader["id"];
            nome = (string)reader["nome"];
            email = (string)reader["email"];
            senha = (string)reader["senha"];
            break;
        }


        MyMethods.User = new Usuario(id, email, nome, senha);

        if (!reader.HasRows)//se não tiver cadastros com esse nome
        {
            Debug.Log("Cadastro inexistente");
        }
        else if (MyMethods.User.ChecarLogin(MyMethods.User.Nome, this.senha.text))
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Debug.Log("Senha incorreta");
        }
        reader.Close();

    }
    public void Cadastro()
    {
        SceneManager.LoadScene("Cadastro");
    }
}
