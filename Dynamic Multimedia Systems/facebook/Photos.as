package  {
	
	public class Photos {
		public var photoID:String;
		public var photoName:String;
		public var thumbnailURL:String;
		public var largeURL:String;
		public var likes:String;
		
		public function Photos(photoID,photoName,thumbnailURL,largeURL,likes) {
			this.photoID = photoID;
			this.photoName = photoName;
			this.thumbnailURL = thumbnailURL;
			this.largeURL = largeURL;
			this.likes = likes;
		}

	}
	
}
