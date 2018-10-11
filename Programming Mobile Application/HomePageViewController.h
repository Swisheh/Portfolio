//
//  HomePageViewController.h
//  Friends
//
//  Created by Rory Hiscock on 7/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Friend.h"
#import "Website.h"

@interface HomePageViewController : UIViewController

@property Friend *friend;

@property (weak, nonatomic) IBOutlet UIWebView *webView;

@end
