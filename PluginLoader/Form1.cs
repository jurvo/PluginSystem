using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginLoader
{
	public partial class Form1 : Form
	{
		PluginContainer PluginContainer;
		public Form1()
		{
			InitializeComponent();
			PluginContainer = new PluginContainer();
			listBox1.DisplayMember = "PluginName";
			listBox1.Items.AddRange(PluginContainer.Plugins.ToArray());
		}

		private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1 && listBox1.SelectedItem is PluginDefiniton.IPlugin p)
				p.EventX();
		}
	}
}
