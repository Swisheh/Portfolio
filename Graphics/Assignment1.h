#pragma once
#include "SDL.h"
#include <vector>

class Point
{
public:
    int x;
    int y;
	Uint8 r;
	Uint8 g;
	Uint8 b;
    Point(int x, int y, Uint8 r, Uint8 g, Uint8 b) : x(x), y(y), r(r), g(g), b(b) {}
};

class Core
{
    int width, height;
    bool running;
    SDL_Surface* buffer;

public:
    Core(int width=800, int height=600);
    virtual ~Core();
	
    void start();

protected:
    void initialise();
    void preprocess();
    void render();
    void handleEvents();

    void putpixel(int x, int y, Uint8 r, Uint8 g, Uint8 b, Uint8 a=255);

    void drawTriangle(Point a, Point b, Point c);
    void makeLine(Point a, Point b, std::vector<Point> *line);
    void scanline(Point a, Point b);
	void sortTriVertices(Point &a, Point &b, Point &c);
    std::vector<Point> clip(std::vector<Point> polygon);
    std::vector<Point> clipedge(std::vector<Point> polygon, int x1, int y1, int x2, int y2);
    std::vector<Point> decompose(std::vector<Point> polygon);
    
    int testing_side(int x, int y, int x0, int y0, int x1, int y1);
	Point intersection(Point p0, Point p1, int x0, int y0, int x1, int y1);

};