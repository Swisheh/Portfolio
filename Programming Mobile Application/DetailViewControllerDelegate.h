//
//  DetailViewControllerDelegate.h
//  Friends
//
//  Created by Rory Hiscock on 7/05/13.
//  Copyright (c) 2013 Rory Hiscock. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol DetailViewControllerDelegate <NSObject>

- (void) detailViewControllerIsAboutToDisappear: (id) detailViewController;

@end
