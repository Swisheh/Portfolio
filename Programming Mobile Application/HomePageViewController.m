//
//  HomePageViewController.m
//  Friends
//
//  Created by Rory Hiscock on 7/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import "HomePageViewController.h"

@interface HomePageViewController ()

@end

@implementation HomePageViewController

//Once loaded it will load the users homepage into a webview
- (void)viewDidLoad
{
    [super viewDidLoad];
        
        self.navigationItem.title = [NSString stringWithFormat:@"%@'s Homepage", self.friend.firstName];
        NSURL *url = [NSURL URLWithString: self.friend.homepage.url];
        NSURLRequest *urlRequest = [NSURLRequest requestWithURL: url];
        [self.webView loadRequest: urlRequest];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
