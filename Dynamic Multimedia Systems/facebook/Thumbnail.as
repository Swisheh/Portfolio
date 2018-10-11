package
{
	import flash.display.MovieClip;
	import flash.display.Loader;
	import flash.events.*;
	import fl.transitions.*;
	import fl.transitions.easing.*;
	import flash.net.URLRequest;
	import flash.text.TextField;
	import flash.text.TextFormat;
	import flash.geom.*;
	import flash.display.Sprite;
	
	public class Thumbnail extends MovieClip
	{
		var startX;
		var startY;
		
		var photoId;
		var photoName;
		var thumbnailURL;
		var largeURL;
		
		var myLoader:Loader;
		
		var oWidth;
		var nWidth;
		var scaleF;
		var oHeight;
		var nHeight;
		
		public function Thumbnail(photo)
		{	
			this.photoId = photo.photoID;
			this.photoName = photo.photoName;
			this.thumbnailURL = photo.thumbnailURL;
			this.largeURL = photo.largeURL;
			
			myLoader = new Loader();
			var url:URLRequest = new URLRequest(thumbnailURL);
			myLoader.contentLoaderInfo.addEventListener(Event.COMPLETE,completeLoader);
			myLoader.load(url);
			
			addEventListener(MouseEvent.MOUSE_DOWN, mouseDown);
			addEventListener(MouseEvent.MOUSE_UP, mouseUp);
			addEventListener(MouseEvent.MOUSE_OVER, mouseOver);
			addEventListener(MouseEvent.MOUSE_OUT, mouseOut);
		}
		
		function mouseDown(e:MouseEvent)
		{
			if(e.target == this)
			{
				startX = e.target.x;
				startY = e.target.y;
				e.target.startDrag();
			}
			else
			{
				e.target.parent.startDrag();
				startX = e.target.parent.x;
				startY = e.target.parent.y;
			}
		}
		
		function mouseUp(e:MouseEvent)
		{
			var targetT;
			if(e.target == this)
			{
				targetT = e.target;
			}
			else
			{
				targetT = e.target.parent;
			}
			
			targetT.stopDrag();
			
			if(targetT.x == startX && targetT.y == startY)
			{
				//BrowsePage(root).hideThumbnails();
				//MovieClip(root).gotoAndStop(40);
			}
			else
			{
				var tweenX:Tween = new Tween(targetT, "x", Elastic.easeOut, targetT.x,
					startX, 0.5, true);
				var tweenY:Tween = new Tween(targetT, "y", Elastic.easeOut, targetT.y,
					startY, 0.5, true);
					
				tweenX.start();
				tweenY.start();
			}
		}
		
		function mouseOver(e:MouseEvent)
		{
			var clipBounds:Rectangle = getBounds(this);
			graphics.lineStyle(5,0xFFFFFF);
			graphics.drawRect((clipBounds.x - 3), (clipBounds.y - 3), (nWidth + 6), (clipBounds.height + 6));
			var tweenW:Tween = new Tween(this, "scaleX", Regular.easeOut, 1, 
				1.1, 0.5, true);
			var tweenH:Tween = new Tween(this, "scaleY", Regular.easeOut, 1,
				1.1, 0.5, true);
			
			tweenW.start();
			tweenH.start();
		}
		
		function mouseOut(e:MouseEvent)
		{
			var tweenW:Tween = new Tween(e.target, "scaleX", Regular.easeOut, 1.1,
				1, 1, true);
			var tweenH:Tween = new Tween(e.target, "scaleY", Regular.easeOut, 1.1,
				1, 1, true);
				
			tweenW.start();
			tweenH.start();
			graphics.clear();
		}
		
		function completeLoader(e:Event)
		{
			if(myLoader.content.width > myLoader.content.height)
				{
					oWidth = myLoader.content.width;
					nWidth = 75;
					scaleF = nWidth / oWidth;
					
					oHeight = myLoader.content.height;
					nHeight = oHeight * scaleF;
					
					myLoader.content.width = nWidth;
					myLoader.content.height = nHeight;
				}
				else
				{
					oHeight = myLoader.content.height;
					nHeight = 75;
					scaleF = nHeight / oHeight;
					
					oWidth = myLoader.content.width;
					nWidth = oWidth * scaleF;
					
					myLoader.content.width = nWidth;
					myLoader.content.height = nHeight;
				}
			addChild(myLoader.content);
			addImageText();
		}
		
		function addImageText()
		{
			var myTextField:TextField = new TextField();
			myTextField.type = "dynamic";
			myTextField.text = photoName;
			myTextField.y = nHeight;
			myTextField.x = 0;
			myTextField.width = nWidth;
			myTextField.height = 47;
			myTextField.wordWrap = true;
			myTextField.embedFonts = true;
			var myFont:GilSans = new GilSans();
			var myFmt:TextFormat = new TextFormat();
			myFmt.font = myFont.fontName;
			myFmt.color = 0xCCCCCC;
			myFmt.bold = true;
			myFmt.align = "center";
			myTextField.setTextFormat(myFmt);
			addChild(myTextField);
		}
	}
}