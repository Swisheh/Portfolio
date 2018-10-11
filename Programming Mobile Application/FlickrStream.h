//
//  FlickrStream.h
//  Friends
//
//  Created by Rory Hiscock on 14/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreData/CoreData.h>

@class Event, Photo;

@interface FlickrStream : NSManagedObject

@property (nonatomic, retain) NSString * identifier;
@property (nonatomic, retain) Event *friend;
@property (nonatomic, retain) NSSet *photos;
@end

@interface FlickrStream (CoreDataGeneratedAccessors)

- (void)addPhotosObject:(Photo *)value;
- (void)removePhotosObject:(Photo *)value;
- (void)addPhotos:(NSSet *)values;
- (void)removePhotos:(NSSet *)values;

@end
