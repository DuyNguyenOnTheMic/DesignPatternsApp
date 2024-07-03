namespace DesignPatternsApp.StructuralPatterns
{
	/// <summary>
	/// Composite Pattern là một sự tổng hợp những
	/// thành phần có quan hệ với nhau để tạo ra
	/// thành phần lớn hơn. Nó cho phép thực hiện các
	/// tương tác với tất cả đối tượng trong mẫu tương tự nhau.
	/// <para>
	/// VD: 1 hộp đồ chơi chứa nhiều đồ chơi, trong hộp đồ chơi
	/// lại có nhiều hộp con có chứa đồ chơi khác, để quản lý 
	/// các đồ chơi này thì mình dùng Composite Pattern.
	/// </para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="price"></param>
	public abstract class GiftBase(string name, decimal price)
	{
		protected string _name = name;
		protected decimal _price = price;

		public abstract decimal CalculateTotalPrice();
	}

	public interface IGiftOperations
	{
		public void Add(GiftBase giftBase);
		public void Remove(GiftBase giftBase);
	}

	public class CompositeGift(string name, decimal price) : GiftBase(name, price), IGiftOperations
	{
		private readonly List<GiftBase> _gifts = [];

		public void Add(GiftBase giftBase)
		{
			_gifts.Add(giftBase);
		}

		public void Remove(GiftBase giftBase)
		{
			_gifts.Remove(giftBase);
		}

		public override decimal CalculateTotalPrice()
		{
			decimal total = decimal.Zero;
			Console.WriteLine($"{_name} contains the following products with prices:");
			foreach (GiftBase gift in _gifts)
			{
				total += gift.CalculateTotalPrice();
			}
			return total;
		}
	}

	public class SingleGift(string name, decimal price) : GiftBase(name, price)
	{
		public override decimal CalculateTotalPrice()
		{
			Console.WriteLine($"{_name} with the price {_price}");
			return _price;
		}
	}
}
