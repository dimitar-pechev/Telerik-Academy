﻿using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.Mocks
{
    internal class ExtendedInstallCommand : InstallCommand
    {
        public ExtendedInstallCommand(IInstaller<IPackage> installer, IPackage package)
            : base(installer, package)
        {
        }

        public IInstaller<IPackage> Installer
        {
            get
            {
                return base.installer;
            }
        }

        public IPackage Package
        {
            get
            {
                return base.package;
            }
        }
    }
}
