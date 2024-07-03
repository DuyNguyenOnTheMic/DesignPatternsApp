namespace DesignPatternsApp.CreationalPatterns
{
	/// <summary>
	/// Factory Method Pattern
	/// <para>
	/// Khi chúng ta muốn tạo ra một object của một type nào đấy,
	/// nhưng chúng ta không biết rõ mình sẽ phải tạo ra cái gì,
	/// mà nó phải dựa vào một số điều kiện business logic đầu vào để tạo ra object tương ứng
	/// </para> 
	/// </summary>
	public class FactoryMethod
	{
		public static IAnimal? CreateAnimal(AnimalType animalType)
		{
			IAnimal? animal = null;
			switch (animalType)
			{
				case AnimalType.Dog:
					animal = new Dog();
					break;
				case AnimalType.Cat:
					animal = new Cat();
					break;
				case AnimalType.Duck:
					animal = new Duck();
					break;
			}
			return animal;
		}
	}

	public enum AnimalType
	{
		Dog = 1,
		Cat = 2,
		Duck = 3
	}

	public interface IAnimal
	{
		public string GetName();
	}

	public class Dog : IAnimal
	{
		public string GetName() => "Dog";
	}

	public class Cat : IAnimal
	{
		public string GetName() => "Cat";
	}

	public class Duck : IAnimal
	{
		public string GetName() => "Duck";
	}
}
