namespace Loupedeck.RemoteAppsPlugin
{
    using System;

    public class RemoteAppsApplication : ClientApplication
    {
        public RemoteAppsApplication(){}

        protected override String GetProcessName() => string.Empty;

        protected override String GetBundleName() => string.Empty;
    }
}