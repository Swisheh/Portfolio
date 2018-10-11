//
//  Photo.h
//  Friends
//
//  Created by Rory Hiscock on 14/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreData/CoreData.h>

@class FlickrStream;

@interface Photo : NSManagedObject

@property (nonatomic, retain) NSData * flickrData;
@property (nonatomic, retain) NSString * imageURL;
@property (nonatomic, retain) FlickrStream *flickrStream;

@end
