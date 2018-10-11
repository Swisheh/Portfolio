//
//  MapViewController.m
//  Friends
//
//  Created by Rory Hiscock on 8/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import "MapViewController.h"

@interface MapViewController () <MKMapViewDelegate>

@property CLGeocoder *geoCoder;
@end

@implementation MapViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

//Once it has loaded, it will create a geo coder and put in the address the user has entered that will then search for that address with a span of 0.02
- (void)viewDidLoad
{
    [super viewDidLoad];
        self.geoCoder = [[CLGeocoder alloc] init];
        self.mapView.mapType = MKMapTypeStandard;
        
        [self.geoCoder geocodeAddressString:self.friend.address completionHandler:^(NSArray *placemarks, NSError *error) {
                if (error){
                      NSLog(@"%@",error);
                        return;
                }
                CLPlacemark *placemark = [placemarks objectAtIndex: 0];
                CLLocation *location = placemark.location;
                CLLocationCoordinate2D coord = location.coordinate;
                MKCoordinateRegion region;
                region.span.latitudeDelta = 0.02;
                region.span.longitudeDelta = 0.02;
                
                self.mapView.region = region;
                self.mapView.centerCoordinate = coord;
        }];
        
        //Sets the title to the users name + address
        self.navigationItem.title = [NSString stringWithFormat:@"%@", self.friend.address];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
