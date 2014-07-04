using Gtk;

namespace OpenGraal.GraalIM
{
	partial class ErrorWindow : Gtk.Window
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Windows Form Designer generated code
		private global::Gtk.UIManager UIManager;
		private Gtk.Button button1;
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void Build()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorWindow));
			
			this.SetPosition(Gtk.WindowPosition.Center);
			this.Name = "OpenGraal.GraalIM.ErrorWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Error!");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("OpenGraal.GraalIM.Resources.rcicon.ico");
			this.DeleteEvent += ErrorWindow_Closed;
			this.UIManager = new global::Gtk.UIManager ();
			this.DefaultWidth = 200;
			this.DefaultHeight = 100;
			this.Show ();
			this.KeepAbove = true;
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		}

		#endregion



	}
}