﻿package{
	//imports
	import flash.display.MovieClip;
	import flash.display.Sprite;
	import flash.events.*;
	//defining the class
	public class Enemy extends MovieClip{
		private var _root:MovieClip;
		public var xSpeed:int;//how fast it's going horizontally
		public var ySpeed:int;//how fast it's going vertically
		public var maxSpeed:int = 3;//how fast it can possibly go
		public var health:int;
		public var level:int;//this will be set to the number passed in
		 
		public function Enemy(code:int){
			this.addEventListener(Event.ADDED, beginClass);
			this.addEventListener(Event.ENTER_FRAME, eFrameEvents);
		 
			level = code;//set the level to the value passed in for use in other functions
		}
		private function beginClass(e:Event):void{
			_root = MovieClip(root);//defining the root
			
			health = level*5;
			
			//checking what the start direction is
			if(_root.startDir == 'UP'){//if it's starting up
				this.y = 300;//set the y value off the field
				this.x = _root.startCoord;//make the x value where it should be
				this.xSpeed = 0;//make it not move horizontally
				this.ySpeed = -maxSpeed;//make it move upwards
			} else if(_root.startDir == 'RIGHT'){//and so on for other directions
				this.x = -25;
				this.y = _root.startCoord;
				this.xSpeed = maxSpeed;
				this.ySpeed = 0;
			} else if(_root.startDir == 'DOWN'){
				this.y = -25;
				this.x = _root.startCoord;
				this.xSpeed = 0;
				this.ySpeed = maxSpeed;
			} else if(_root.startDir == 'LEFT'){
				this.x = 550;
				this.y = _root.startCoord;
				this.xSpeed = -maxSpeed;
				this.ySpeed = 0;
			}
			
			//draw the actual enemy, it's just a red ball
			this.graphics.beginFill(0xFF0000);
			this.graphics.drawCircle(12.5,12.5,5);
			this.graphics.endFill();
		}
		private function eFrameEvents(e:Event):void{
			//move it based on x and y value
			this.x += xSpeed;
			this.y += ySpeed;
			
			//checking what direction it goes when finishing the path
			if(_root.finDir == 'UP'){//if it finishes at the top
				if(this.y <= -25){//if the y value is too high
					destroyThis();//then remove this guy from the field
					_root.lives --;//take away a life
				}
			} else if(_root.finDir == 'RIGHT'){//and so on for other directions
				if(this.x >= 550){
					destroyThis();					
					_root.lives --;
				}
			} else if(_root.finDir == 'DOWN'){
				if(this.y >= 300){
					destroyThis();
					_root.lives --;
				}
			} else if(_root.startDir == 'LEFT'){
				if(this.x <= 0){
					destroyThis();
					_root.lives --;
				}
			}
			
			//remove this from stage when game is over
			if(_root.gameOver){
				destroyThis();
			}
			
			//destroy this if health is equal to or below 0
			if(health <= 0){
				destroyThis();
				_root.money += 5*level;
			}
		}
		public function destroyThis():void{
			//this function will make it easier to remove this from stage
			this.removeEventListener(Event.ENTER_FRAME, eFrameEvents);
			this.parent.removeChild(this);
			_root.enemiesLeft --;
		}
	}
}