namespace DesignPatternsApp.StructuralPatterns
{
	/// <summary>
	/// Tách tính trừu tượng (abstraction) ra khỏi tính hiện thực (implementation)
	/// của nó. Từ đó có thể dễ dàng chỉnh sửa hoặc thay thế mà không làm
	/// ảnh hưởng đến những nơi có sử dụng lớp ban đầu.
	/// </summary>
	public interface IColor
	{
		public string GetColor();
	}

	public class Yellow : IColor
	{
		public string GetColor() => "Yellow";
	}

	public class White : IColor
	{
		public string GetColor() => "White";
	}

	public abstract class Shape
	{
		public IColor? Color { get; set; }

		public string GetColor()
		{
			return Color?.GetColor() ?? string.Empty;
		}
	}

	public class Square : Shape;
	public class Circle : Shape;
}
