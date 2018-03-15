// Copyright (c) 2016-2018 Code 4 Game <develop@c4g.io>

using UnrealBuildTool;

public class libdraco_ue4 : ModuleRules
{
    public libdraco_ue4(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        string DracoPath = System.IO.Path.Combine(ModuleDirectory, "libdraco-1.2.5");
        string IncludePath = System.IO.Path.Combine(DracoPath, "include");
        string LibPath = "";

        if ((Target.Platform == UnrealTargetPlatform.Win32) || (Target.Platform == UnrealTargetPlatform.Win64))
        {
            string VSPath = "vs" + WindowsPlatform.GetVisualStudioCompilerVersionName();

            string PlatformPath = "";
            switch (Target.Platform)
            {
            case UnrealTargetPlatform.Win32:
                PlatformPath = "win32";
                break;
            case UnrealTargetPlatform.Win64:
                PlatformPath = "win64";
                break;
            }

            LibPath = System.IO.Path.Combine(DracoPath, "lib", VSPath, PlatformPath, "Release");

            PublicAdditionalLibraries.Add("dracodec.lib");
            PublicAdditionalLibraries.Add("dracoenc.lib");
        }

        PublicIncludePaths.Add(IncludePath);
        PublicLibraryPaths.Add(LibPath);
    }
}
