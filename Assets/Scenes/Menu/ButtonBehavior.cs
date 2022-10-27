using Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.Menu
{
    public class ButtonBehavior : MonoBehaviour
    {

        private void Awake()
        {
            EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
            entryPointerEnter.eventID = EventTriggerType.PointerEnter;
            entryPointerEnter.callback.AddListener(_ => { OnPointerEnterDelegate(); });
            trigger.triggers.Add(entryPointerEnter);

            EventTrigger.Entry entryPointerClick = new EventTrigger.Entry();
            entryPointerClick.eventID = EventTriggerType.PointerClick;
            entryPointerClick.callback.AddListener(_ => { OnPointerClickDelegate(); });
            trigger.triggers.Add(entryPointerClick);
        }

        public static void OnPointerEnterDelegate()
        {
            AudioManager.Instance.ButtonHover();
        }

        public static void OnPointerClickDelegate()
        {
            AudioManager.Instance.ButtonClick();
        }
    }
}
