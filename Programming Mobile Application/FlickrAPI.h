//
//  FlickrAPI.h
//  FlickrAPI
//
//  Created by Rene Hexel on 22/04/13.
//  Copyright (c) 2013 Rene Hexel. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * A simple class that demonstrates how to use the Flickr API.
 * For more information on the Flickr API, see
 * http://www.flickr.com/services/api/
 */
@interface FlickrAPI: NSObject

@property NSString *apiKey;             ///< Flickr requires an API key
@property NSInteger maximumResults;     ///< max. results in any one fetch

- initWithAPIKey: (NSString *) key;     ///< create an instance with this key

- (NSMutableArray *) latestPhotos;      ///< get the latest photos
- (NSMutableArray *) topPlacesByRegion; ///< top 100 places in the last 24 hours

- (NSString *) findUser: (NSString *) user; ///< get the user id from their username
- (NSMutableArray *) userPhotos: (NSString *) userid; ///< get the photos from their id

/**
 * Get the photos in a given region
 */
- (NSArray *) photosInRegion: (NSDictionary *) place;

- (NSURL *) photoURLFor: photo;         ///< get original URL for photo

/**
 * Same as above, but get the URL for a photo in the given format.
 * See below for valid photo formats!
 */
- (NSURL *) photoURLFor: photo format: (NSString *) flickrPhotoFormat;

/**
 * Return the URL for a given photo (in a given format) as a string.
 */
- (NSString *) urlStringForPhoto: photo format: (NSString *) format;


/**
 * This is the method that actually fetches data from Flickr.
 * Don't invoke directly, but use one of the above methods instead!
 */
- (NSDictionary *) fetch: (NSString *) request;

@end


/**
 * Flickr photo formats.
 * You need to specify one of them for downloading.
 */
extern NSString *kFlickrPhotoFormatOriginal;
extern NSString *kFlickrPhotoFormatSquare;
extern NSString *kFlickrPhotoFormatBig;
extern NSString *kFlickrPhotoFormatSmall;
extern NSString *kFlickrPhotoFormatThumbnail;
extern NSString *kFlickrPhotoFormat500;
extern NSString *kFlickrPhotoFormat640;

