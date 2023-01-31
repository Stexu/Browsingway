using CefSharp;
using CefSharp.OffScreen;
using System.Reflection;

namespace Browsingway.Renderer;

internal static class CefHandler
{
	public static void Initialise(string cefAssemblyPath, string cefCacheDir, int parentPid)
	{
		CefSettings settings = new()
		{
			BrowserSubprocessPath = Path.Combine(cefAssemblyPath, "CefSharp.BrowserSubprocess.exe"), CachePath = cefCacheDir,
#if !DEBUG
			LogSeverity = LogSeverity.Fatal,
#endif
		};
		settings.CefCommandLineArgs["autoplay-policy"] = "no-user-gesture-required";
		settings.EnableAudio();
		settings.SetOffScreenRenderingBestPerformanceArgs();
		settings.UserAgentProduct = $"Mozilla/5.0 (SMART-TV; LINUX; Tizen 5.5) AppleWebKit/537.36 (KHTML, like Gecko) 69.0.3497.106.1/5.5 TV Safari/537.36";

		Cef.Initialize(settings, false, browserProcessHandler: null);
	}

	public static void Shutdown()
	{
		Cef.Shutdown();
	}
}