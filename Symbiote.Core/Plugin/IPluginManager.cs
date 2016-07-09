﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     ▄███████▄                                            ▄▄▄▄███▄▄▄▄                                                             
      █   ███    ███    ███                                          ▄██▀▀▀███▀▀▀██▄                                                           
      █   ███▌   ███    ███  █       ██   █     ▄████▄   █  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █   ███▌   ███    ███ ██       ██   ██   ██    ▀  ██  ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ███▌ ▀█████████▀  ██       ██   ██  ▄██       ██▌ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █   ███    ███        ██       ██   ██ ▀▀██ ███▄  ██  ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █   ███    ███        ██▌    ▄ ██   ██   ██    ██ ██  ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █   █▀    ▄████▀      ████▄▄██ ██████    ██████▀  █    █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for the Plugin Manager.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System.Collections.Generic;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin.Connector;
using Symbiote.Core.Plugin.Endpoint;
using System.Threading.Tasks;
using Symbiote.Core.Model;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Defines the interface for the Plugin Manager.
    /// </summary>
    public interface IPluginManager : IStateful, IManager, IConfigurable<PluginManagerConfiguration>
    {
        #region Properties

        /// <summary>
        /// A list of currently loaded plugin assemblies.
        /// </summary>
        List<PluginAssembly> PluginAssemblies { get; }

        /// <summary>
        /// A Dictionary of all Plugin Instances, keyed by instance name.
        /// </summary>
        Dictionary<string, IPluginInstance> PluginInstances { get; }

        /// <summary>
        /// A list of installed plugins.
        /// </summary>
        List<Plugin> Plugins { get; }

        /// <summary>
        /// A list of all Plugin Archives.
        /// </summary>
        List<PluginArchive> PluginArchives { get; }

        /// <summary>
        /// A list of all invalid Plugin Archives.
        /// </summary>
        List<InvalidPluginArchive> InvalidPluginArchives { get; }

        /// <summary>
        /// The manager for Plugins of type Connector.
        /// </summary>
        ConnectorManager ConnectorManager { get; }

        /// <summary>
        /// The manager for Plugins of type Endpoint.
        /// </summary>
        EndpointManager EndpointManager { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Refreshes the lists of valid and invalid Plugin Archives.
        /// </summary>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        PluginArchiveLoadResult ReloadPluginArchives();

        /// <summary>
        /// Asynchronously installs the Plugin contained within the supplied PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <returns>A Result containing the result of the operation and the installed Plugin.</returns>
        Task<Result<Plugin>> InstallPluginAsync(PluginArchive archive);

        /// <summary>
        /// Installs the Plugin contained within the supplied PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <param name="updatePlugin">When true, bypasses checks that prevent</param>
        /// <returns>A Result containing the result of the operation and the installed Plugin.</returns>
        Result<Plugin> InstallPlugin(PluginArchive archive, bool updatePlugin = false);

        /// <summary>
        /// Asynchronously uninstalls the supplied plugin by deleting the directory using the default IPlatform, then removes it from the default
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<Result> UninstallPluginAsync(Plugin plugin);

        /// <summary>
        /// Uninstalls the supplied plugin by deleting the directory using the default IPlatform, then removes it from the default 
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result UninstallPlugin(Plugin plugin);

        /// <summary>
        /// Asynchronously reinstalls the specified Plugin by uninstalling, then installing from the original archive.
        /// </summary>
        /// <param name="plugin">The Plugin to reinstall.</param>
        /// <returns>A Result containing the result of hte operation.</returns>
        Task<Result> ReinstallPluginAsync(Plugin plugin);

        /// <summary>
        /// Reinstalls the specified Plugin by uninstalling, then installing from the original archive.
        /// </summary>
        /// <param name="plugin">The Plugin to reinstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result ReinstallPlugin(Plugin plugin);

        /// <summary>
        /// Asynchronously Updates the Plugin contained within the specified PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive to use for the update.</param>
        /// <returns>A Result containing the result of the operation and the updated Plugin.</returns>
        Task<Result<Plugin>> UpdatePluginAsync(PluginArchive archive);

        /// <summary>
        /// Updates the Plugin contained withing the specified PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive to use for the update.</param>
        /// <returns>A Result containing the result of the operation and the updated Plugin.</returns>
        Result<Plugin> UpdatePlugin(PluginArchive archive);

        /// <summary>
        /// Searches the Plugins list for a Plugin with an FQN matching the supplied FQN and returns it if found.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Plugin to find.</param>
        /// <returns>The Plugin matching the supplied FQN, or the default Plugin if not found.</returns>
        Plugin FindPlugin(string fqn);

        /// <summary>
        /// Loads the Plugin Assembly belonging to the specified Plugin and stores the instance in the PluginAssemblies list.
        /// </summary>
        /// <param name="plugin">The Plugin to which the Plugin Assembly to load belongs.</param>
        /// <returns>A Result containing the result of the operation and the newly created PluginAssembly instance.</returns>
        Result<PluginAssembly> LoadPluginAssembly(Plugin plugin);

        /// <summary>
        /// Finds and returns the PluginAssembly in the PluginAssemblies list whose FQN matches the specified FQN.
        /// </summary>
        /// <param name="fqn">The FQN of the desired PluginAssembly.</param>
        /// <returns>The PluginAssembly instance whose FQN matches the specified FQN, or the default PluginAssembly if not found.</returns>
        PluginAssembly FindPluginAssembly(string fqn);

        /// <summary>
        /// Creates and returns an instance of the specified plugin type with the specified name
        /// </summary>
        /// <remarks>
        ///     The instanceName is propagated through the plugin instance and any internal reference (such as a ConnectorItem).  This name
        ///     should match references to the plugin, either through fully qualified addressing or configuration.
        /// </remarks>
        /// <param name="instanceManager">The ProgramManager instance to be passed to the Plugin instance.</param>
        /// <param name="instanceName">The desired internal name of the instance</param>
        /// <param name="instanceLogger">The logger for the plugin instance.</param>
        /// <typeparam name="T">The Type of the Plugin instance to create.</typeparam>
        /// <returns>A Result containing the result of the operation and the created Plugin instance.</returns>
        Result<IPluginInstance> InstantiatePlugin<T>(ProgramManager instanceManager, string instanceName, xLogger instanceLogger);

        /// <summary>
        /// Given an instance name string, return the matching instance of IPluginInstance.
        /// </summary>
        /// <param name="instanceName">The name of the instance to find.</param>
        /// <param name="pluginType">The Type of instance to find.</param>
        /// <returns>The instance of IPluginInstance matching the requested InstanceName.</returns>
        IPluginInstance FindPluginInstance(string instanceName, PluginType pluginType = PluginType.Connector);

        /// <summary>
        /// Attempts to resolve the supplied plugin item Fully Qualified Name to an instance of Item contained in a Connector plugin.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the instance to find.</param>
        /// <returns>The found Item.</returns>
        Item FindPluginItem(string fqn);

        #endregion
    }
}
