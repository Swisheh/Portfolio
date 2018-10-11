//
//  FlickrAPI.m
//  FlickrAPI
//
//  Created by Rene Hexel on 22/04/13.
//  Copyright (c) 2013 Rene Hexel. All rights reserved.
//

#import "FlickrAPI.h"

#define DEFAULT_MAX_RESULTS     75

NSString *kFlickrPhotoFormatOriginal  = @"o";
NSString *kFlickrPhotoFormatSquare    = @"s";
NSString *kFlickrPhotoFormatBig       = @"b";
NSString *kFlickrPhotoFormatSmall     = @"m";
NSString *kFlickrPhotoFormatThumbnail = @"t";
NSString *kFlickrPhotoFormat500       = @"-";
NSString *kFlickrPhotoFormat640       = @"z";

@implementation FlickrAPI

- initWithAPIKey: (NSString *) key
{
        if (!(self = [super init]))
                return nil;

        self.apiKey = key;
        self.maximumResults = DEFAULT_MAX_RESULTS;

        return self;
}


- (NSMutableArray *) latestPhotos
{
        NSString *request = [NSString stringWithFormat: @"http://api.flickr.com/services/rest/?method=flickr.photos.search&license=1,2,4,5,7&per_page=%d&has_geo=1&extras=original_format,tags,description,geo,date_upload,owner_name,place_url", self.maximumResults];

        return [[self fetch: request] valueForKeyPath: @"photos.photo"];
}

// Grabs the user name then sends a request to obtain its id
- (NSString *) findUser: (NSString *) user
{
        NSString *request = [NSString stringWithFormat: @"http://api.flickr.com/services/rest/?method=flickr.people.findByUsername&username=%@", user];

        return [[self fetch: request] valueForKeyPath: @"user.nsid"];
}

//Takes a user id then sends a request to obtain their latest 75 photos
- (NSMutableArray *) userPhotos: (NSString *) userid
{
        NSString *request = [NSString stringWithFormat: @"http://api.flickr.com/services/rest/?method=flickr.photos.search&user_id=%@&extras=original_format,tags,description,geo,date_upload,owner_name,place_url&per_page=%d", userid, self.maximumResults];
        
        return [[self fetch: request] valueForKeyPath: @"photos.photo"];
}


- (NSMutableArray *) topPlacesByRegion
{
        NSString *request = [NSString stringWithFormat: @"http://api.flickr.com/services/rest/?method=flickr.places.getTopPlacesList&place_type_id=8"];

        return [[self fetch: request] valueForKeyPath: @"places.place"];
}


- (NSArray *) photosInRegion: (NSDictionary *) place
{
        NSString *placeId = [place objectForKey: @"place_id"];
        if (!placeId)
                return nil;

        NSString *request = [NSString stringWithFormat: @"http://api.flickr.com/services/rest/?method=flickr.photos.search&place_id=%@&per_page=%d&extras=original_format,tags,description,geo,date_upload,owner_name,place_url", placeId, self.maximumResults];
        
        return [[self fetch: request] valueForKeyPath: @"photos.photo"];
}


- (NSDictionary *) fetch: (NSString *) request
{
        NSString *query = [[NSString stringWithFormat: @"%@&api_key=%@&format=json&nojsoncallback=1", request, self.apiKey]
                           stringByAddingPercentEscapesUsingEncoding: NSUTF8StringEncoding];

        NSURL *queryURL = [NSURL URLWithString: query];
        NSData *responseData = [NSData dataWithContentsOfURL: queryURL];
        if (!responseData)
                return nil;

        NSError *error = nil;
        NSDictionary *jsonContent = [NSJSONSerialization JSONObjectWithData: responseData options: NSJSONReadingMutableContainers error: &error];

        if (!jsonContent)
                NSLog(@"Could not fetch '%@': %@", request, error);

        return jsonContent;
}


- (NSURL *) photoURLFor: photo
{
        NSString *photoURLString = [self urlStringForPhoto: photo format: kFlickrPhotoFormatOriginal];

        if (!photoURLString) return nil;

        return [NSURL URLWithString: photoURLString];
}


- (NSURL *) photoURLFor: photo format: (NSString *) flickrPhotoFormat
{
        NSString *photoURLString = [self urlStringForPhoto: photo format: flickrPhotoFormat];
        
        if (!photoURLString) return nil;
        
        return [NSURL URLWithString: photoURLString];
}


- (NSString *) urlStringForPhoto: photo format: (NSString *) format
{
	id phfarm = photo[@"farm"];
	id server = photo[@"server"];
	id unique = photo[@"id"];
	id secret = photo[@"secret"];

	NSString *kind = @"jpg";
	if ([format isEqualToString: kFlickrPhotoFormatOriginal])
        {
                secret = photo[@"originalsecret"];
                kind = photo[@"originalformat"];
        }

        if (phfarm && server && unique && secret)
                return [NSString stringWithFormat: @"http://farm%@.static.flickr.com/%@/%@_%@_%@.%@", phfarm, server, unique, secret, format, kind];

        return nil;
}



@end
