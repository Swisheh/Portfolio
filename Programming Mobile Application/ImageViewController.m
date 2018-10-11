//
//  ImageViewController.m
//  Friends
//
//  Created by Rory Hiscock on 14/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import "ImageViewController.h"

@interface ImageViewController ()

@end

@implementation ImageViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

//On load it will change the title and image view to the picture
- (void)viewDidLoad
{
    [super viewDidLoad];
        self.imageView.image = [UIImage imageWithData:self.imageData];
        self.navigationItem.title = [NSString stringWithFormat:@"%@", self.imageTitle];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
