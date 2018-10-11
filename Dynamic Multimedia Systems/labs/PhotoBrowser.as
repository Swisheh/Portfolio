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
	
	public class PhotoBrowser extends MovieClip
	{
		var thumbnails:Array = new Array;
		var frob;
		var authToken;
		var userID;
		var userName;
		
		public function PhotoBrowser()
		{
			Security.loadPolicyFile("http://farm1.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm2.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm3.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm4.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm5.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm6.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm7.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm8.staticflickr.com/crossdomain.xml");
			Security.loadPolicyFile("http://farm9.staticflickr.com/crossdomain.xml");
			
			continue_btn.addEventListener(MouseEvent.CLICK, continuePressed);
			back_btn.addEventListener(MouseEvent.CLICK, backPressed);
			search_btn.addEventListener(MouseEvent.CLICK, searchPressed);
			//sign_btn.addEventListener(MouseEvent.CLICK, signPressed);
			//continue_sign_btn.addEventListener(MouseEvent.CLICK, continueSignIn);
		}
		
		function continuePressed(e:MouseEvent)
		{
			play();
		}
		
		function backPressed(e:MouseEvent)
		{
			showThumbnails();
			gotoAndStop(20);
		}
		
		function searchPressed(e:MouseEvent)
		{
			var proxy:FlickrProxy = new FlickrProxy();
			proxy.photoSearch(search_txt.text, completeHandler2);
			/* var flickrURL:String = 'http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=dc140afe3fd3a251c2fdf9dcd835be5c&text="'+search_txt.text+'"&extras=owner_name%2Curl_sq%2Curl_n&per_page=10&format=rest';
			var signature = signRequest(flickrURL);
			var signedURL:String = flickrURL + '&api_sig=' + signature;
			trace(signedURL);
			var request:URLRequest = new URLRequest(signedURL);
			//'http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=dc140afe3fd3a251c2fdf9dcd835be5c&text="'+search_txt.text+'"&extras=owner_name%2Curl_sq%2Curl_n&per_page=10&format=rest'
			
			var loader:URLLoader = new URLLoader();
			loader.addEventListener(Event.COMPLETE,completeHandler);
			loader.load(request); */
		} 
		
		public function hideThumbnails()
		{
			for (var i:int = 0; i < thumbnails.length; i++)
			{
				thumbnails[i].visible = false;
			}
		}
		
		public function showThumbnails()
		{
			for (var i:int = 0; i < thumbnails.length; i++)
			{
				thumbnails[i].visible = true;
			}
		}
		
		public function completeHandler2(photos:Array)
		{
			for (var o:int = 0; o < thumbnails.length; o++)
			{
				removeChild(thumbnails[o]);
			}

			for (var i:int = 0; i < 10; i++)
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
				
				thumbnails[i] = th;
				addChild(th);
			}
			/* var loader:URLLoader = URLLoader(e.target);
			var data:XML = XML(loader.data);
			trace(data);
			
			for (var o:int = 0; o < thumbnails.length; o++)
			{
				removeChild(thumbnails[o]);
			}
			
			for (var i:int = 0; i < 10; i++)
			{	
				var photoId = data.photos.photo[i].@id;
				var ownerId = data.photos.photo[i].@owner;
				var ownerName = data.photos.photo[i].@ownername;
				var title = data.photos.photo[i].@title;
				var thumbnailURL = data.photos.photo[i].@url_sq;
				var largeURL = data.photos.photo[i].@url_n;
				
				var th:Thumbnail = new Thumbnail(photoId,ownerId,ownerName,title,
										thumbnailURL,largeURL);
				
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
				
				thumbnails[i] = th;
				
				addChild(th);
			} */
		}
		
		/* public function signRequest(url:String):String
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
			trace(sortedVariables);	
			var stringToSign = sortedVariables.join("")
			
			var secret:String = "faf000ccf1b60ffa";
			stringToSign = secret + stringToSign;
			var signature:String = MD5.hash(stringToSign);
			return signature;
		} */
		
		/* function signPressed(e:MouseEvent)
		{
			var url:String = 'http://api.flickr.com/services/rest/?method=flickr.auth.getFrob&api_key=dc140afe3fd3a251c2fdf9dcd835be5c';
			var signature = signRequest(url);
			var signedURL = url + '&api_sig=' + signature;
			trace(signedURL);
			var request:URLRequest = new URLRequest(signedURL);
			var loader:URLLoader = new URLLoader();
			loader.addEventListener(Event.COMPLETE,completeSignHandler);
			loader.load(request);
		}
		
		public function completeSignHandler(e:Event)
		{
			var loader:URLLoader = URLLoader(e.target);
			var data:XML = XML(loader.data);
			trace(data);
			frob = data.frob;
			var url:String = 'http://api.flickr.com/services/auth/?api_key=dc140afe3fd3a251c2fdf9dcd835be5c&perms=write&frob='+ frob;
			var signature = signRequest(url);
			var signedURL = url + '&api_sig=' + signature;
			trace(signedURL);
			navigateToURL(new URLRequest(signedURL));
			
			gotoAndStop(30);
		}
		
		public function continueSignIn(e:MouseEvent)
		{
			var url:String = 'http://api.flickr.com/services/rest/?method=flickr.auth.getToken&api_key=dc140afe3fd3a251c2fdf9dcd835be5c&frob=' + frob;
			trace(url);
			var signature = signRequest(url);
			var signedURL = url + '&api_sig=' + signature;
			var request:URLRequest = new URLRequest(signedURL);
			var loader:URLLoader = new URLLoader();
			loader.addEventListener(Event.COMPLETE, getAuthToken);
			loader.load(request);
		}
		
		public function getAuthToken(e:Event)
		{
			var loader:URLLoader = URLLoader(e.target);
			var data:XML = XML(loader.data);
			trace(data);
			authToken = data.auth.token;
			userID = data.auth.user.@nsid;
			userName = data.auth.user.@username;
			trace(authToken);
			trace(userID);
			trace(userName);
			
			var url:String = 'http://api.flickr.com/services/rest/?method=flickr.people.getInfo&api_key=dc140afe3fd3a251c2fdf9dcd835be5c&user_id='+ userID +'&format=rest'
			var signature = signRequest(url);
			var signedURL = url + '&api_sig=' + signature;
			var request:URLRequest = new URLRequest(signedURL);
			var loader2:URLLoader = new URLLoader();
			loader2.addEventListener(Event.COMPLETE, getInfoLoader);
			loader2.load(request);
			
			gotoAndStop(20);
		} */
		
		function getInfoLoader(e:Event)
		{
			var loader:URLLoader = URLLoader(e.target);
			var data:XML = XML(loader.data);
			trace(data);
		}
	}
}






