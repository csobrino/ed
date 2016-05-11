using System.Data;
using System;

namespace CCategoria
{
	public class App
	{
		private static App instance = new App();
		public static App Instance {
			get { return instance;}
		}


		private App (){

		}

		private IDbConnection dbConnection;
		public IDbConnection DbConnection{
			get {return dbConnection;}
			set {dbConnection = value;}

		}
	}
}

