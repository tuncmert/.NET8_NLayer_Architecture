namespace App.Services.Products;

public record ProductDto(int Id, String Name, decimal Price, int Stock,int CategoryId);

//public record ProductDto
//{
//    public int Id { get; init; }
//    public string Name { get; init; } = default!;
//    public decimal Price { get; init; }
//    public int Stock { get; init; }
//}

