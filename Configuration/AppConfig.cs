using System;

namespace NetStockAssignment.Configuration
{
    // 1) Make sure appsettings.json & relative environment files are copied to the application root folder during publishing (File propery > Content > Copy if newer/Copy always)
    // 2) Do not store config values directly in the root object, but instead use Options classes
    public class AppConfig
    {
        public DearOptions DearOptions { get; set; }
        public ExtraOptions ExtraOptions { get; set; }
		public CsvOptions CsvOptions { get; set; }
	}

    public class DearOptions
    {
        public bool Enabled { get; set; }
        public Uri Url { get; set; }
		public string AccountID { get; set; }
		public string AppKey { get; set; }
	}

    public class ExtraOptions
    {
        public string ConsoleId { get; set; }
    }
	public class CsvOptions
	{
		public string Directory { get; set; }
	}
}
