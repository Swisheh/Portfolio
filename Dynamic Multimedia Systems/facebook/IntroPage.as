package  {
	
	import flash.display.MovieClip;
	import flash.text.TextField;
	import flash.text.TextFormat;
	
	
	public class IntroPage extends MovieClip {
		var fProxy:FacebookProxy = new FacebookProxy();
		
		public function IntroPage() {
			fProxy.GetAbout(completeHandler);
		}
		
		function completeHandler(aboutString:String){
			var aboutTextField:TextField = new TextField();
			aboutTextField.type = "dynamic";
			aboutTextField.text = aboutString;
			aboutTextField.y = 200;
			aboutTextField.x = 146;
			aboutTextField.width = 248;
			aboutTextField.height = 200;
			aboutTextField.wordWrap = true;
			aboutTextField.embedFonts = true;
			var myFont:GilSans = new GilSans();
			var myFmt:TextFormat = new TextFormat();
			myFmt.font = myFont.fontName;
			myFmt.color = 0xCCCCCC;
			myFmt.bold = true;
			myFmt.size = 20;
			myFmt.align = "center";
			aboutTextField.setTextFormat(myFmt);
			addChild(aboutTextField);
		}
	}
	
}
