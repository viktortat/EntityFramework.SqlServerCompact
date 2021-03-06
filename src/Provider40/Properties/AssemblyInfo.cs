﻿using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;

#if SQLCE35
[assembly: AssemblyTitle("EntityFrameworkCore.SqlServerCompact35")]
[assembly: AssemblyProduct("EntityFrameworkCore.SqlServerCompact35")]
[assembly: DesignTimeProviderServices(
    typeName: "Microsoft.EntityFrameworkCore.Scaffolding.Internal.SqlCeDesignTimeServices",
    assemblyName: "EntityFrameworkCore.SqlServerCompact35.Design",
    packageName: "EntityFrameworkCore.SqlServerCompact35.Design")]
#else
[assembly: AssemblyTitle("EntityFrameworkCore.SqlServerCompact40")]
[assembly: AssemblyProduct("EntityFrameworkCore.SqlServerCompact40")]
[assembly: DesignTimeProviderServices(
    typeName: "Microsoft.EntityFrameworkCore.Scaffolding.Internal.SqlCeDesignTimeServices",
    assemblyName: "EntityFrameworkCore.SqlServerCompact40.Design",
    packageName: "EntityFrameworkCore.SqlServerCompact40.Design")]
#endif
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0-rc2-final")]
