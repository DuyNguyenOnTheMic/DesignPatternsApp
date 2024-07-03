namespace DesignPatternsApp.StructuralPatterns
{
	/// <summary>
	/// Là mẫu thiết kế chuyển đổi khuôn mẫu (interface)
	/// của một lớp thành một khuôn mẫu khác mà phía clients muốn.
	/// Cho phép 2 khuôn mẫu không liên quan làm việc cùng nhau.
	/// </summary>
	public interface IShape
	{
		public void Draw(int x1, int y1, int x2, int y2);
	}

	public class RectangleAdapter(LegacyRectangle legacyRectangle) : IShape
	{
		private readonly LegacyRectangle _legacyRectangle = legacyRectangle;

		public void Draw(int x1, int y1, int x2, int y2)
		{
			int x = Math.Min(x1, x2);
			int y = Math.Min(y1, y2);
			int w = Math.Abs(x2 - x1);
			int h = Math.Abs(y2 - y1);
			LegacyRectangle.Draw(x, y, w, h);
		}
	}

	public class LineAdapter(LegacyLine legacyLine) : IShape
	{
		private readonly LegacyLine _legacyLine = legacyLine;

		public void Draw(int x1, int y1, int x2, int y2)
		{
			LegacyLine.Draw(x1, y1, x2, y2);
		}
	}

	public class LegacyRectangle
	{
		public static void Draw(int x, int y, int w, int h)
		{
			Console.WriteLine($"Drawing rectangle {x} {y} {w} {h}");
		}
	}

	public class LegacyLine
	{
		public static void Draw(int x1, int y1, int x2, int y2)
		{
			Console.WriteLine($"Drawing line {x1} {y1} {x2} {y2}");
		}
	}
}
