// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Collections.Generic;

namespace SmokeAlerter.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

        #endregion

        //UserName
        private const string UserNameKey = "user_name_key";
        private static readonly string UserNameDefault = "";

        //PassWord
        private const string PassWordKey = "pass_word_key";
        private static readonly string PassWordDefault = "";


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserNameKey, value);
            }
        }

        public static string PassWord
        {
            get
            {
                return AppSettings.GetValueOrDefault(PassWordKey, PassWordDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(PassWordKey, value);
            }
        }

	}
}