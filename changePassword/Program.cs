using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace changePassword
{
	/// <summary>
	/// Change local user password
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			var userName = args[0];
			Console.WriteLine("userName=" + userName);
			var oldPassword = args[1];
			var newPassword = args[2];
			ChangeMyPassword("localhost", userName, oldPassword, newPassword);
		}

		public static void ChangeMyPassword(string machine, string userName, string currentPassword, string newPassword)
		{
			string ldapPath = string.Format("WinNT://{0}/{1},user", machine, userName);
			var directionEntry = new DirectoryEntry(ldapPath, userName, currentPassword, AuthenticationTypes.Secure);
			if (directionEntry != null)
				directionEntry.Invoke("ChangePassword", new object[] {currentPassword, newPassword});
		}
	}
}
