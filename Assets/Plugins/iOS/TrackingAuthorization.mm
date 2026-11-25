#import <AppTrackingTransparency/AppTrackingTransparency.h>

// Native side of TrackingAuthorization.cs: asks iOS for App Tracking Transparency permission.
static bool s_RequestComplete = false;

extern "C"
{
    // 0 = not determined, 1 = restricted, 2 = denied, 3 = authorized
    int _TrackingAuthorizationStatus()
    {
        if (@available(iOS 14, *))
        {
            return (int)[ATTrackingManager trackingAuthorizationStatus];
        }
        // Before iOS 14 there is no prompt and tracking is allowed
        return 3;
    }

    void _RequestTrackingAuthorization()
    {
        if (@available(iOS 14, *))
        {
            s_RequestComplete = false;
            [ATTrackingManager requestTrackingAuthorizationWithCompletionHandler:^(ATTrackingManagerAuthorizationStatus status) {
                s_RequestComplete = true;
            }];
        }
        else
        {
            s_RequestComplete = true;
        }
    }

    int _IsTrackingRequestComplete()
    {
        return s_RequestComplete ? 1 : 0;
    }
}
