using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<AbstractUIMenuBase> _menus = new List<AbstractUIMenuBase>();

    private void Awake()
    {
        // if needed 
        foreach (var menu in _menus)
        {
            menu.InitMenu();
        }
    }

    private void OnEnable()
    {
        EventsObserver.AddEventListener<StopTimeEvent>(StopTimeListener);
        EventsObserver.AddEventListener<PlayerDeathEvent>(EndGame);
    }
    
    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<StopTimeEvent>(StopTimeListener);
        EventsObserver.RemoveEventListener<PlayerDeathEvent>(EndGame);
    }
    
    private void StopTimeListener(StopTimeEvent e)
    {
        if (!e.IsTimeStopped)
        {
            SetActiveMenu(1);
        }
    }
    
    private void EndGame(PlayerDeathEvent e)
    {
        SetActiveMenu(2);
    }

    private void SetActiveMenu(int activeIndex)
    {
        foreach (var menu in _menus)
        {
            menu.gameObject.SetActive(false);
        }
        
        _menus[activeIndex].gameObject.SetActive(true);
    }
    
}
