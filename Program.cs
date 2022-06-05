Ecs ecs = new Ecs(10, 10);

int playerOne = ecs.CreateEntity();
ecs.AddComponent(playerOne, new PositionComponent());
ecs.AddComponent(playerOne, new RotationComponent());

int playerTwo = ecs.CreateEntity();
ecs.AddComponent(playerTwo, new PositionComponent());

Console.WriteLine($"Player 1 id: {playerOne}");
Console.WriteLine($"Player 2 id: {playerTwo}");
Console.WriteLine($"Player 1 has position: {ecs.HasComponent(playerOne, typeof(PositionComponent))}");
Console.WriteLine($"Player 2 has position: {ecs.HasComponent(playerTwo, typeof(PositionComponent))}");
Console.WriteLine($"Player 1 has rotation: {ecs.HasComponent(playerOne, typeof(RotationComponent))}");
Console.WriteLine($"Player 2 has rotation: {ecs.HasComponent(playerTwo, typeof(RotationComponent))}");
Console.WriteLine($"Player 1 has pos & rot: {ecs.HasComponents(playerOne, typeof(PositionComponent), typeof(RotationComponent))}");
Console.WriteLine($"Player 2 has pos & rot: {ecs.HasComponents(playerTwo, typeof(PositionComponent), typeof(RotationComponent))}");

Console.WriteLine($"Query result for position: {ecs.Query(typeof(PositionComponent)).Count}");
Console.WriteLine($"Query result for pos & rot: {ecs.Query(typeof(PositionComponent), typeof(RotationComponent)).Count}");
