using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton4Clicked (object sender, EventArgs e)
	{
		Decimal Numero1 = Decimal.Parse (entry4.Text);
		Decimal Numero2 = Decimal.Parse (entry5.Text);
		Decimal Resultado = Numero1+Numero2;
		label3.Text = Resultado.ToString ();	
	}
}
