using UnityEngine;

namespace SkyHook
{
  public class SkyHookManager : MonoBehaviour
  {
    private static SkyHookManager _instance;

    internal static bool IsFocused;

    public bool requireFocus = true;

    private bool _started;

    public static SkyHookManager Instance
    {
      get
      {
        if (_instance) return _instance;

        var obj = new GameObject("SkyHook Manager");

        _instance = obj.AddComponent<SkyHookManager>();

        DontDestroyOnLoad(_instance);

        return _instance;
      }
    }

    private void HookCallback(SkyHookEvent ev)
    {
      Debug.Log($"{ev.Type} {ev.Key} {ev.Time}");
    }

    private void StartHook()
    {
      var result = SkyHookNative.StartHook(HookCallback);

      if (result != null)
      {
        throw new SkyHookException(result);
      }

      _started = true;
    }

    private void StopHook()
    {
      if (!_started) return;

      var result = SkyHookNative.StopHook();

      if (result != null)
      {
        throw new SkyHookException(result);
      }

      _started = false;
    }

    public static void Start()
    {
      Instance.StartHook();
    }

    public static void Stop()
    {
      Instance.StopHook();
    }

    private void OnDestroy()
    {
      Debug.Log("Destroy");
      StopHook();
    }

    private void Run()
    {
      if (requireFocus)
      {
        IsFocused = Application.isFocused;
      }
    }
  }
}