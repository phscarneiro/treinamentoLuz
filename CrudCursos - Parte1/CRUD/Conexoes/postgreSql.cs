using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows;

namespace CRUD.Conexoes
{
    
    internal class postgreSql
    {

        public static void testeconexao()
        {
            
            string conexao = @"Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345";
            NpgsqlConnection con = new NpgsqlConnection(conexao); 
           
                con.Open();
                if (con.State == ConnectionState.Open) 
                {
                    MessageBox.Show("conectado");
                }
        }
    }

}

/*
        private static NpgsqlConnection conexao() 
        {
            return new NpgsqlConnection(@"Server=conexoes_db_1;Port=5432;Database=postgres;Username=postgres;Password=12345");
        }
        */
/*
private NpgsqlConnection com;

private NpgsqlCommand cmd;

string teste = "Server=conexoes_db_1;Port=5432;Database=postgres;Username=postgres;Password=12345";

NpgsqlConnection com = new NpgsqlConnection(teste);
com.Open();
string sql = "INSERT INTO cursodb1(id,nome,autor)VALUES(1,'pe','ce')";
NpgsqlCommand cmd = new NpgsqlCommand(sql, com);
com.Close();
*/