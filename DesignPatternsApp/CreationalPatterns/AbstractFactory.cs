namespace DesignPatternsApp.CreationalPatterns
{
	/// <summary>
	/// Abstract Factory
	/// <para>
	/// Cung cấp một interface cho việc khởi tạo các tập hợp
	/// của những object có đặc điểm giống nhau mà không cần quan tâm object đó là gì
	/// </para>
	/// </summary>
	public interface IMonAnFactory
	{
		public IHuTieu LayToHuTieu();
		public IMy LayToMy();
	}

	public interface IHuTieu
	{
		public string GetModelDetails();
	}

	public interface IMy
	{
		public string GetModelDetails();
	}

	public class Client(IMonAnFactory foodFactory)
	{
		private readonly IHuTieu huTieu = foodFactory.LayToHuTieu();
		private readonly IMy my = foodFactory.LayToMy();

		public string? GetHuTieuDetails()
		{
			return huTieu?.GetModelDetails();
		}

		public string? GetMyDetails()
		{
			return my?.GetModelDetails();
		}
	}

	public class LoaiGioFactory : IMonAnFactory
	{
		public IHuTieu LayToHuTieu()
		{
			return new HuTieuGio();
		}

		public IMy LayToMy()
		{
			return new MyGio();
		}
	}

	public class LoaiNacFactory : IMonAnFactory
	{
		public IHuTieu LayToHuTieu()
		{
			return new HuTieuNac();
		}

		public IMy LayToMy()
		{
			return new MyNac();
		}
	}

	public class HuTieuGio : IHuTieu
	{
		public string GetModelDetails() => "Hu tieu gio cua em day.";
	}

	public class HuTieuNac : IHuTieu
	{
		public string GetModelDetails() => "Hu tieu nac cua em day.";
	}

	public class MyGio : IMy
	{
		public string GetModelDetails() => "My gio cua em day.";
	}

	public class MyNac : IMy
	{
		public string GetModelDetails() => "My nac cua em day.";
	}
}
