public class Ecs
{
    private int lastEntityId;
    private HashSet<int> entities;
    private Dictionary<Type, ComponentManager> componentManagers;

    public Ecs(int maxEntities, int maxQueries)
    {
        entities = new();
        componentManagers = new();
    }

    public int CreateEntity()
    {
        entities.Add(lastEntityId);
        return lastEntityId++;
    }

    public void DestroyEntity(int entityId)
    {
        if (!entities.Contains(entityId)) return;

        entities.Remove(entityId);

        foreach (var pair in componentManagers)
        {
            pair.Value.RemoveComponent(entityId);
        }
    }

    public void AddComponent(int entityId, IComponent component)
    {
        if (!entities.Contains(entityId)) return;

        Type componentType = component.GetType();

        if (!componentManagers.ContainsKey(componentType))
        {
            componentManagers.Add(componentType, new ComponentManager(componentType));
        }

        componentManagers[componentType].AddComponent(entityId, component);
    }

    public void RemoveComponent(int entityId, Type componentType)
    {
        if (!entities.Contains(entityId)) return;
        if (!componentManagers.ContainsKey(componentType)) return;

        componentManagers[componentType].RemoveComponent(entityId);
    }

    public bool HasComponent(int entityId, Type componentType)
    {
        if (!entities.Contains(entityId)) return false;
        if (!componentManagers.ContainsKey(componentType)) return false;

        return componentManagers[componentType].HasComponent(entityId);
    }

    public IComponent? GetComponent(int entityId, Type componentType)
    {
        if (!entities.Contains(entityId)) return null;
        if (!componentManagers.ContainsKey(componentType)) return null;

        return componentManagers[componentType].GetComponent(entityId);
    }

    public bool HasComponents(int entityId, params Type[] componentTypes)
    {
        if (!entities.Contains(entityId)) return false;

        foreach (Type type in componentTypes)
        {
            if (!HasComponent(entityId, type)) return false;
        }

        return true;
    }

    public List<int> Query(params Type[] componentTypes)
    {
        List<int> matchingEntities = new List<int>();

        foreach (int id in entities)
        {
            if (HasComponents(id, componentTypes)) matchingEntities.Add(id);
        }

        return matchingEntities;
    }
}
