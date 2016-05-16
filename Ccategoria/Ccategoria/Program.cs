using Gtk;
using MySql.Data.MySqlClient;
using System;

namespace Ccategoria
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			App.Instace.DbConnection = new MySqlConnection (
				"Database=dbprueba;user=root;password=sistemas");
			App.Instace.DbConnection.Open ();



			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();


			App.Instace.DbConnection.Close ();
		}
	}
}
