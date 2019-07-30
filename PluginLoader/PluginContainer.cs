using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using PluginDefiniton;

namespace PluginLoader
{
	class PluginContainer
	{
		private static readonly string defaultPath = @"plugins\";
		private List<IPlugin> plugins;

		public List<IPlugin> Plugins
		{
			get { return plugins; }
		}

		public PluginContainer()
		{
			LoadFromDir();
		}

		private void LoadFromDir()
		{
			LoadFromDir(defaultPath);
		}

		/// <summary>
		/// Loads the plugins from the path.
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="DirectoryNotFoundException"></exception>
		private void LoadFromDir(string path)
		{
			#region Exception throwing
			if (path == null) throw new ArgumentNullException(nameof(path));
			if (path == string.Empty) throw new ArgumentException("Parameter must not be empty.",nameof(path));
			if (!Directory.Exists(path)) throw new DirectoryNotFoundException();
			#endregion

			List<Assembly> assemblies = new List<Assembly>();
			foreach (string dll in Directory.GetFiles(path, "*.dll"))
			{
				assemblies.Add(Assembly.Load(AssemblyName.GetAssemblyName(dll)));
			}

			Type pluginType = typeof(IPlugin);
			List<Type> pluginTypes = new List<Type>();
			foreach (Assembly assembly in assemblies)
			{
				if (assembly != null)
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						if (type.IsInterface || type.IsAbstract)
						{
							continue;
						}
						else
						{
							if (type.GetInterface(pluginType.FullName) != null)
							{
								pluginTypes.Add(type);
							}
						}
					}
				}
			}

			plugins = new List<IPlugin>(pluginTypes.Count);
			foreach (Type type in pluginTypes)
			{
				IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
				plugins.Add(plugin);
			}

			foreach (IPlugin plugin in plugins)
			{
				plugin.OnLoad();
			}
		}
	}
}
