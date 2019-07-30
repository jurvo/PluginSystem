namespace Plugin_1
{
    public class TestPlugin : PluginDefiniton.IPlugin
    {
		public string PluginName
		{
			get { return "Test Plugin"; }
		}

		public string Creator
		{
			get { return "jurvo"; }
		}
		public string Version
		{
			get { return "1"; }
		}

		public void OnLoad()
		{
			System.Windows.Forms.MessageBox.Show("Test");
		}

		public void EventX()
		{
			System.Windows.Forms.MessageBox.Show("Event X");
		}
	}
}
