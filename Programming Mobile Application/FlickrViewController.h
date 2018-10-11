//
//  FlickrViewController.h
//  Friends
//
//  Created by Rory Hiscock on 8/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Friend.h"
#import "FlickrAPI.h"
#import "Photo.h"
#import "FlickrStream.h"
#import "ImageViewController.h"

@interface FlickrViewController : UITableViewController <UITableViewDelegate>

@property (strong, nonatomic) NSFetchedResultsController *fetchedResultsController;

@property Friend *friend;
@property FlickrAPI *flickr;

//Saves flickr api responses to these
@property NSString *user;
@property NSArray *photos;

@end
