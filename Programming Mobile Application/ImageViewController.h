//
//  ImageViewController.h
//  Friends
//
//  Created by Rory Hiscock on 14/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FlickrViewController.h"

@interface ImageViewController : UIViewController

//Takes in some basic data
@property NSString *imageTitle;
@property NSData *imageData;

@property (weak, nonatomic) IBOutlet UIImageView *imageView;

@end
