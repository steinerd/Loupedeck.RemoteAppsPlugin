namespace Loupedeck.RemoteAppsPlugin
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemoteAppsFolder : PluginDynamicFolder
    {
        internal static RemoteAppsFolder Instance { get ; private set; }
        public RemoteAppsFolder()
        {
            Instance = this;
            this.DisplayName = "Remote\nApps";
            this.GroupName = "Controls";
            this.Navigation = PluginDynamicFolderNavigation.ButtonArea;            
        }

        public override IEnumerable<String> GetEncoderPressActionNames()
        {
            return new[]
            {
                null, null, null,
                this.CreateAdjustmentName("Refresh")
            };
        }

        public override IEnumerable<String> GetButtonPressActionNames()
        {

            var systemButtons = new[]
            {
                PluginDynamicFolder.NavigateUpActionName,
            };

            return RemoteAppsPlugin.CurrentRemoteApps.Count() > 0
                ? systemButtons.Concat(RemoteAppsPlugin.CurrentRemoteApps.Select(s => this.CreateCommandName(s.Name)))
                : systemButtons.Concat(new[] { this.CreateCommandName("Nothing\nFound") });
        }

        public override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            var builder = new BitmapBuilder(imageSize);
            var rdpc = RemoteAppsPlugin.CurrentRemoteApps.FirstOrDefault(f => f.Name == actionParameter);

            builder.Clear(new BitmapColor(0, 0, 0));

            //builder.DrawText(actionParameter, BitmapColor.White);
            var ico = BitmapImage.FromFile(rdpc.IconPath);
            ico.Resize(50, 50);
            builder.DrawImage(ico);

            return builder.ToImage();
        }
        

        public override void RunCommand(String actionParameter)
        {
            var rdp = RemoteAppsPlugin.CurrentRemoteApps.FirstOrDefault(f => f.Name == actionParameter);
            System.Diagnostics.Process.Start(rdp.Path, rdp.Args);
        }
    }
}
