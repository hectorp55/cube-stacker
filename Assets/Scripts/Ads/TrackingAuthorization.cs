using System.Collections;
using UnityEngine;
#if UNITY_IOS && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

// Shows Apple's App Tracking Transparency prompt ("Allow ... to track your activity?").
// Only does anything on an iOS device; in the editor it finishes immediately.
public static class TrackingAuthorization
{
    // Safety net in case iOS never calls back (e.g. the app was not active when asked)
    private const float MAX_WAIT_SECONDS = 60f;

#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")] private static extern int _TrackingAuthorizationStatus();
    [DllImport("__Internal")] private static extern void _RequestTrackingAuthorization();
    [DllImport("__Internal")] private static extern int _IsTrackingRequestComplete();
#endif

    // Shows the prompt if the player hasn't answered it yet, and waits for their answer
    public static IEnumerator Request()
    {
#if UNITY_IOS && !UNITY_EDITOR
        // Already answered on a previous launch, iOS won't show it again
        if (_TrackingAuthorizationStatus() != 0) yield break;

        _RequestTrackingAuthorization();

        float waited = 0f;
        while (_IsTrackingRequestComplete() == 0 && waited < MAX_WAIT_SECONDS)
        {
            waited += Time.unscaledDeltaTime;
            yield return null;
        }

        Debug.Log($"[TrackingAuthorization] Status after prompt: {_TrackingAuthorizationStatus()}");
#else
        yield break;
#endif
    }
}
