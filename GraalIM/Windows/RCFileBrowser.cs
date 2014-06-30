using System;
using System.Collections.Generic;

namespace OpenGraal.GraalIM
{
	public class RCFileBrowser : Gtk.Window
	{

		private global::Gtk.Table table1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView FileBrowserMessage;
		private Framework Server;
		private static RCFileBrowser _instance = new RCFileBrowser();
		private Gtk.TreeStore musicListStore = new Gtk.TreeStore(typeof(Gdk.Pixbuf), typeof(string));
		private Dictionary<string, Gtk.TreeIter> dirPath = new Dictionary<string, Gtk.TreeIter>();
		private Gtk.TreeView tree = new Gtk.TreeView();

		public static RCFileBrowser GetInstance()
		{
			return _instance;
		}
		public void WindowInit()
		{
			this.Build();
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rcicon.ico");
			this.Server = Framework.GetInstance();
			this.Show();
			this.ShowAll();
		}

		private RCFileBrowser()
			: base(Gtk.WindowType.Toplevel)
		{
			Gtk.Application.Invoke(delegate
			{
				
				this.WindowInit();
			}
			);
		}

		protected void Build()
		{
			// Widget OpenGraal.GraalIM.PMWindow
			this.CanFocus = true;
			this.Name = "OpenGraal.GraalIM.RCFileBrowser";
			this.Title = global::Mono.Unix.Catalog.GetString("File Browser");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rcicon.ico");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child OpenGraal.GraalIM.PMWindow.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.WidthRequest = 600;
			this.table1.HeightRequest = 434;
			Gtk.Frame frame = new Gtk.Frame();
			frame.Label = " Files ";
			//this.table1.Add(frame);
			this.table1.Attach(frame, 0, 1, 0, 1, Gtk.AttachOptions.Fill | Gtk.AttachOptions.Expand, Gtk.AttachOptions.Fill | Gtk.AttachOptions.Expand, 5, 4);
			Gtk.HBox hbox = new Gtk.HBox(true, 5);
			Gtk.Alignment halign = new Gtk.Alignment(1, 0, 0, 0);
			hbox.Add(new Gtk.Button("_Close"));
			halign.Add(hbox);
			this.table1.Attach(halign, 0, 1, 1, 2, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 5, 5);
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.FileBrowserMessage = new global::Gtk.TextView();
			this.FileBrowserMessage.Name = "FileBrowserMessage";
			this.FileBrowserMessage.Editable = false;
			this.FileBrowserMessage.AcceptsTab = false;
			this.FileBrowserMessage.WrapMode = ((global::Gtk.WrapMode)(3));
			this.GtkScrolledWindow.Add(this.FileBrowserMessage);
			//frame.Add(this.GtkScrolledWindow);
			Gtk.Label currentFolder = new Gtk.Label("Current folder: ");
			//Gtk.HBox currentFolderHorizontalBox = new Gtk.HBox();
			Gtk.Alignment currentFolderAlignment = new Gtk.Alignment(0, 0, 0, 0);
			currentFolderAlignment.Add(currentFolder);
			Gtk.Table table2 = new global::Gtk.Table(((uint)(4)), ((uint)(2)), false);
			table2.Name = "table2";
			frame.Add(table2);
			Gtk.Label spacer = new Gtk.Label();
			spacer.SetSizeRequest(10, 1);

			#region Folder List
			
			tree.HeadersVisible = false;

			Gtk.TreeViewColumn artistColumn = new Gtk.TreeViewColumn();
			//artistColumn.Title = "Artist";
			artistColumn.Resizable = false;
			//artistColumn.Clickable = false;
			//artistColumn.Visible = false;

			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			artistNameCell.Visible = true;
			artistColumn.PackStart(artistNameCell, true);

			tree.AppendColumn("Icon", new Gtk.CellRendererPixbuf(), "pixbuf", 0);
			tree.AppendColumn(artistColumn);
			

			artistColumn.AddAttribute(artistNameCell, "text", 1);

			//this.musicListStore = new Gtk.TreeStore(typeof(Gdk.Pixbuf), typeof(string));
			//this.musicListStore.AppendValues("", "Loading...");
			Gtk.TreeIter iter;
			//iter = musicListStore.AppendValues(global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), "levels/");
			
			//musicListStore.AppendValues(iter, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), "staff/");
			//musicListStore.RowChanged += RowChanged;
			tree.RowExpanded += RowExpanded;
			tree.RowCollapsed += RowCollapsed;
			tree.CursorChanged += new System.EventHandler(RowSelected); 
			tree.SearchColumn = 1;
			tree.EnableSearch = true;
			//tree.

			tree.Model = musicListStore;

			#endregion

			table2.Attach(tree, 0, 1, 2, 3, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 4, 0);
			table2.Attach(spacer, 0, 2, 0, 1, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 0, 0);
			table2.Attach(currentFolderAlignment, 0, 2, 1, 2, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 4, 0);
			table2.Attach(this.GtkScrolledWindow, 0, 2, 3, 4, Gtk.AttachOptions.Fill | Gtk.AttachOptions.Expand, Gtk.AttachOptions.Fill | Gtk.AttachOptions.Expand, 4, 4);

			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 616;
			this.DefaultHeight = 472;
			this.DefaultSize = new Gdk.Size(616,472);

			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.RemoveRCFileBrowserWindow);
			this.HideOnDelete();
			
			//this.SendToallMessageButton.Clicked += new global::System.EventHandler(this.SendToallMessageButtonClicked);
		}
		
		private void RowExpanded(object sender, Gtk.RowExpandedArgs args) 
		{
			Gtk.TreeView store = (Gtk.TreeView)sender;
			this.musicListStore.SetValue(args.Iter, 0, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderopen.png"));
		}

		private void RowCollapsed(object sender, Gtk.RowCollapsedArgs args)
		{
			Gtk.TreeView store = (Gtk.TreeView)sender;
			this.musicListStore.SetValue(args.Iter, 0, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"));
		}

		private void RowSelected(object sender, System.EventArgs e)
		{
			Gtk.Application.Invoke(delegate
			{
				Gtk.TreeSelection selection = (sender as Gtk.TreeView).Selection;
				Gtk.TreeModel model;
				Gtk.TreeIter iter;
				 
				// THE ITER WILL POINT TO THE SELECTED ROW
				if (selection.GetSelected(out model, out iter))
				{
					try
					{
						string CDPath = "";
						Gtk.TreeIter parent;
						Console.WriteLine("Selected Value:" + model.GetValue(iter, 1).ToString());
						
						if (model.IterParent(out parent, iter))
							CDPath += model.GetValue(parent, 1).ToString();

						CDPath += model.GetValue(iter, 1).ToString();

						Abstraction.GetInstance().WriteText(CDPath);

						Framework.GetInstance().SendGSPacket(new Core.CString() + (byte)OpenGraal.Common.Connections.Client.GraalServer.PacketOut.RC_FILEBROWSER_CD + CDPath);
					}
					catch (Exception ez)
					{ }
				}
			}
			);
		}

		private void RemoveRCFileBrowserWindow(object sender, Gtk.DeleteEventArgs e)
		{
			e.RetVal = true; 
			Abstraction main = Abstraction.GetInstance();

			this.Hide();
		}

		public void AppendTextWithoutScroll(string text)
		{
			Gtk.TextIter iter;
			this.FileBrowserMessage.Buffer.MoveMark(this.FileBrowserMessage.Buffer.InsertMark, this.FileBrowserMessage.Buffer.EndIter);
			if (text != null)
			{
				if (text.Equals("") == false)
				{
					iter = this.FileBrowserMessage.Buffer.EndIter;
					this.FileBrowserMessage.Buffer.Insert(iter, text);
				}
			}
			iter = this.FileBrowserMessage.Buffer.EndIter;
			this.FileBrowserMessage.Buffer.Insert(iter, "\n");
		}

		public void AppendText(string text)
		{
			System.DateTime time = System.DateTime.Now;              // Use current time
			string format = "HH:mm:ss";

			//
			//this.FileBrowserMessage.Buffer.Clear();
			this.AppendTextWithoutScroll(text);
			//this.FileBrowserMessage.ScrollToMark(this.FileBrowserMessage.Buffer.InsertMark, 0.4, true, 0.0, 1.0);
		}

		public void WriteText(string text)
		{
			Gtk.Application.Invoke(delegate
			{
				this.AppendText(text);
			}
			);
		}

		public void SetMessage(Core.CString message)
		{
			this.WriteText(message.ToString());
		}

		public void SetDirList(string[] dirList)
		{
			
			this.musicListStore.Clear();
			this.dirPath.Clear();
			Gtk.TreeIter iter,iter2;
			foreach (string dir in dirList)
			{
				string[] curDir = dir.Split(' ')[1].Split('/');
				string prevDir = "";
				int dirs = 0;
				foreach (string dir2 in curDir)
				{
					string thisDir = this.DecodeUrlString(dir2);
					dirs++;
					if (curDir.Length == dirs && (thisDir.Contains("*") || thisDir.Contains(".")))
					{ }
					else
					{
						//this.tree.Model.
						if (this.dirPath.TryGetValue(prevDir, out iter))
						{
							//Abstraction.GetInstance().WriteText(this.musicListStore.GetValue(iter, 1).ToString());
							if (this.dirPath.TryGetValue(prevDir + thisDir + "/", out iter2))
							{
								//Abstraction.GetInstance().WriteText(this.musicListStore.GetValue(iter, 1).ToString());
								//iter = this.musicListStore.AppendValues(iter, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), dir2 + "/");
							}
							else
							{
								iter = this.musicListStore.AppendValues(iter, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), thisDir + "/");
							}
						}
						else
						{
							if (this.dirPath.TryGetValue(thisDir + "/", out iter))
							{
								//Abstraction.GetInstance().WriteText(this.musicListStore.GetValue(iter, 1).ToString());
								//iter = this.musicListStore.AppendValues(iter, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), dir2 + "/");
							}
							else
							{
								iter = this.musicListStore.AppendValues(global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), thisDir + "/");
							}
						}
						try
						{
							this.dirPath.Add(prevDir + thisDir + "/", iter);
						}
						catch (Exception e)
						{
						}
						prevDir = prevDir + thisDir + "/";
					}
				}
			}
			//tree.Model = this.musicListStore;
				//iter = musicListStore.AppendValues(global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), "levels/");
				//musicListStore.AppendValues(iter, global::Gdk.Pixbuf.LoadFromResource("OpenGraal.GraalIM.Resources.rc_images.rcfiles_folderclosed.png"), "staff/");
			 
		}

		private string DecodeUrlString(string url)
		{
			return url.Replace("%095","_");
			//	Current.Server.UrlDecode
		}
	}
}

