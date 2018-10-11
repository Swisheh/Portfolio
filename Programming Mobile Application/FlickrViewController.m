//
//  FlickrViewController.m
//  Friends
//
//  Created by Rory Hiscock on 8/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import "FlickrViewController.h"

@interface FlickrViewController ()

@end

@implementation FlickrViewController

- (id)initWithStyle:(UITableViewStyle)style
{
    self = [super initWithStyle:style];
    if (self) {
        // Custom initialization
    }
    return self;
}

//On load it will remove instances of old photos stored then attempt to get the users id, then photos, then add those photos to the friend object.
- (void)viewDidLoad
{
    [super viewDidLoad];
        if(self.friend.flickrStream.photos){
                [self.friend.flickrStream removePhotos:self.friend.flickrStream.photos];
        }
        
        self.flickr = [[FlickrAPI alloc] initWithAPIKey: @"ce7400807de8249a53392f2ec2cd68d0"];
        self.user = [self.flickr findUser:self.friend.flickrStream.identifier];
        self.photos = [self.flickr userPhotos:self.user];
        
        for(int i = 0; i < self.photos.count; i++){
                Photo *flickrPhoto = [NSEntityDescription insertNewObjectForEntityForName: @"Photo" inManagedObjectContext:self.friend.managedObjectContext];
                NSURL *imageURL = [self.flickr photoURLFor:self.photos[i] format:kFlickrPhotoFormatSmall];
                flickrPhoto.imageURL = [imageURL absoluteString];
                [self.friend.flickrStream addPhotosObject: flickrPhoto];
        }        
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
        return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
        return [self.friend.flickrStream.photos count];
}

//Each cell gets the image title and a thumbnail of the image
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
        UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"Cell"];
        
        cell.textLabel.text = [self.photos[indexPath.row] valueForKeyPath: @"title"];

        NSArray *array = [self.friend.flickrStream.photos allObjects];
        Photo *photo = array[indexPath.row];
                
        cell.imageView.image = [UIImage imageWithData:photo.flickrData];
        NSURL *photoURL = [NSURL URLWithString:photo.imageURL];
        
        //puts the image loading onto a different queue
        if (!cell.imageView.image) {
                dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_LOW, 0),
                               ^{
                                       photo.flickrData = [NSData dataWithContentsOfURL: photoURL];
                                       dispatch_async(dispatch_get_main_queue(),
                                                      ^{
                                                              cell.imageView.image = [UIImage imageWithData:photo.flickrData];

                                                              [tableView beginUpdates];
                                                              [tableView reloadRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationAutomatic];
                                                              [tableView endUpdates];
                                                      });
                               });
        }
        
        return cell;
}

#pragma mark - Table view delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Navigation logic may go here. Create and push another view controller.
    /*
     <#DetailViewController#> *detailViewController = [[<#DetailViewController#> alloc] initWithNibName:@"<#Nib name#>" bundle:nil];
     // ...
     // Pass the selected object to the new view controller.
     [self.navigationController pushViewController:detailViewController animated:YES];
     */
}

//When an image is hit it'll start a segue to the detail view to display a larger image and title
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
        ImageViewController *ivc = segue.destinationViewController;
        NSIndexPath *indexPath = self.tableView.indexPathForSelectedRow;
        NSArray *array = [self.friend.flickrStream.photos allObjects];
        Photo *photo = array[indexPath.row];
        ivc.imageTitle = [self.photos[indexPath.row] valueForKeyPath: @"title"];
        ivc.imageData = photo.flickrData;
}

@end
