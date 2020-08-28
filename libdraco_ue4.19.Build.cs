// Copyright (o) 2016-2020 Code 4 Game <develop@c4g.io>

using UnrealBuildTool;
using System.Collections.Generic;

public class libdraco_ue4 : ModuleRules
{
    public libdraco_ue4(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        string DracoPath = System.IO.Path.Combine(ModuleDirectory, "libdraco-1.3.4");
        string IncludePath = System.IO.Path.Combine(DracoPath, "include");
        List<string> LibPaths = new List<string>();
        List<string> LibFilePaths = new List<string>();

        if ((Target.Platform == UnrealTargetPlatform.Win32) || (Target.Platform == UnrealTargetPlatform.Win64))
        {
            string PlatformName = "";
#if UE_4_23_OR_LATER
            if (Target.Platform == UnrealTargetPlatform.Win32)
            {
                PlatformName = "win32";
            }
            else if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                PlatformName = "win64";
            }
#else
            switch (Target.Platform)
            {
            case UnrealTargetPlatform.Win32:
                PlatformName = "win32";
                break;
            case UnrealTargetPlatform.Win64:
                PlatformName = "win64";
                break;
            }
#endif

            string TargetConfiguration = "Release";
            if (Target.Configuration == UnrealTargetConfiguration.Debug)
            {
                TargetConfiguration = "Debug";
            }

            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", PlatformName, "vs2019", TargetConfiguration));

            LibFilePaths.Add("dracodec.lib");
            LibFilePaths.Add("dracoenc.lib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "linux"));

            LibFilePaths.Add("libdracodec.a");
            LibFilePaths.Add("libdracoenc.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "macos"));

            LibFilePaths.Add("libdracodec.a");
            LibFilePaths.Add("libdracoenc.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "android", "armeabi-v7a"));
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "android", "armeabi-v7a-with-neon"));
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "android", "arm64-v8a"));
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "android", "x86"));
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "android", "x86_64"));

            LibFilePaths.Add("libdracodec.a");
            LibFilePaths.Add("libdracoenc.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "ios", "os"));
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "ios", "simulator"));
            LibPaths.Add(System.IO.Path.Combine(DracoPath, "lib", "ios", "watchos"));

            LibFilePaths.Add("libdracodec.a");
            LibFilePaths.Add("libdracoenc.a");
        }

        PublicIncludePaths.Add(IncludePath);
        PublicLibraryPaths.AddRange(LibPaths);
        PublicAdditionalLibraries.AddRange(LibFilePaths);
    }
}
