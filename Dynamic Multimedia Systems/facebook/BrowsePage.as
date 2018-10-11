package  {
	
	import flash.display.MovieClip;
	import flash.text.TextField;
	import flash.text.TextFormat;
	import flash.events.MouseEvent;
	
	public class BrowsePage extends MovieClip {
		var fProxy:FacebookProxy = new FacebookProxy();
		var startPos:int = 0;
		var photos:Array;
		var thumbnails:Array = new Array;
		
		var nextBtn:nextPage = new nextPage;
		var nextTextField:TextField = new TextField();
		var prevBtn:previousPage = new previousPage;	
		var prevTextField:TextField = new TextField();
		
		public function BrowsePage() {
			fProxy.PhotoSearch(completeHandler);
			
			nextBtn.addEventListener(MouseEvent.CLICK,NextClick);
			prevBtn.addEventListener(MouseEvent.CLICK,PrevClick);
		}
		
		function completeHandler(photos:Array){
			this.photos = photos;

			if(photos.length > (startPos + 10)){
				nextBtn.x = 360;
				nextBtn.y = 462.95;
				nextBtn.width = 30;
				nextBtn.height = 30;
				addChild(nextBtn);
				
				nextTextField.type = "dynamic";
				nextTextField.text = "Next";
				nextTextField.y = 462.95;
				nextTextField.x = nextBtn.x + 15;
				nextTextField.embedFonts = true;
				var myFont:GilSans = new GilSans();
				var myFmt:TextFormat = new TextFormat();
				myFmt.font = myFont.fontName;
				myFmt.color = 0xCCCCCC;
				nextTextField.setTextFormat(myFmt);
				addChild(nextTextField);
			}
			
			if(startPos > 0){
				prevBtn.x = 186.10;
				prevBtn.y = 462.95;
				prevBtn.width = 30;
				prevBtn.height = 30;
				addChild(prevBtn);
				
				prevTextField.type = "dynamic";
				prevTextField.text = "Previous";
				prevTextField.y = 462.95;
				prevTextField.x = prevBtn.x - 60;
				prevTextField.width = 45;
				prevTextField.embedFonts = true;
				var myFont2:GilSans = new GilSans();
				var myFmt2:TextFormat = new TextFormat();
				myFmt2.font = myFont2.fontName;
				myFmt2.color = 0xCCCCCC;
				prevTextField.setTextFormat(myFmt2);
				addChild(prevTextField)
			}
			
			for (var i:int = startPos; i < photos.length; i++){
				var th:Thumbnail = new Thumbnail(photos[i]);
				
				if((i-startPos) < 5)
				{
					th.y = 160;
					th.x = 35 + (th.width * (i-startPos)) + ((i-startPos) * 100);
				}
				else if((i-startPos) < 10 && (i-startPos) >= 5)
				{
					th.y = 300;
					th.x = 35 + (th.width * ((i-startPos)-5)) + (((i-startPos)-5) * 100);
				}
				else if((i-startPos) >= 10)
				{
					break;
				}
				
				thumbnails[(i-startPos)] = th;
				addChild(th);
			}
		}
		
		function NextClick(e:MouseEvent){
			startPos = startPos + 10;
			for (var o:int = 0; o < thumbnails.length; o++){
				removeChild(thumbnails[o]);
			}
			thumbnails = new Array; //Remove all elements left in the array
			removeChild(nextBtn);
			removeChild(nextTextField);
			completeHandler(photos);
		}
		
		function PrevClick(e:MouseEvent){
			startPos = startPos - 10;
			for (var o:int = 0; o < thumbnails.length; o++){
				removeChild(thumbnails[o]);
			}
			thumbnails = new Array; //Remove all elements left in the array
			removeChild(prevBtn);
			removeChild(prevTextField);
			completeHandler(photos);
		}
	}
	
}
