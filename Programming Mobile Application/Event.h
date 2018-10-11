//
//  Event.h
//  Friends
//
//  Created by Rory Hiscock on 14/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreData/CoreData.h>

@class FlickrStream, Website;

@interface Event : NSManagedObject

@property (nonatomic, retain) NSString * address;
@property (nonatomic, retain) NSString * birthday;
@property (nonatomic, retain) NSString * firstName;
@property (nonatomic, retain) NSData * image;
@property (nonatomic, retain) NSString * imageURL;
@property (nonatomic, retain) NSString * lastName;
@property (nonatomic, retain) FlickrStream *flickrStream;
@property (nonatomic, retain) Website *homepage;

@end
