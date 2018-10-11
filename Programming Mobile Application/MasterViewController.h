//
//  MasterViewController.h
//  Friends
//
//  Created by Rory Hiscock on 7/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <UIKit/UIKit.h>

#import <CoreData/CoreData.h>

@interface MasterViewController : UITableViewController <NSFetchedResultsControllerDelegate>

@property (strong, nonatomic) NSFetchedResultsController *fetchedResultsController;
@property (strong, nonatomic) NSManagedObjectContext *managedObjectContext;

@end
