package  {
	
	import flash.display.MovieClip;
	
	
	public class Top5Page extends MovieClip {
		var fProxy:FacebookProxy = new FacebookProxy();
		var photos:Array;
		
		public function Top5Page() {
			fProxy.PhotoSearch(completeHandler);
		}
		
		function completeHandler(photos:Array){
			this.photos = photos;
			photos.sortOn("likes", Array.DESCENDING);
			
			for (var i:int = 0; i < 5; i++)
			{
				var th:Thumbnail = new Thumbnail(photos[i]);
				
				if(i < 5)
				{
					th.y = 160;
					th.x = 35 + (th.width * i) + (i * 100);
				}
				else if(i < 10 && i >= 5)
				{
					th.y = 255;
					th.x = 35 + (th.width * (i-5)) + ((i-5) * 100);
				}
				
				addChild(th);
			}
		}
	}
}
