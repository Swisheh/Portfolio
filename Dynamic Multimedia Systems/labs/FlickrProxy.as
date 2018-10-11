package
{
	import flash.display.MovieClip;
	import flash.events.*;
	import flash.net.URLRequest;
	import flash.net.URLLoader;
	import flash.net.URLVariables;
	import flash.net.navigateToURL;
	import flash.system.*;
	import com.adobe.crypto.*;

	public class FlickrProxy
	{
		private var onPhotoResultsListener:Function;
		
		public var photos:Array = new Array();
		
		public function photoSearch(searchText:String, listener:Function): void
		{
			onPhotoResultsListener = listener;
			var flickrURL:String = 'http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=dc140afe3fd3a251c2fdf9dcd835be5c&text="'+searchText+'"&extras=owner_name%2Curl_sq%2Curl_n&per_page=10&format=rest';
			var signature = signRequest(flickrURL);
			var signedURL:String = flickrURL + '&api_sig=' + signature;
			//trace(signedURL);
			var request:URLRequest = new URLRequest(signedURL);
			//'http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=dc140afe3fd3a251c2fdf9dcd835be5c&text="'+search_txt.text+'"&extras=owner_name%2Curl_sq%2Curl_n&per_page=10&format=rest'
			
			var loader:URLLoader = new URLLoader();
			loader.addEventListener(Event.COMPLETE,completeHandler);
			loader.load(request);
		}
		
		public function signRequest(url:String):String
		{
			var split:Array = url.split("?");
			var urlVariables:URLVariables = new URLVariables(split[1]);
				
			var sortedVariables:Array = [];
			for(var i:String in urlVariables)
			{
				var variable:String = i + urlVariables[i];
				sortedVariables.push(variable);
			}
			sortedVariables.sort();
			//trace(sortedVariables);	
			var stringToSign = sortedVariables.join("")
			
			var secret:String = "faf000ccf1b60ffa";
			stringToSign = secret + stringToSign;
			var signature:String = MD5.hash(stringToSign);
			return signature;
		}
		
		public function completeHandler(e:Event)
		{
			var loader:URLLoader = URLLoader(e.target);
			var data:XML = XML(loader.data);
			//trace(data);
			
			for (var i:int = 0; i < 10; i++)
			{	
				var photoId = data.photos.photo[i].@id;
				var ownerId = data.photos.photo[i].@owner;
				var ownerName = data.photos.photo[i].@ownername;
				var title = data.photos.photo[i].@title;
				var thumbnailURL = data.photos.photo[i].@url_sq;
				var largeURL = data.photos.photo[i].@url_n;
				
				var th:Photo = new Photo(photoId,ownerId,ownerName,title,
										thumbnailURL,largeURL);
				photos[i] = th;
			}
		onPhotoResultsListener(photos);
		}
	}
}