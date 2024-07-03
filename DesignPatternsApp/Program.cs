using DesignPatternsApp.CreationalPatterns;
using DesignPatternsApp.StructuralPatterns;

Console.WriteLine("Common Design Patterns in C#:\n");

#region Creational Patterns
Console.WriteLine("---- CREATIONAL PATTERNS ----\n");

// 1. Cách sử dụng Singleton
Console.WriteLine("1/ Singleton Pattern:");
Console.WriteLine(Singleton.Instance);
Console.Write("\n");

// 2. Cách sử dụng Factory Method
Console.WriteLine("2/ Factory Method Pattern:");
IAnimal? animal = FactoryMethod.CreateAnimal(AnimalType.Dog);
Console.WriteLine(animal?.GetName());
Console.Write("\n");

// 3. Cách sử dụng Abstract Factory
Console.WriteLine("3/ Abstract Factory Pattern:");
LoaiNacFactory loaiNac = new();
Client nacClient = new(loaiNac);
LoaiGioFactory loaiGio = new();
Client gioClient = new(loaiGio);
Console.WriteLine("********* HU TIEU **********");
Console.WriteLine(nacClient.GetHuTieuDetails());
Console.WriteLine(gioClient.GetHuTieuDetails());

Console.WriteLine("******* MY **********");
Console.WriteLine(nacClient.GetMyDetails());
Console.WriteLine(gioClient.GetMyDetails());
Console.Write("\n");

// 4. Cách sử dụng Builder
Console.WriteLine("4/ Builder Pattern:");
Director director = new();
ConcreteBuilder builder = new();
director.Builder = builder;

Console.WriteLine("Standard basic product:");
director.BuildMinimalViableProduct();
Console.WriteLine(builder.GetProduct().ListParts());

Console.WriteLine("Standard full featured product:");
director.BuildFullFeaturedProduct();
Console.WriteLine(builder.GetProduct().ListParts());

Console.WriteLine("Custom product:");
builder.BuildPartA();
builder.BuildPartC();
Console.Write(builder.GetProduct().ListParts());
Console.Write("\n");
#endregion

#region Structural Patterns
Console.WriteLine("---- STRUCTURAL PATTERNS ----\n");

// 1. Cách sử dụng Adapter
Console.WriteLine("1/ Builder Pattern:");
List<IShape> shapes =
[
	new RectangleAdapter(new LegacyRectangle()),
	new LineAdapter(new LegacyLine()),
];
int x1 = 5, y1 = 10, x2 = -3, y2 = 2;
shapes.ForEach(shape => shape.Draw(x1, y1, x2, y2));
Console.Write("\n");

// 2. Cách sử dụng Bridge
Console.WriteLine("2/ Bridge Pattern:");
Yellow yellow = new();
White white = new();
Square yellowSquare = new() { Color = yellow };
Square whiteSquare = new() { Color = white };
Circle yellowCircle = new() { Color = yellow };
Circle whiteCircle = new() { Color = white };
Console.WriteLine("Hinh vuong mau vang co mau: " + yellowSquare.GetColor());
Console.WriteLine("Hinh vuong mau trang co mau: " + whiteSquare.GetColor());
Console.WriteLine("Hinh tron mau vang co mau: " + yellowCircle.GetColor());
Console.WriteLine("Hinh tron mau trang co mau: " + whiteCircle.GetColor());
Console.Write("\n");

// 3. Cách sử dụng Composite
Console.WriteLine("3/ Composite Pattern:");
SingleGift iPhone = new("IPhone", 20000);
iPhone.CalculateTotalPrice();

// Composite gift
CompositeGift rootBox = new("RootBox", 0);
SingleGift truckToy = new("TruckToy", 289);
SingleGift plainToy = new("PlainToy", 587);
rootBox.Add(truckToy);
rootBox.Add(plainToy);
CompositeGift childBox = new("ChildBox", 0);
SingleGift soldierToy = new("SoldierToy", 200);
childBox.Add(soldierToy);
rootBox.Add(childBox);
Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");

// 4. Cách sử dụng Composite


#endregion

Console.ReadKey();
