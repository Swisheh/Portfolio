package  {
	
	import flash.display.MovieClip;
	import flash.events.*;
	
	
	public class VCOBrowser extends MovieClip {
		private var current; 
		
		public function VCOBrowser() {
			stop();
			var introPage:IntroPage = new IntroPage();
			current = introPage;
			addChild(current);
			
			
			current.facebookLoginBtn.addEventListener(MouseEvent.CLICK, gotoFacebookLogin);
			current.browseBtn.addEventListener(MouseEvent.CLICK, gotoBrowsePage);
			current.top5Btn.addEventListener(MouseEvent.CLICK, gotoTop5Page);
		}
		
		public function gotoFacebookLogin(e:MouseEvent){
			removeChild(current);
			current = new FacebookLogin();
			current.backBtn.addEventListener(MouseEvent.CLICK, gotoIntroPage);
			addChild(current);		
		}
		
		public function gotoIntroPage(e:MouseEvent){
			removeChild(current);
			current = new IntroPage();
			addChild(current);
			current.facebookLoginBtn.addEventListener(MouseEvent.CLICK, gotoFacebookLogin);
			current.browseBtn.addEventListener(MouseEvent.CLICK, gotoBrowsePage);
			current.top5Btn.addEventListener(MouseEvent.CLICK, gotoTop5Page);
		}
		
		public function gotoBrowsePage(e:MouseEvent){
			removeChild(current);
			current = new BrowsePage();
			addChild(current);
			current.backBtn.addEventListener(MouseEvent.CLICK, gotoIntroPage);
			current.facebookLoginBtn.addEventListener(MouseEvent.CLICK, gotoFacebookLogin);
		}
		
		public function gotoTop5Page(e:MouseEvent){
			removeChild(current);
			current = new Top5Page();
			addChild(current);
			current.backBtn.addEventListener(MouseEvent.CLICK, gotoIntroPage);
			current.facebookLoginBtn.addEventListener(MouseEvent.CLICK, gotoFacebookLogin);
		}
	}
	
}
