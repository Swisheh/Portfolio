//
//  Website.h
//  Friends
//
//  Created by Rory Hiscock on 14/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreData/CoreData.h>

@class Event;

@interface Website : NSManagedObject

@property (nonatomic, retain) NSString * url;
@property (nonatomic, retain) Event *owner;

@end
