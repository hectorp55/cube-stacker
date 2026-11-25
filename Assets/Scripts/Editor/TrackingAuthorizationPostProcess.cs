#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

// Adds what the App Tracking Transparency prompt needs to the generated Xcode project:
// the AppTrackingTransparency framework and the message shown in the prompt.
public static class TrackingAuthorizationPostProcess
{
    // Text shown under the prompt's title. Apple reviews this, so keep it clear about the purpose.
    private const string TRACKING_MESSAGE = "This lets us show you ads that are more relevant to you and helps keep the game free.";

    [PostProcessBuild(1000)]
    public static void OnPostProcessBuild(BuildTarget target, string buildPath)
    {
        if (target != BuildTarget.iOS) return;

        // Info.plist usage description (iOS crashes the request without it)
        string plistPath = Path.Combine(buildPath, "Info.plist");
        var plist = new PlistDocument();
        plist.ReadFromFile(plistPath);
        plist.root.SetString("NSUserTrackingUsageDescription", TRACKING_MESSAGE);
        plist.WriteToFile(plistPath);

        // Link the framework into UnityFramework, where the native plugin code lives
        string projectPath = PBXProject.GetPBXProjectPath(buildPath);
        var project = new PBXProject();
        project.ReadFromFile(projectPath);
        project.AddFrameworkToProject(project.GetUnityFrameworkTargetGuid(), "AppTrackingTransparency.framework", true);
        project.WriteToFile(projectPath);
    }
}
#endif
