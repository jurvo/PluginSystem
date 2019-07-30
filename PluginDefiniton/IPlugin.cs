namespace PluginDefiniton
{
	public interface IPlugin
	{
		/// <summary>
		/// The name of the plugin.
		/// </summary>
		string PluginName { get; }

		/// <summary>
		/// The name of the creator of the plugin.
		/// </summary>
		string Creator { get; }

		/// <summary>
		/// The version of the plugin.
		/// </summary>
		string Version { get; }

		/// <summary>
		/// This method will be executed when the plugin is loaded.
		/// </summary>
		void OnLoad();

		/// <summary>
		/// This method will be executed when Event X occur.
		/// </summary>
		void EventX();
	}
}
