using System;
using Gtk;
using System.Diagnostics;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private Random random; 
	private readonly Gdk.Color GREEN_COLOR = new Gdk.Color(0, 255, 0);
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		random = new Random ();


		Table table = new Table (9, 10, true);

		List<int> numeros = new List<int> ();
		List<Button> buttons = new List<Button> ();

		//Opción 1
		for (uint index = 0; index < 90; index++) {
			uint row = index / 10;
			uint column = index % 10;
			int numero = (int)index + 1;//el uint desborda el rangod de INT por eso le obligamos.
			Button button = new Button ();
			button.Label = numero.ToString();
			button.Visible = true;
			table.Attach (button, column, column + 1, row, row + 1);
			buttons.Add (button);
			numeros.Add (numero);
		}

		//Opción 2
		//for (uint row = 0; row < 9; row++)
		//for (uint column=0; column < 10; column++) {
		//uint index = row * 10 + column;
		//Button button = new Button ();
		//button.Label = (index + 1).ToString();
		//utton.Visible = true;
		//table.Attach (button, column, column + 1, row, row + 1);
		//}



		table.Visible = true;
		vbox1.Add (table);

		buttonNumero.Clicked += delegate {
			int indexAleatorio = random.Next (numeros.Count);
			int numero = numeros[indexAleatorio];
			numeros.RemoveAt(indexAleatorio);
			labelNumero.Text = numero.ToString();


			Button button = buttons[numero - 1];
			button.ModifyBg (StateType.Normal, GREEN_COLOR);
			Process.Start ("espeak", "-v es " + numero);
			buttonNumero.Sensitive= numeros.Count > 0; //Cuando todos los numeros han salido el boton "siguiente" se desactiva
			//DEVELOP BROKER
		};


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
