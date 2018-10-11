//
//  DetailViewController.h
//  Friends
//
//  Created by Rory Hiscock on 7/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Friend.h"
#import "Website.h"
#import "FlickrStream.h"

@interface DetailViewController : UITableViewController

@property Friend *friend;
@property id delegate;
@property id segue;

- (IBAction)cancelButton:(id)sender;

@property (weak, nonatomic) IBOutlet UITextField *firstNameText;
@property (weak, nonatomic) IBOutlet UITextField *lastNameText;
@property (weak, nonatomic) IBOutlet UITextField *birthdayText;
@property (weak, nonatomic) IBOutlet UITextField *addressText;

@property (weak, nonatomic) IBOutlet UITextField *homepageURL;
@property (weak, nonatomic) IBOutlet UITextField *flickrURL;

@property (weak, nonatomic) IBOutlet UITextField *imageURL;
@property (weak, nonatomic) IBOutlet UIImageView *imageView;
@end
