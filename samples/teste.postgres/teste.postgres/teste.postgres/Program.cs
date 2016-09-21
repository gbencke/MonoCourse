
using System;
using System.Configuration;
using Npgsql;

namespace teste.postgres
{
	class MainClass
	{

		private static NpgsqlConnection conn;

		private static NpgsqlConnection GetConnection()
		{
			var PostgresServer = ConfigurationManager.AppSettings["PostgresServer"];
			var PostgresPort = ConfigurationManager.AppSettings["PostgresPort"];
			var PostgresDatabase = ConfigurationManager.AppSettings["PostgresDatabase"];
			var PostgresUser = ConfigurationManager.AppSettings["PostgresUser"];
			var PostgresPassword = ConfigurationManager.AppSettings["PostgresPassword"];


			Console.WriteLine(String.Format("Postgres Server:{0}", PostgresServer));
			Console.WriteLine(String.Format("Postgres Port:{0}", PostgresPort));
			Console.WriteLine(String.Format("Postgres Database:{0}", PostgresDatabase));
			Console.WriteLine(String.Format("Postgres User:{0}", PostgresUser));

			var ConnectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", PostgresServer, PostgresPort, PostgresUser, PostgresPassword, PostgresPassword);

			conn = new NpgsqlConnection(ConnectionString);
			return conn;
		}

		private static void InsertRow()
		{
			var UserNameToAdd = ConfigurationManager.AppSettings["UserNameToAdd"];

			using (var stmt = new NpgsqlCommand())
			{
				stmt.Connection = conn;
				stmt.CommandText = "INSERT INTO public.\"USUARIOS\" (\"NOME\",\"SENHA\",\"DATA\") SELECT \'" + UserNameToAdd + "\', \'MINHA SENHA\', NOW()";
				stmt.ExecuteNonQuery();
			}
		}

		private static void ReadShowAndRows()
		{
			using (var stmt = new NpgsqlCommand())
			{
				stmt.Connection = conn;
				stmt.CommandText = "SELECT * FROM public.\"USUARIOS\"";
				var reader = stmt.ExecuteReader();

				TableDrawHelper.PrintLine();

				while (reader.Read())
				{
					string[] ColumnValues = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() };
					TableDrawHelper.PrintRow(ColumnValues);
				}

				TableDrawHelper.PrintLine();
			}

		}

		public static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Iniciando o aplicativo de teste de insert...");
				Console.WriteLine("============================================");
				Console.WriteLine(String.Format("Sistema Operacional:{0}",Environment.OSVersion.ToString()));

				conn = GetConnection();
				Console.WriteLine("Abrindo Conexão:");
				conn.Open();

				Console.WriteLine("Conexão Aberta...");
				Console.WriteLine("Inserindo registro...");

				InsertRow();

				Console.WriteLine("Registro Inserido...");

				Console.WriteLine("Mostrando Conteudo da Tabela USUARIOS...");

				ReadShowAndRows();

				Console.WriteLine("Programa Concluido com sucesso...");

				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine(String.Format("Ocorreu o erro:{0} em {1}", ex.Message, ex.StackTrace));
			}

		}
	}
}
