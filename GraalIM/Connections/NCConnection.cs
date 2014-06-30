using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using OpenGraal;
using OpenGraal.Core;
using OpenGraal.GraalIM;

namespace OpenGraal.GraalIM
{
	public class NCConnection : CSocket
	{
		/// <summary>
		/// Enumerator -> Packet In
		/// </summary>
		public enum PacketIn
		{
			NC_NPCGET = 103,	// {103}{INT id}
			NC_NPCDELETE = 104,	// {104}{INT id}
			NC_NPCRESET = 105,	// {105}{INT id}
			NC_NPCSCRIPTGET = 106,	// {106}{INT id}
			NC_NPCWARP = 107,	// {107}{INT id}{CHAR x*2}{CHAR y*2}{level}
			NC_NPCFLAGSGET = 108,	// {108}{INT id}
			NC_NPCSCRIPTSET = 109,	// {109}{INT id}{GSTRING script}
			NC_NPCFLAGSSET = 110,	// {110}{INT id}{GSTRING flags}
			NC_NPCADD = 111,	// {111}{GSTRING info}  - (info) name,id,type,scripter,starting level,x,y
			NC_CLASSGET = 112,	// {112}{class}
			NC_CLASSADD = 113,	// {113}{CHAR name length}{name}{GSTRING script}
			NC_LOCALNPCSGET = 114,	// {114}{level}
			NC_WEAPONLISTGET = 115,	// {115}
			NC_WEAPONGET = 116,	// {116}{weapon}
			NC_WEAPONADD = 117,	// {117}{CHAR weapon length}{weapon}{CHAR image length}{image}{code}
			NC_WEAPONDELETE = 118,	// {118}{weapon}
			NC_CLASSDELETE = 119,	// {119}{class}
			NC_LEVELLISTGET = 150,	// {150}
			NC_LEVELLISTSET = 151,	// {151}{GSTRING levels}
		};

		/// <summary>
		/// Enumerator -> Packet Out
		/// </summary>
		public enum PacketOut
		{
			NC_CHAT = 74,	// {74}{GSTRING text}
			NC_LEVELLIST = 80,	// {80}{GSTRING levels}
			NC_NPCATTRIBUTES = 157,	// {157}{GSTRING attributes}
			NC_NPCADD = 158,	// {158}{INT id}{CHAR 50}{CHAR name length}{name}{CHAR 51}{CHAR type length}{type}{CHAR 52}{CHAR level length}{level}
			NC_NPCDELETE = 159,	// {159}{INT id}
			NC_NPCSCRIPT = 160,	// {160}{INT id}{GSTRING script}
			NC_NPCFLAGS = 161,	// {161}{INT id}{GSTRING flags}
			NC_CLASSGET = 162,	// {162}{CHAR name length}{name}{GSTRING script}
			NC_CLASSADD = 163,	// {163}{class}
			NC_LEVELDUMP = 164,
			NC_WEAPONLISTGET = 167,	// {167}{CHAR name1 length}{name1}{CHAR name2 length}{name2}...
			NC_CLASSDELETE = 188,	// {188}{class}
			NC_WEAPONGET = 192,	// {192}{CHAR name length}{name}{CHAR image length}{image}{script}
		};

		/// <summary>
		/// Member Variables
		/// </summary>
		private Framework Server;
		public bool LoggedIn = false;
		public string Account, Password;

		/// <summary>
		/// Base Constructor
		/// </summary>
		public NCConnection()
			: base()
		{
			Server = Framework.GetInstance();
			this.Init();
			this.Setup();
		}

		~NCConnection()
		{
			System.Console.WriteLine("KILLED");
		}

		/// <summary>
		/// Handle Login Packet
		/// </summary>
		public void SendLogin(string username, string password)
		{
			// Check Type & Version
			int type = 8;
			String version = "NCL21075";
			CString loginPacket = new CString() + (byte)type + version + (byte)username.Length + username + (byte)password.Length + password + "\n";
			SendPacket(loginPacket, true);

			Abstraction.GetInstance().WriteText(loginPacket.ToString());

			this.ReceiveData();

			// Set Login
			LoggedIn = true;
		}

		/// <summary>
		/// Handle Received Data
		/// </summary>
		protected override void HandleData(CString Packet)
		{
			// Player not logged in
			//if (!LoggedIn)
			//	HandleLogin(Packet.ReadString('\n'));

			// Parse Packets
			while (Packet.BytesLeft > 0)
			{
				// Grab Single Packet
				CString CurPacket = Packet.ReadString('\n');

				// Read Packet Type
				int PacketId = CurPacket.ReadGUByte1();

				// Run Internal Packet Function
				switch ((PacketIn)PacketId)
				{
					default:
						Abstraction.GetInstance().WriteText("CLIENTNC -> Packet [" + PacketId + "]: " + CurPacket.Text);
						break;
				}
			}
		}
	}
}
