using UnityEngine;
  
public class GUIname : MonoBehaviour
{
     // использовать ли рейкастинг для отображения имени только если объект не закрыт другим объектом
     // будет работать если на объекте есть коллайдер
     public bool useRayCast;
     // размер объекта (используется в условии по рейкастингу)
     public float objectSize = 2;
  
     // вспомогательные переменные
     private bool _showName;
     private Vector2 _position;
	
	public float MaxHealth; // общее количество жизней
	public float CurHealth;// Текущее количество
	private float HealthBarLen;	// Для вывода на экран
	public GUISkin mySkin;	// Скин
  
     public void Awake()
     {
        MaxHealth = 100;
		CurHealth = 100;
     }
  
	public void Update()
     {
				HealthBarLen = CurHealth / MaxHealth;
				_showName = false;
				// позиция относительно камеры
				Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint (transform.position);
				// если z>0, то точка находится перед камерой
				if (cameraRelative.z > 0) {
						// если используем рейкастинг
			if (useRayCast) {
								RaycastHit hit;
				
								// направление луча
								Vector3 direction = transform.position - Camera.main.transform.position;
				
								// сам луч
								Ray ray = new Ray (Camera.main.transform.position, direction);
				
								// посылаем луч
								if (Physics.Raycast (ray, out hit)) {
										// если дистанция до цели удовлетворяет условиям, то отображаем имя
										if (hit.distance >= (direction.magnitude - objectSize)) {
												Vector3 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
												_position = new Vector2 (screenPosition.x - 26f, Screen.height - screenPosition.y - 100f);
												_showName = true;     
										}
								}
						} else {
								// случай без рейкастинга
								Vector3 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
								_position = new Vector2 (screenPosition.x - 26f, Screen.height - screenPosition.y - 100f);
								_showName = true;                
						}
			
				}
		}

     public void OnGUI()
     {
         // если следует отобразить бар
         if (_showName)
         {
			GUI.skin = mySkin;
             // считаем позицию
             Rect rect = new Rect(_position.x, _position.y, 60f, 15f);
  
            GUI.Box(new Rect(_position.x, _position.y, 60f*HealthBarLen, 15f), " ", GUI.skin.GetStyle("fon")); 
			GUI.Box(rect, " ", GUI.skin.GetStyle("Bar"));
         }
		//networkView.RPC ("GUI_func", RPCMode.All);
     }
}