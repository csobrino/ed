using System;
using System.Data;


namespace CCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel){
			this.Build ();

			saveAction.Activated += delegate {
				Console.WriteLine ("saveAction.Activated");


				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
				dbCommand.CommandText = 
					"insert into categoria (nombre) values (@nombre)";
				string nombre = entryNombre.Text;

				DbHelper.DbCommandAddParameter(dbCommand, "nombre", nombre);


				dbCommand.ExecuteNonQuery ();
		
			};
		}

			}
		}
	


