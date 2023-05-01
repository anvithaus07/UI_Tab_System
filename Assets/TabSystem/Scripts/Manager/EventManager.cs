

public class EventManager
{
    private static EventManager m_Instance;

    public static EventManager Instance()
    {
        if (m_Instance == null)
            m_Instance = new EventManager();
        return m_Instance;
    }

    public delegate void OnTabViewChangedDel(Tabs tabType);
    public event OnTabViewChangedDel OnTabViewChanged;

    public void OnTabViewChangedEvent(Tabs tabType)
    {
        OnTabViewChanged?.Invoke(tabType);
    }


}
