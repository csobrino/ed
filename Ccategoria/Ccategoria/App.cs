using System;
using System.Data;



namespace Ccategoria
{
	public class App
	{

		private static App instance = new App();


		public static App Instace {
			get { return instance;}

		}





		private App ()
		{


		}

		private IDbConnection dbConnection;
		public IDbConnection DbConnection{
			get { return dbConnection;}
			set {dbConnection = value;}
		}
	}
}

