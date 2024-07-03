namespace DesignPatternsApp.CreationalPatterns
{
	/// <summary>
	/// Singleton Pattern
	/// <para>
	/// Đảm bảo một class chỉ có duy nhất một instance được khởi tạo
	/// và nó cung cấp phương thức truy cập đến instance đó từ mọi nơi.
	/// </para>
	/// </summary>
	public sealed class Singleton
	{
		private Singleton() { }
		private static Singleton? instance = null;
		public static Singleton Instance
		{
			get
			{
				instance ??= new Singleton();
				return instance;
			}
		}
	}
}
