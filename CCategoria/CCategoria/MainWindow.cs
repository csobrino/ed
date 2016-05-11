using System;
using Gtk;
using System.Data;
using CCategoria;
using MySql.Data.MySqlClient;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();


		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText(), "text", 1);

		ListStore liststore = new ListStore(typeof(long), typeof(string));
		treeView.Model = liststore;

		//liststore.AppendValues (33L, "Treinta y tres");

		App.Instance.DbConnection = new MySqlConnection ("Database=dbprueba;user=root;password=sistemas");
		App.Instance.DbConnection.Open ();

		fillListStore (liststore);




		newAction.Activated += delegate {
			CategoriaView categoriaView = new CategoriaView(); 
	};
		//dbConnection.Close ();
	
		deleteAction.Activated += delegate {
			//confirmar
	/*		MessageDialog messageDialog = new MessageDialog(
				this,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				" ¿ Deseas eliminar el registro ? "
			);
			messageDialog.Title = Title;
			ResponseType response =	(ResponseType)messageDialog.Run();
			messageDialog.Destroy();
			if (response != ResponseType.Yes)
				return;

*/
			if (!WindowHelper.Confirm(this, "¿quieres Eliminar el registro?"))
				return;


			TreeIter treeIter;
			treeView.Selection.GetSelected(out treeIter);
			object id = liststore.GetValue(treeIter, 0);


			Console.WriteLine ("deletedAction Activated id = {0}", id);
			IDbCommand deleteDbCommand = App.Instance.DbConnection.CreateCommand();
			deleteDbCommand.CommandText = "delete from categoria where id = @id";
			DbHelper.DbCommandAddParameter(deleteDbCommand, "id", id);
			deleteDbCommand.ExecuteNonQuery();
		};


	treeView.Selection.Changed += delegate {
			Console.WriteLine ("treeView Selection Changed Count Selected Rows()={0}");
								treeView.Selection.CountSelectedRows();
			refreshActions();

	};
		refreshActions ();
	}

	private void fillListStore(ListStore liststore){
		
		IDbCommand dbcommand = App.Instance.DbConnection.CreateCommand ();
		dbcommand.CommandText = "select * from categoria";
		IDataReader dataReader = dbcommand.ExecuteReader ();
		while (dataReader.Read()) 
		//Console.WriteLine ("id={0} nombre={1}", dataReader ["id"], dataReader ["nombre"]);
		liststore.AppendValues (dataReader ["id"], dataReader ["nombre"]);

		dataReader.Close ();
	
	}

	private void refreshActions() {
		deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;

	}




	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnNewActionActivated (object sender, EventArgs e)
	{

	}
}