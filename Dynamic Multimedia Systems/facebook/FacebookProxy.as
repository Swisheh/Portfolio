package  {
	import flash.net.URLRequest;
	import flash.net.URLLoader;
	import flash.events.*;
	import com.adobe.serialization.json.JSON;
	
	public class FacebookProxy {
		
		private var functionResultsListener:Function;
		
		var photos:Array = new Array;
		var photoURL:String = "https://graph.facebook.com/362134400532769/albums";
		var aboutURL:String = "https://graph.facebook.com/362134400532769";
		
		public function PhotoSearch(listener:Function) {
			functionResultsListener = listener;
			
			var request:URLRequest = new URLRequest(photoURL);
			var loader:URLLoader = new URLLoader();
			loader.addEventListener(Event.COMPLETE,PhotoHandler);
			loader.load(request);
		}
		
		function PhotoHandler(e:Event){
			var loader:URLLoader = URLLoader(e.target);
			var data:Object = JSON.decode(loader.data);
		
			var albumID = data.data[0].id;
			var photosURL:String = "https://graph.facebook.com/"+albumID+"/photos"
			
			var request:URLRequest = new URLRequest(photosURL);
			var loader2:URLLoader = new URLLoader();
			loader2.addEventListener(Event.COMPLETE,PhotosHandler);
			loader2.load(request);
		}
		
		function PhotosHandler(e:Event){
			var loader:URLLoader = URLLoader(e.target);
			var data:Object = JSON.decode(loader.data);
			
			for(var i:int = 0; i < data.data.length; i++){
				var photoID = data.data[i].id;
				var photoName = data.data[i].name;
				var thumbnailURL = data.data[i].picture;
				var largeURL = data.data[i].source;
				trace(thumbnailURL);
				var likes;
				if(data.data[i].hasOwnProperty("likes")){ 
					likes = data.data[i].likes.data.length;
				}else{
					likes = 0;
				}
				
				var photo = new Photos(photoID,photoName,thumbnailURL,largeURL,likes);
				photos[i] = photo;
			}
			
			functionResultsListener(photos);
		}
		
		public function GetAbout(listener:Function){
			functionResultsListener = listener;
			
			var request:URLRequest = new URLRequest(aboutURL);
			var loader:URLLoader = new URLLoader();
			loader.addEventListener(Event.COMPLETE,AboutHandler);
			loader.load(request);
		}
		
		function AboutHandler(e:Event){
			var loader:URLLoader = URLLoader(e.target);
			var data:Object = JSON.decode(loader.data); 
			functionResultsListener(data.about);
		}
	}
	
}
