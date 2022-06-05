public class ComponentManager
{
    private Dictionary<int, IComponent?> components;
    private Type type;

    public ComponentManager(Type type)
    {
        this.type = type;
        components = new();
    }

    public void AddComponent(int entityId, IComponent component)
    {
        if (components.ContainsKey(entityId)) return;
        if (component.GetType() != type) throw new ArgumentException($"Component type {component.GetType()} does not match collection type {type}");

        components.Add(entityId, component);
    }

    public void RemoveComponent(int entityId)
    {
        components.Remove(entityId);
    }

    public bool HasComponent(int entityId)
    {
        return components.ContainsKey(entityId);
    }

    public IComponent? GetComponent(int entityId)
    {
        if (!components.ContainsKey(entityId)) return null;
        return components[entityId];
    }
}
