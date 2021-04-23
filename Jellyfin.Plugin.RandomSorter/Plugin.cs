using System;
using System.Collections.Generic;
using Jellyfin.Plugin.RandomSorter.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.RandomSorter
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "Random Sorter2";

        private readonly Guid _id = new Guid("9eda27ec-6e19-41ff-89e6-cabeebaf3b14");
        public override Guid Id => _id;

        public override string Description => "Add random sorting for lazy night";

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            //public class NameComparer : IBaseItemComparer, IComparer<BaseItem>
        }

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = this.Name,
                    EmbeddedResourcePath = string.Format("{0}.Configuration.configPage.html", GetType().Namespace)
                }
            };
        }
    }
}
