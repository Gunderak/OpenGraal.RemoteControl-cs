using System;

namespace OpenGraal.GraalIM
{
	public class AppSettings : OpenGraal.Core.IniFile
	{
		private static AppSettings _instance = new AppSettings();
		public static AppSettings GetInstance()
		{
			return _instance;
		}

		private AppSettings() : base()
		{
		}
		private string _account = null;
		public string Account
		{
			get
			{
				this._account = this.GetValue("credentials", "account", "guest");
				return this._account;
			}
			set
			{
				this._account = value;

				this.SetValue("credentials", "account", this._account);
				this.Save();

			}
		}
		private string _password = null;
		public string Password
		{
			get
			{
				this._password = this.GetValue("credentials", "password", "7Y3bdzjf");

				return this._password;
			}
			set
			{
				this._password = value;
				this.SetValue("credentials", "password", this._password);

				this.Save();
			}
		}
		private string _nickname = null;
		public string Nickname
		{
			get
			{
				this._nickname = this.GetValue("credentials", "nickname", "Guest");
				return this._nickname;
			}
			set
			{
				this._nickname = value;

				this.SetValue("credentials", "nickname", this._nickname);
				this.Save();

			}
		}
		/*
		private bool _rcMode;
		public bool rcMode
		{
			get
			{
				this._rcMode = this.GetValue("other", "rcMode", "true");
				return this._rcMode;
			}
			set
			{
				this._rcMode = value;

				this.SetValue("other", "rcMode", this._rcMode.ToString());
				this.Save();

			}
		}
		*/
		public string EncodeTo64(string toEncode)
		{
			byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
			string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
			return returnValue;
		}

		public string DecodeFrom64(string encodedData)
		{
			byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
			string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
			return returnValue;
		}
	}
}