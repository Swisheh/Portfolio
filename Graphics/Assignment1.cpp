//////////////////////////////////////////////////////////////
/// Author:             <Rory Hiscock>
/// Student Number:     <s2776863>
/// Operating System:   <Windows>
/// Comments:           <Run both Assignment1.h and Assignment1.cpp in the project starter set>
//////////////////////////////////////////////////////////////

#include "Assignment1.h"
#include <iostream>
#include <cmath>
#include <math.h>

using namespace std;

#if defined(__MACH__) && defined(__APPLE__)
    // Allow SDL main hack, because of the OS X Cocoa binding
#else
    // SDL main hackery disabled for Windows and Linux
    #define SDL_main main           
#endif

// Draw objects here
    float scale = 256.0f;    // Size of the triangle
    float half = scale/2;

// An equilateral triangle with center at origin
    Point a(0, int(-scale), 255, 0, 0);
    Point b(int(half*sqrt(3.f)), int(half), 0, 255, 0);
    Point c(int(-half*sqrt(3.f)), int(half), 0, 0, 255);

// Globals for moving 
	int aX = 400; int aY = 100;
	int bX = 100; int bY = 500;
	int cX = 700; int cY = 500;

// Counter for triangle clicks
	int clicked = 4;

int main(int argc, char* argv[])
{
    Core example;
    example.start();
    return 0;
}

Core::Core(int width, int height) : running(true)
{
    this->width = width;
    this->height = height;
}

Core::~Core()
{
    // Allows SDL to exit properly
    if (SDL_WasInit(SDL_INIT_VIDEO))
        SDL_Quit();
}

void Core::start()
{
    // Setup and then enter main loop
    initialise();
    while (running) {
        render();
        handleEvents();
    }
}

void Core::initialise()
{
    // Initialise SDL
    if (SDL_Init(SDL_INIT_VIDEO) < 0) {
        cerr << SDL_GetError() << endl;
        SDL_Quit();
    }

    // Create a framebuffer
    Uint32 flags = SDL_SWSURFACE | SDL_DOUBLEBUF;

    buffer = SDL_SetVideoMode(width, height, 32, flags);
    if (!buffer) {
        cerr << SDL_GetError() << endl;
        SDL_Quit();
    }
}

void Core::render()
{
    // Clear the screen to black
    SDL_FillRect(buffer, NULL, 0);

    SDL_LockSurface(buffer);
    /////////////////////////////////////
    // Draw objects here
    //float scale = 256.0f;    // Size of the triangle
    //float half = scale/2;

	// An equilateral triangle with center at origin
    //Point a(0, int(-scale), 255, 0, 0);
    //Point b(int(half*sqrt(3.f)), int(half), 0, 255, 0);
    //Point c(int(-half*sqrt(3.f)), int(half), 0, 0, 255);
	//Point d(int(-half*sqrt(3.f)), int(half), 0, 0, 255);

    // You should modify these values to test your clipping.
    a.x = aX;     a.y = aY;
    b.x = bX;     b.y = bY;
    c.x = cX;     c.y = cY;
	
	

	// Sort the points into A, B, C in anticlockwise, where A is the top point (smallest y). If
    // More than one point competes, the point with a smaller x value wins.
	sortTriVertices(a, b, c);

    vector<Point> polygon;  // our polygon is a triangle for the moment
    polygon.push_back(a);
    polygon.push_back(b);
    polygon.push_back(c);
	
	//Draw before doing clipping
	//drawTriangle(a,b,c);
	// clip polygon and do polygon decomposition
    vector<Point> clipped = decompose(clip(polygon));
	//cout<<polygon.size();
	//cout<<clipped.size();

    for (int i = 0; i < (int)clipped.size(); i+=3)
        drawTriangle(clipped[i], clipped[i+1], clipped[i+2]);

    /////////////////////////////////////
    SDL_UnlockSurface(buffer);
    // Flip the buffers
    SDL_Flip(buffer);
}

/////////////////////////////////////
// Lab Exercise

/////////////////////////////////////
// Renders a triangle(a, b, c) to buffer
void Core::drawTriangle(Point a, Point b, Point c)
{

    Point A = a, B = b, C = c;
	sortTriVertices(a, b, c);

	//cout<<a.x<<" "<<a.y<<" a\n";
	//cout<<b.x<<" "<<b.y<<" b\n";
	//cout<<c.x<<" "<<c.y<<" c\n";

	vector<int> Ledge (800), Redge(800); //- edge arrays
	double red = a.r;
	double green = a.g;
	double blue = a.b;
	if(a.y == b.y){
		double mL = (c.x - a.x) / (double)(c.y - a.y);
		double mR = (c.x - b.x) / (double)(c.y - b.y);
		double xL = a.x;
		double xR = b.x;
		int hL = c.y - a.y;
		int hR = c.y - b.y;
		int high = (hL > hR) ? hL : hR;
		if (abs(hL) > abs(hR)) high = abs(hL);
		else high = abs(hR);
		int j = abs(a.y);
		for (int y = 0; y < high; y++){
			Ledge.at(y) = xL;
			Redge.at(y) = xR;
			for (int o = xL; o < xR; o++){
				putpixel(o, j, 255, 255, 255, 255);
			}
			j++;
			xL += mL;
			xR += mR;
		}
	} else {
		double mL = (b.x - a.x) / (double)(b.y - a.y);
		double mR = (c.x - a.x) / (double)(c.y - a.y);
		double xL = a.x;
		double xR = a.x;
		int hL = b.y - a.y;
		int hR = c.y - a.y;
		int high = (hL > hR) ? hL : hR;
		if (abs(hL) > abs(hR)) high = abs(hL);
		else high = abs(hR);
		//int lenL = sqrt (pow((a.x - b.x), 2.0) + pow((a.y - b.y), 2.0));
		//int lenR = sqrt (pow((a.x - c.x), 2.0) + pow((a.y - c.y), 2.0)); 
		int j = abs(a.y);
		bool hLpass = false;
		bool hRpass = false;
		for (int y = 0; y < high; y++){
			Ledge.at(y) = xL;
			Redge.at(y) = xR;
			int dif = xL - xR;			
			if (y == hL){
				mL = (c.x - b.x) / (double)(c.y - b.y);
				hLpass = true;
			}
			if (y == hR){ 
				mR = (b.x - c.x) / (double)(b.y - c.y);
				hRpass = true;
			}
			double redPix = red+(blue-red)*y/high;
			double greenPix = green+(red-green)*y/high;
			double bluePix = blue+(red-blue)*y/high;
			int z = 0;
			for (int o = xR; o < xL; o++){
				double greenPix = green+ (bluePix-green)*z/dif;
				double bluePix2 = bluePix-greenPix;
				putpixel(o, j, int(redPix), int(greenPix), int(bluePix2), 255);	
				z++;
			}
			
			j++;
			//cout<<xL<<" "<<xR<<"\n:";
			xL += mL;
			xR += mR;
		}
	}
	
}

/////////////////////////////////////
// Sort the vertices of triangle into the anticlockwise sense.
// a should be the topmost & leftmost point.
void Core::sortTriVertices(Point &a, Point &b, Point &c)
{
	// Your code here
	if (b.y <= a.y){
		if (b.y == a.y){
			if (b.y + b.x < a.y + a.x){
				Point temp = a;
				a = b;
				b = temp;
			}
		} else if (b.y < a.y){
			Point temp = a;
			a = b;
			b = temp;
		}
	} 
	
	if (c.y <= a.y){
		if (c.y == a.y){
			if (c.y + c.x < a.y + a.x){
				Point temp = a;
				a = c;
				b = temp;
			}
		} else if (c.y < a.y){
			Point temp = a;
			a = c;
			c = temp;
		}
	}

	

	

	double angle1 = atan2 (double(c.y - a.y) , double(c.x - a.x));
	double angle2 = atan2 (double(b.y - a.y) , double(b.x - a.x));

	if (angle1 < angle2){
		Point temp = c;
		c = b;
		b = temp;
	}
}

/////////////////////////////////////
// "draws" the line(a, b) but stores the result in the vector.
// This can be used to create your edge lists.
// You can keep doing push_back() into the std::vector, but make sure that your lists are
// of equal length after interpolation!
void Core::makeLine(Point a, Point b, vector<Point> *line)
{
    // Your code here. Similar to week 2, but make sure your line only contains one point for every y-value
    // Repeated points with different x-values but same y-value can be skipped.
	float x, y;
	int i;
	float dy = b.y - a.y;
	float dx = b.x - a.x;
	x = a.x;
	y = a.y;
	float m = dx / dy;
	for (i = a.y; i < b.y; i++) {
		putpixel(int(x), int(y), 255, 255, 255, 255);
		line->push_back(Point(int(x), int(y), 255, 255, 255));
		x = x + m;
		y = y + 1;
	}
}

/////////////////////////////////////
// Renders the line(a, b). Assume that a and b have the same y value.
void Core::scanline(Point a, Point b)
{
    // Your code here. Basically same thing as week 2, but you can safely interpolate only on X axis.
	for (int i = b.x; i < a.x; i++) {
		putpixel(int(i), int(a.y), 255, 255, 255, 255);
	}
}

/////////////////////////////////////
// Clips the triangle against the screen boundary.
std::vector<Point> Core::clip(std::vector<Point> polygon)
{
    // We can only work with at least a triangle.
    if (polygon.size() < 3)
        return polygon;

	// The points p0(x0,y0) and p1(x1,y1) are ordered in clipedge such that any points 
	// to the right of the line p0-p1 are inside and vice versa
    polygon = clipedge(polygon, 0, 0, width-1, 0);                  // Top edge
    polygon = clipedge(polygon, 0, height-1, 0, 0);                 // Left edge
    polygon = clipedge(polygon, width-1, height-1, 0, height-1);    // Bottom edge
    polygon = clipedge(polygon, width-1, 0, width-1, height-1);     // Right edge

    return polygon;
}

///////////////////////////////////////////////////////////
// Clips for any line defined by P0(x0, y0), P1(x1, y1). 
vector<Point> Core::clipedge(vector<Point> polygon, int x0, int y0, int x1, int y1)
{
	
    // For each side of the polygon, check the 4 cases of sutherland-hodgman.
    // Creating a temporary buffer to hold your new set of vertices for the clipped polygon.
    vector<Point> temp;
    int size = (int)polygon.size();

    for (int i = 0; i < size; ++i) {
        // Points we're testing
        Point p0 = polygon[i];
        Point p1 = polygon[(i+1)%size]; // The last point is the same as the first point
		//cout<<i<<" "<<(i+1)%size<<"\n";
        // Testing sides
		// Assumes the right hand side of the line being inside.
        int p0_side = testing_side(p0.x, p0.y, x0, y0, x1, y1);
        int p1_side = testing_side(p1.x, p1.y, x0, y0, x1, y1);

        // Consider the 4 cases of Sutherland–Hodgman clipping here. 
		// Remember to calculate the color for any intersection points
		//// your code here 
		if (p0_side >= 0){
            if (p1_side >= 0){
                temp.push_back(p1);
			}else{
                temp.push_back(intersection(p0, p1, x0, y0, x1, y1));
			}
		}else{
			if (p1_side >= 0){
                temp.push_back(intersection(p0, p1, x0, y0, x1, y1));
				temp.push_back(p1);
			}
		}
    }
    return temp;
}

Point Core::intersection(Point p0, Point p1, int x0, int y0, int x1, int y1)
{
    if (x0 == 0 && y0 == 0 && x1 == width-1 && y1 == 0){
		//cout<<"top\n";
		//cout<<p0.x + (0 - p0.y) * (p1.x - p0.x) / (p1.y - p0.y)<<"\n";
		return Point(p0.x + (0 - p0.y) * (p1.x - p0.x) / (p1.y - p0.y), 0, 255, 255, 255);
	}else if(x0 == 0 && y0 == height-1 && x1 == 0 && y1 == 0){
		//cout<<"left\n";
		//cout<<p0.y + (0 - p0.x) * (p1.y - p0.y) / (p1.x - p0.x)<<"\n";
		return Point(0, p0.y + (0 - p0.x) * (p1.y - p0.y) / (p1.x - p0.x), 255, 255, 255);
	}else if(x0 == width-1 && y0 == height-1 && x1 == 0 && y1 == height-1){
		//cout<<"bottom\n";
		return Point(p0.x + (600 - p0.y) * (p1.x - p0.x) / (p1.y - p0.y), 600, 255, 255, 255);
	}else if(x0 == width-1 && y0 == 0 && x1 == width-1 && y1 == height-1){
		//cout<<"right\n";
		return Point(800, p0.y + (800 - p0.x) * (p1.y - p0.y) / (p1.x - p0.x), 255, 255, 255);
	}
	return Point(0, 0, 255, 255, 255);
}

/////////////////////////////////////
// Tests if the point (x, y) lies on the inside or outside of the line P0(x0, y0),
// P1(x1, y1). Positive: inside. Negative: outside. Zero: on the line.
int Core::testing_side(int x, int y, int x0, int y0, int x1, int y1)
{
    //// Your code here
	if (x0 == 0 && y0 == 0 && x1 == width-1 && y1 == 0){
		if (y < 0){
			return -1;
		}
	}else if(x0 == 0 && y0 == height-1 && x1 == 0 && y1 == 0){
		if (x < 0){
			return -1;
		}
	}else if(x0 == width-1 && y0 == height-1 && x1 == 0 && y1 == height-1){
		if (y > 600){
			return -1;
		}
	}else if(x0 == width-1 && y0 == 0 && x1 == width-1 && y1 == height-1){
		if (x > 800){
			return -1;
		}
	}else{
		return 1;
	}
}

/////////////////////////////////////
// Decomposes a polygon (if more than a triangle) into multiple triangles.
std::vector<Point> Core::decompose(std::vector<Point> polygon)
{
     //Your code here. Use triangle-fan for this. Look at the diagram from the lab handout.
	vector<Point> temp;
	if (polygon.size() < 3){
		return polygon;
	}

	for (int i = 0; i < polygon.size() - 2; i++){
		temp.push_back(polygon[0]);
		temp.push_back(polygon[i+1]);
		temp.push_back(polygon[i+2]);
	}
	//cout<<temp.size()<<" points\n";
	return temp;
}

void Core::handleEvents()  
{  
    SDL_Event e;  
    while (SDL_PollEvent(&e)) {  
        switch (e.type) {  
            case SDL_QUIT:  
                running = false;  
            break;  
            case SDL_KEYUP:
                switch (e.key.keysym.sym) {
                    case SDLK_ESCAPE:
                        running = false;
                    break;
						case SDLK_w: { 
							cout<<"W Pressed! Moving up!\n";
							aY -= 5;
							bY -= 5;
							cY -= 5;
							break;
									  }
						case SDLK_s: { 
							cout<<"S Pressed! Moving down!\n";
							aY += 5;
							bY += 5;
							cY += 5;
							break;
										}
						case SDLK_a: { 
							cout<<"A Pressed! Moving left!\n";
							aX -= 5;
							bX -= 5;
							cX -= 5;
							break;
										}
						case SDLK_d: { 
							cout<<"D Pressed! Moving right!\n";
							aX += 5;
							bX += 5;
							cX += 5;
							break;
										}
						//case SDLK_q: { 
						//	int centX = (aX + bX + cX) / 3;
						//	int centY = (aY + bY + cY) / 3;
						//	aX += centX*cos(1.0) - centY*sin(1.0);
						//	aY += centY*sin(1.0) + centX*cos(1.0);
						//	break;
						//				}
						case SDLK_UP: { 
							cout<<"Up Arrow Pressed! Scaling up!\n";
							int centX = (aX + bX + cX) / 3;
							int centY = (aY + bY + cY) / 3;
							aX = aX*1.1;
							aY = aY*1.1;
							bX = bX*1.1;
							bY = bY*1.1;
							cX = cX*1.1;
							cY = cY*1.1;
							int centX2 = (aX + bX + cX) / 3;
							int centY2 = (aY + bY + cY) / 3;
							aX = aX -(centX2 - centX);
							aY = aY -(centY2 - centY);
							bX = bX -(centX2 - centX);
							bY = bY -(centY2 - centY);
							cX = cX -(centX2 - centX);
							cY = cY -(centY2 - centY);
							break;
										}
						case SDLK_DOWN: { 
							cout<<"Down Arrow Pressed! Scaling down!\n";
							int centX = (aX + bX + cX) / 3;
							int centY = (aY + bY + cY) / 3;
							aX = aX/1.1;
							aY = aY/1.1;
							bX = bX/1.1;
							bY = bY/1.1;
							cX = cX/1.1;
							cY = cY/1.1;
							int centX2 = (aX + bX + cX) / 3;
							int centY2 = (aY + bY + cY) / 3;
							aX = aX -(centX2 - centX);
							aY = aY -(centY2 - centY);
							bX = bX -(centX2 - centX);
							bY = bY -(centY2 - centY);
							cX = cX -(centX2 - centX);
							cY = cY -(centY2 - centY);
							break;
										}
						case SDLK_SPACE: { 
							cout<<"Spacebar Pressed! Resetting!\n";
							clicked = 0;
							aX = 0;
							aY = 0;
							bX = 0;
							bY = 0;
							cX = 0;
							cY = 0;
							break;
										}

                    default: break;
                }
            break;
            case SDL_MOUSEBUTTONDOWN: {
				clicked ++;
				cout<<"Mouse Clicked! ";
				if(clicked == 1){
					cout<<"First Point Set!\n";
					aX = e.button.x;
					aY = e.button.y;
					bX = e.button.x;
					bY = e.button.y;
					cX = e.button.x;
					cY = e.button.y;
				} else if (clicked == 2){
					cout<<"Second Point Set!\n";
					bX = e.button.x;
					bY = e.button.y;
				} else if (clicked == 3){
					cout<<"Third Point Set!\n";
					cX = e.button.x;
					cY = e.button.y;
				}
									  }
            break;
            default: break;  
        }  
    }  
}  

void Core::putpixel(int x, int y, Uint8 r, Uint8 g, Uint8 b, Uint8 a)
{
    Uint8 *p = (Uint8 *)buffer->pixels + y * buffer->pitch + x * 4;

#if defined(__MACH__) && defined(__APPLE__)
    *(Uint32 *)p = b << 24 | g << 16 | r << 8 | a; // Big endian
#else
    *(Uint32 *)p = b | g << 8 | r << 16 | a << 24; // Lil endian
#endif
}