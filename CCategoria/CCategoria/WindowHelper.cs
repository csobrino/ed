using Gtk;
using System;

namespace CCategoria
{
	public class WindowHelper
	{
		public static bool Confirm(Window parent, string message){
			//TODO implementar
			MessageDialog messageDialog = new MessageDialog(
				parent,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				message
				);
			messageDialog.Title = parent.Title;
			ResponseType response =	(ResponseType)messageDialog.Run();
			messageDialog.Destroy();
		if (response != ResponseType.Yes)
			return response == ResponseType.Yes;



	}
}

