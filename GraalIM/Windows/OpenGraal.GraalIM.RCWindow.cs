
// This file has been generated by the GUI designer. Do not modify.
namespace OpenGraal.GraalIM
{
	public partial class RCWindow
	{
		private global::Gtk.Table table2;
		private global::Gtk.Entry entry1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView textview1;
		private global::Gtk.Table table3;
		private global::Gtk.Image image3;
		private global::Gtk.Image image4;
		private global::Gtk.Image image5;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget OpenGraal.GraalIM.RCWindow
			this.Name = "OpenGraal.GraalIM.RCWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("RCWindow");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("OpenGraal.GraalIM.Resources.rcicon.ico");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.AllowGrow = false;
			// Container child OpenGraal.GraalIM.RCWindow.Gtk.Container+ContainerChild
			this.table2 = new global::Gtk.Table (((uint)(3)), ((uint)(1)), false);
			this.table2.Name = "table2";
			// Container child table2.Gtk.Table+TableChild
			this.entry1 = new global::Gtk.Entry ();
			this.entry1.CanFocus = true;
			this.entry1.Name = "entry1";
			this.entry1.IsEditable = true;
			this.entry1.InvisibleChar = '•';
			this.table2.Add (this.entry1);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table2 [this.entry1]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.textview1 = new global::Gtk.TextView ();
			this.textview1.CanFocus = true;
			this.textview1.Name = "textview1";
			this.GtkScrolledWindow.Add (this.textview1);
			this.table2.Add (this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table2 [this.GtkScrolledWindow]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			// Container child table2.Gtk.Table+TableChild
			this.table3 = new global::Gtk.Table (((uint)(3)), ((uint)(3)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.image3 = new global::Gtk.Image ();
			this.image3.Name = "image3";
			this.image3.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("OpenGraal.GraalIM.Resources.rc_images.rc_options_normal.png");
			this.table3.Add (this.image3);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table3 [this.image3]));
			w4.LeftAttach = ((uint)(2));
			w4.RightAttach = ((uint)(3));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.image4 = new global::Gtk.Image ();
			this.image4.Name = "image4";
			this.image4.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("OpenGraal.GraalIM.Resources.rc_images.rc_playerlist_normal.png");
			this.table3.Add (this.image4);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table3 [this.image4]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.LeftAttach = ((uint)(2));
			w5.RightAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.image5 = new global::Gtk.Image ();
			this.image5.Name = "image5";
			this.image5.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("OpenGraal.GraalIM.Resources.rc_images.rc_datablocks_normal.png");
			this.table3.Add (this.image5);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table3 [this.image5]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.LeftAttach = ((uint)(2));
			w6.RightAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.table2.Add (this.table3);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2 [this.table3]));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.table2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 562;
			this.DefaultHeight = 303;
			this.Show ();
		}
	}
}