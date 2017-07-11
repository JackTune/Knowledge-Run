using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class Cadastrar : MonoBehaviour
{
    private string source;
    private MySqlConnection conexao;
    public InputField nome, email, senha, confirmacao;
    public Button cadastrar;

    //Use this for initialization
    void Start()
    {
        source = "Server=localhost;" +
                 "Database=knowledgerun;" +
                 "User ID=root;" +
                 "Pooling=false;" +
                 "Password=;";

        ConectarBanco(source);
    }


    void ConectarBanco(string _source)
    {
        conexao = new MySqlConnection(_source);
        conexao.Open();
    }

    public void Insert()
    {
        MySqlCommand comando = conexao.CreateCommand();

        string complemento = "default, '" + nome.text + "', '" + email.text + "', '" + senha.text + "')";

        comando.CommandText = "insert into cadastros values(" + complemento;


        MySqlDataReader dados = comando.ExecuteReader();

        dados.Close();

        MyMethods.User = new Usuario(GetID(nome.text), email.text, nome.text, senha.text);

        dados.Close();

        SceneManager.LoadScene("Menu");
    }


    public int GetID(string nome)
    {
        int id = 0;
        MySqlCommand select = conexao.CreateCommand();

        select.CommandText = "SELECT id FROM cadastros WHERE nome = '" + nome + "'";

        MySqlDataReader reader = select.ExecuteReader();
        while (reader.Read())
        {
            id = (int)reader["id"];
        }

        return id;
    }
    public void ErroSenha()
    {
        if (senha.text != confirmacao.text)
        {
            Debug.Log("As senhas não coincidem");
            cadastrar.interactable = false;
        }
        else
        {
            Debug.Log("As senhas coincidem");
            cadastrar.interactable = true;
        }
    }
}
