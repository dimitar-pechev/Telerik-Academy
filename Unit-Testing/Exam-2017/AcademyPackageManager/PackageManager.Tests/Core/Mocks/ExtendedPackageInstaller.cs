using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Core.Mocks
{
    internal class ExtendedPackageInstaller : PackageInstaller
    {
        public ExtendedPackageInstaller(IDownloader downloader, IProject project)
            : base(downloader, project)
        {
        }

        public IDownloader Downloader
        {
            get
            {
                return base.downloader;
            }
        }

        public IProject Project
        {
            get
            {
                return base.project;
            }
        }
    }
}
