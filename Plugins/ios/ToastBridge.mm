#import <UIKit/UIKit.h>

extern "C" void _showToast(const char* message)
{
    NSString* msg = [NSString stringWithUTF8String:message];

    dispatch_async(dispatch_get_main_queue(), ^{
        UIWindow *window = UIApplication.sharedApplication.keyWindow;
        if (!window) return;

        UILabel *toastLabel = [[UILabel alloc] initWithFrame:CGRectMake(40, window.frame.size.height - 120, window.frame.size.width - 80, 40)];
        toastLabel.backgroundColor = [[UIColor blackColor] colorWithAlphaComponent:0.7];
        toastLabel.textColor = [UIColor whiteColor];
        toastLabel.textAlignment = NSTextAlignmentCenter;
        toastLabel.font = [UIFont systemFontOfSize:14];
        toastLabel.text = msg;
        toastLabel.alpha = 0.0;
        toastLabel.layer.cornerRadius = 10;
        toastLabel.clipsToBounds = YES;

        [window addSubview:toastLabel];

        [UIView animateWithDuration:0.5 animations:^{
            toastLabel.alpha = 1.0;
        } completion:^(BOOL finished) {
            [UIView animateWithDuration:0.5 delay:2 options:0 animations:^{
                toastLabel.alpha = 0.0;
            } completion:^(BOOL finished) {
                [toastLabel removeFromSuperview];
            }];
        }];
    });
}
