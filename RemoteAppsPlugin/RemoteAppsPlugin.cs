namespace Loupedeck.RemoteAppsPlugin
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Drawing;

    using IWshRuntimeLibrary;

    public class RemoteAppsPlugin : Plugin
    {
        internal static IDictionary<string, IEnumerable<(string Name, string Path, string Args, string IconPath)>> RemoteAppDesktopCollections;

        internal static string Context { get; set; }
        internal static IEnumerable<(string Name, string Path, String Args, string IconPath)> CurrentRemoteApps
        {
            get =>
                RemoteAppDesktopCollections.Keys.Count() == 1
                    ? RemoteAppDesktopCollections[RemoteAppDesktopCollections.Keys.First()]
                    : string.IsNullOrEmpty(Context) ? new List<(string Name, string Path, string Args, string IconPath)>() : RemoteAppDesktopCollections[Context];
        }

        internal static RemoteAppsPlugin Instance { get; private set; }

        public override Boolean HasNoApplication => true;
        public override Boolean UsesApplicationApiOnly => true;

        public RemoteAppsPlugin()
        {
            Instance = this;
            this.RefreshRADCList();            
        }

        public override void Load() => this.Init();

        public override void Unload()
        {
        }

        private void OnApplicationStarted(Object sender, EventArgs e)
        {
        }

        private void OnApplicationStopped(Object sender, EventArgs e)
        {
        }

        public override void RunCommand(String commandName, String parameter)
        {
            if (parameter == "Refresh")
            {
                this.RefreshRADCList();
                RemoteAppsFolder.Instance.RunCommand(PluginDynamicFolder.NavigateUpActionName);
            }
        }

        public override void ApplyAdjustment(String adjustmentName, String parameter, Int32 diff)
        {
        }

        internal IDictionary<string, IEnumerable<(string Name, string Path, string Args, string IconPath)>> RefreshRADCList()
        {
            var startMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            var programs = Path.Combine(startMenu, @"Programs\");
            var rdacDirectories = Directory.GetDirectories(programs, "*(RADC)", SearchOption.TopDirectoryOnly);
            var getListName = new Func<string, string>(d => d.Replace(programs, "").Replace(" (RADC)", "").Trim());

            var rdacTree = rdacDirectories.ToDictionary(d => getListName(d), d =>
            {
                var computerName = getListName(d);
                var files = Directory.GetFiles(d, "*.lnk");
                var filesObject = files.Select(di =>
                {
                    var shortcut = (IWshShortcut)new WshShell().CreateShortcut(di);
                    var workspace = shortcut.Arguments.Split(new string[] { "Resource\\", @"""" }, StringSplitOptions.RemoveEmptyEntries);
                    var iconPath = $"{workspace[0]}Icons\\{workspace[1].Trim().Replace(".rdp", ".ico")}";
                    return (
                        Name: getListName(di)
                            .Replace($"{computerName}\\", "")
                            .Replace($" ({computerName})", "")
                            .Replace(".lnk", ""),
                        Path: shortcut.TargetPath,
                        Args: shortcut.Arguments,
                        IconPath: iconPath
                    );
                });

                return filesObject;
            });

            RemoteAppDesktopCollections = rdacTree;
            return rdacTree;
        }

        private void Init()
        {
            this.Info.Icon16x16 = EmbeddedResources.ReadImage("Loupedeck.RemoteAppsPlugin.Resources.16.png");
            this.Info.Icon32x32 = EmbeddedResources.ReadImage("Loupedeck.RemoteAppsPlugin.Resources.32.png");
            this.Info.Icon48x48 = EmbeddedResources.ReadImage("Loupedeck.RemoteAppsPlugin.Resources.48.png");
            this.Info.Icon256x256 = EmbeddedResources.ReadImage("Loupedeck.RemoteAppsPlugin.Resources.256.png");
        }
    }
}
