using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Giliberto.TestADO.NET
{
    class Connected
    {
        //creo la stringa di connessione
        const String conString = @"Persist Security Info = False;
            Integrated Security = True; Initial Catalog = polizia; Server = WINAPP43MDHLF7O\SQLEXPRESS";

        public static void AgentiPerArea(int idArea)
        {
           
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    //apro la connessione
                    connection.Open();

                    //creo e valorizzo il comando
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * " +
                                      "from agentiDiPolizia inner join ronde " +
                                      "on ronde.idAgente = agentiDiPolizia.id " +
                                      "where ronde.idArea = @idArea";

                    //creo e valorizzo il parametro
                    cmd.Parameters.AddWithValue("@idArea", idArea);

                    //eseguo il comando
                    SqlDataReader reader = cmd.ExecuteReader();

                    //leggo i dati del result set
                    while (reader.Read())
                    {
                        Console.WriteLine("Nome: {0} -  Cognome: {1}" +
                                          "\r\nDOB: {2} \r\nCF: {3} \r\nAnni di servizio: {4}",
                                          reader["nome"], reader["cognome"], reader["dob"],
                                          reader["CF"], reader["anniServizio"]
                                          );
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally 
                {
                    connection.Close();
                }
                
            }

        }

        public static void AggiungiAgente(String nome, String cognome, String CF, DateTime dob, int anni)
        {

            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    //apro la connessione
                    connection.Open();

                    //creo e valorizzo il comando
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into agentiDiPolizia values (@nome, @cognome, @CF, @dob, @anniServizio)";

                    //creo e valorizzo i parametri
                    cmd.Parameters.AddWithValue("@anniServizio", anni);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cognome", cognome);
                    cmd.Parameters.AddWithValue("@CF", CF);

                    //cmd.Parameters.Add("@nome", System.Data.SqlDbType.NVarChar, 255, "nome");
                    //cmd.Parameters.Add("@cognome", System.Data.SqlDbType.NVarChar, 255, "cognome");
                    //cmd.Parameters.Add("@CF", System.Data.SqlDbType.NChar, 16, "CF");


                    //eseguo il comando
                    cmd.ExecuteNonQuery();

                    //printo il risultato
                    Console.WriteLine("Inserimento riuscito");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }

                

                //chiudo la connessione



            }


        }

    }
}
/*
 * Utilizzare db Polizia

1. Recuperare i dati relativi agli agenti di polizia assegnati a una data area utilizzando la modalità connessa.
Vincoli:
-Lettura del parametro da command line
-Scrittura dei risultati a schermo

2. Inserire una nuovo record di Agente utilizzando la modalità connessa.

 * 
 */
