package
{
	public class Photo
	{
		public var photoId:String;
		public var ownerId:String;
		public var ownerName:String;
		public var title:String;
		public var thumbnailURL:String;
		public var largeURL:String;
		
		public function Photo(photoId, ownerId, ownerName, title, thumbnailURL, largeURL)
		{
			this.photoId = photoId;
			this.ownerId = ownerId;
			this.ownerName = ownerName;
			this.title = title;
			this.thumbnailURL = thumbnailURL;
			this.largeURL = largeURL;
		}
	}
}