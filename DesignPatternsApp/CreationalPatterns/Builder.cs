namespace DesignPatternsApp.CreationalPatterns
{
	/// <summary>
	/// Builder
	/// <para>
	/// Cung cấp một giải pháp linh hoạt cho các vấn đề
	/// tạo đối tượng (object) khác nhau trong lập trình hướng đối tượng.
	/// </para>
	/// <para>
	/// chỉ định các phương phương pháp để tạo các phần khác nhau Product object 
	/// </para>
	/// </summary>
	public interface IBuilder
	{
		public void BuildPartA();
		public void BuildPartB();
		public void BuildPartC();
	}

	/// <summary>
	/// Tuân theo Builder Interface cung cấp các triển khai cụ thể của từng bước
	/// </summary>
	public class ConcreteBuilder : IBuilder
	{
		private Product _product = new();

		public ConcreteBuilder() => Reset();

		public void Reset() => _product = new Product();

		public void BuildPartA() => _product.AddPart("PartA1");

		public void BuildPartB() => _product.AddPart("PartB1");

		public void BuildPartC() => _product.AddPart("PartC1");

		public Product GetProduct()
		{
			Product product = _product;
			Reset();
			return product;
		}
	}

	/// <summary>
	/// Chỉ sử dụng Builder Pattern khi sản phẩm có nhiều loại và trở nên phức tạp và cần có tỉnh mở rộng.
	/// Vì đôi khi Concrete builder khác nhau có thể tạo ra những product khác nhau và không liên quan đến nhau. 
	/// </summary>
	public class Product
	{
		private readonly List<object> _parts = [];

		public void AddPart(string part)
		{
			_parts.Add(part);
		}

		public string ListParts() => string.Join(", ", _parts) + "\n";
	}

	/// <summary>
	/// Chịu trách nhiệm thực hiện các bước build theo một trình tự xác định cụ thể
	/// Class Director là tùy chọn để có Client có thể kiểm soát trực tiếp quá trình.
	/// </summary>
	public class Director
	{
		private IBuilder? _builder;

		public IBuilder Builder
		{
			set => _builder = value;
		}

		public void BuildMinimalViableProduct() => _builder?.BuildPartA();

		public void BuildFullFeaturedProduct()
		{
			_builder?.BuildPartA();
			_builder?.BuildPartB();
			_builder?.BuildPartC();
		}
	}
}
