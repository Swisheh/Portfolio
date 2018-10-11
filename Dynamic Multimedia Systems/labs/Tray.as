package
{
	import flash.display.MovieClip;
	import flash.events.*;
	
	public class Tray extends MovieClip
	{
		var animating:Boolean = false;
		
		public function Tray()
		{
			addEventListener(MouseEvent.MOUSE_OVER, trayOver);
			addEventListener(Event.ENTER_FRAME, trayEnterFrame);
			addEventListener(MouseEvent.MOUSE_OUT, trayOut);
			//addEventListener(Event.EXIT_FRAME, trayExitFrame);
		}
		
		function trayOver(e:MouseEvent):void
		{
			animating = true;
		}
		
		function trayEnterFrame(e:Event):void
		{
			if(animating && MovieClip(root).tray1.y > 262.85){
				MovieClip(root).tray1.y -= 5;
			}
			
			if((animating == false) && MovieClip(root).tray1.y < 369.80){
				MovieClip(root).tray1.y += 5;
			}
		}
		
		function trayOut(e:MouseEvent):void
		{
			animating = false;
			// MovieClip(root).tray1.y =  369.80;
		} 
		
		/* function trayExitFrame(e:Event):void
		{
			removeEventListener(Event.ENTER_FRAME, trayEnterFrame);
		} */
	}
}