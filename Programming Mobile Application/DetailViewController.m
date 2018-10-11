//
//  DetailViewController.m
//  Friends
//
//  Created by Rory Hiscock on 7/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import "DetailViewController.h"
#import "DetailViewControllerDelegate.h"
#import "HomePageViewController.h"
#import "FlickrViewController.h"
#import "MapViewController.h"

@interface DetailViewController ()
- (void)configureView;
@end

@implementation DetailViewController

#pragma mark - Managing the detail item

//Adds the friends details to the relevant boxes
- (void)configureView
{
        self.firstNameText.text = self.friend.firstName;
        self.lastNameText.text = self.friend.lastName;
        self.birthdayText.text = self.friend.birthday;
        self.addressText.text = self.friend.address;
        
        self.homepageURL.text = self.friend.homepage.url;
        
        self.flickrURL.text = self.friend.flickrStream.identifier;
        
        self.imageURL.text = self.friend.imageURL;
        self.imageView.image = [UIImage imageWithData:self.friend.image];
}

//Sets the navigation title to the friends first and last name
- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
        self.navigationItem.title = [NSString stringWithFormat:@"%@ %@", self.friend.firstName, self.friend.lastName];
        [self configureView];
}

//When the view disappears it'll save the object and set the delegate to self
- (void)viewWillDisappear:(BOOL)animated {
        [super viewWillDisappear:animated];
        self.friend.firstName = self.firstNameText.text;
        self.friend.lastName = self.lastNameText.text;
        self.friend.birthday = self.birthdayText.text;
        self.friend.address = self.addressText.text;
        
        self.friend.homepage.url = self.homepageURL.text;
        
        self.friend.flickrStream.identifier = self.flickrURL.text;
        
        self.friend.imageURL = self.imageURL.text;
        
        [self.friend.managedObjectContext save:NULL];
        [self.delegate detailViewControllerIsAboutToDisappear: self];
}

//Makes the text field disappear when the user hits enter & locally saves the changes the user has made. It also loads an image if the user hit enter on the imageURL field
- (BOOL) textFieldShouldReturn:(UITextField *)textField
{
        if (textField == self.imageURL) {
                NSLog(@"Textfield worked");
                dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_LOW, 0),
                        ^{
                               NSURL *imageURL = [NSURL URLWithString: self.imageURL.text];
                               NSData *imageData = [NSData dataWithContentsOfURL: imageURL];
                               self.friend.image = imageData;
                               dispatch_async(dispatch_get_main_queue(),
                                              ^{
                                                      self.imageView.image = [UIImage imageWithData:imageData];
                                              });
                       });
        }
        self.friend.firstName = self.firstNameText.text;
        self.friend.lastName = self.lastNameText.text;
        self.friend.birthday = self.birthdayText.text;
        self.friend.address = self.addressText.text;
        
        self.friend.homepage.url = self.homepageURL.text;
        
        self.friend.flickrStream.identifier = self.flickrURL.text;
                
        self.friend.imageURL = self.imageURL.text;
        
        [textField resignFirstResponder];
        
        return YES;
}

//Sets the destination view controllers and sends the friend object through with it
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
        if([segue.identifier isEqualToString:@"gotoHomepage"])
        {
                HomePageViewController *hvc = segue.destinationViewController;
                hvc.friend = self.friend;
        }
        if([segue.identifier isEqualToString:@"gotoFlickr"])
        {
                FlickrViewController *fvc = segue.destinationViewController;
                fvc.friend = self.friend;
        }
        if([segue.identifier isEqualToString:@"gotoMap"])
        {
                MapViewController *mvc = segue.destinationViewController;
                mvc.friend = self.friend;
        }
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

//Hitting the cancel button will rollback any changes made to the friend
- (IBAction)cancelButton:(id)sender
{
        [self.friend.managedObjectContext rollback];
        [self configureView];
}
@end
