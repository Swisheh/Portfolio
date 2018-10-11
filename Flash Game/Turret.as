﻿package{//creating the basic skeleton
	import flash.display.MovieClip;
	import flash.events.*;
	public class Turret extends MovieClip{
		private var _root:MovieClip;
		
		private var angle:Number; //the angle that the turret is currently rotated at
		private var radiansToDegrees:Number = 180/Math.PI;//this is needed for the rotation
		private var damage:int = 3;//how much damage this little baby can inflict
		private var range:int = 100;//how far away (in pixels) it can hit a target
		private var enTarget;//the current target that it's rotating towards
		private var cTime:int = 0;//how much time since a shot was fired by this turret
		private var reloadTime:int = 12;//how long it takes to fire another shot
		private var loaded:Boolean = true;//whether or not this turret can shoot
		
		public function Turret(){
			//adding the required listeners
			this.addEventListener(Event.ADDED, beginClass);
			this.addEventListener(Event.ENTER_FRAME, eFrameEvents);
			this.addEventListener(MouseEvent.MOUSE_OVER, thisMouseOver);
			this.addEventListener(MouseEvent.MOUSE_OUT, thisMouseOut);
		}
		private function beginClass(e:Event):void{
			_root = MovieClip(root);
			
			//drawing the turret, it will have a gray, circular, base with a white gun
			this.graphics.beginFill(0x999999);
			this.graphics.drawCircle(0,0,12.5);
			this.graphics.endFill();
			this.graphics.beginFill(0xFFFFFF);
			this.graphics.drawRect(-2.5, 0, 5, 20);
			this.graphics.endFill();
		}
		private function eFrameEvents(e:Event):void{
			//FINDING THE NEAREST ENEMY WITHIN RANGE
			var distance:Number = range;//let's define a variable which will be how far the nearest enemy is
			enTarget = null;//right now, we don't have a target to shoot at
			for(var i:int=_root.enemyHolder.numChildren-1;i>=0;i--){//loop through the children in enemyHolder
				var cEnemy = _root.enemyHolder.getChildAt(i);//define a movieclip that will hold the current child
				//this simple formula with get us the distance of the current enemy
				if(Math.sqrt(Math.pow(cEnemy.y - y, 2) + Math.pow(cEnemy.x - x, 2)) < distance){
					//if the selected enemy is close enough, then set it as the target
					enTarget = cEnemy;
				}
			}
			//ROTATING TOWARDS TARGET
			if(enTarget != null){//if we have a defined target
				//turn this baby towards it
				this.rotation = Math.atan2((enTarget.y-y), enTarget.x-x)/Math.PI*180 - 90;
				if(loaded){//if the turret is able to shoot
					loaded = false;//then make in unable to do it for a bit
					var newBullet:Bullet = new Bullet();//create a bullet
					//set the bullet's coordinates
					newBullet.x = this.x;
					newBullet.y = this.y;
					//set the bullet's target and damage
					newBullet.target = enTarget;
					newBullet.damage = damage;
					_root.addChild(newBullet);//add it to the stage
				}
			}
			//LOADING THE TURRET
			if(!loaded){//if it isn't loaded
				cTime ++;//then continue the time
				if(cTime == reloadTime){//if time has elapsed for long enough
					loaded = true;//load the turret
					cTime = 0;//and reset the time
				}
			}
			if(_root.gameOver){//destroy this if game is over
				this.removeEventListener(Event.ENTER_FRAME, eFrameEvents);
				MovieClip(this.parent).removeChild(this);
			}
		}
		private function thisMouseOver(e:MouseEvent):void{
			_root.rangeCircle.x = this.x-12.5;
			_root.rangeCircle.y = this.y-12.5;
			_root.addChild(_root.rangeCircle);
		}
		private function thisMouseOut(e:MouseEvent):void{
			_root.removeChild(_root.rangeCircle);
		}
	}
}