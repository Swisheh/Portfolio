//
//  MapViewController.h
//  Friends
//
//  Created by Rory Hiscock on 8/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h>
#import "Friend.h"

@interface MapViewController : UIViewController

@property IBOutlet MKMapView *mapView;
@property Friend *friend;

@end
