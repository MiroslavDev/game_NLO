using UnityEngine;

using System.Collections;



//Здесь мы объявляем необходимые компоненты, без которых

//данный модуль работать не будет

[RequireComponent(typeof(Animation))]

[RequireComponent(typeof(CapsuleCollider))]

[RequireComponent(typeof(NavMeshAgent))]



public class BotMovement : MonoBehaviour {
	
	
	
	//максимальная дистанция, на которую можно приблизиться к боту
	
	public float MaxDistance = 3.0f;
	
	//скорость разворота бота
	
	public float RotationSpeed = 5;
	
	
	
	//анимация покоя. объявлена как public, значит назначать ее будем
	
	//в окне Inspector. там появится свойство animIdle.
	
//	public AnimationClip animIdle;
	
	//скорость анимации покоя.
	
	public float animIdleSpeed = 1;
	
	
	
	//соответственно, анимация бега
	
	//public AnimationClip animRun;
	
//	public float animRunSpeed = 1;
	
	
	
	//анимации выстрела и смерти
	
	//public AnimationClip animShut;
	
	//public AnimationClip animDeath;
	
	
	
	//цель нападения. В эту переменную потом попадет
	
	//наш FirstPersonController
	
public Transform target;
	
	
	
	//а в эту переменную попадет кость скелета,
	
	//которая является родительской для всей верхней части бота
	
	public Transform _tors;
	
	
	
	//в следующей переменной будет храниться NavMeshAgent
	
	private NavMeshAgent _navMeshAgent;
	
	
	
	
	
	//признак агрессии. Далее мы будем проверять эту переменную, и если она
	
	//равна true – начинать преследование.
	
	private bool Agression;
	
	
	
	//признак смерти. Если переменная будет true – значит бот умер
	
	private bool deaded = false;
	
	
	
	//здесь будет храниться ссылка на наш коллайдер. Ссылка нужна
	
	//для того, чтобы мы могли уничтожить коллайдер после
	
	//смерти бота
	
	private CapsuleCollider cc;
	
	
	
	void Start () {
		
		
		
		//находим NavMeshAgent
		
		_navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		
		
		
		//находим CapsuleCollider
		
		cc = gameObject.GetComponent<CapsuleCollider>();
		
		
		
		//цель пока нулевая
		
		target = null;
		
		
		
		//инициализируем анимации
		
	//	animation.wrapMode = WrapMode.Loop;
		
		
		
		
		
	//	animation[animShut.name].layer = 1;

	//	animation[animShut.name].wrapMode = WrapMode.Once;

		
		
	//	animation[animDeath.name].layer = 2;

//		animation[animDeath.name].wrapMode = WrapMode.Once;
		
		
		
		
		
	//	animation.Stop();
		
	//	animation[animIdle.name].speed = animIdleSpeed;
		
	//	animation[animRun.name].speed = animRunSpeed;
		
		
		
	//	animation.CrossFade(animIdle.name);
		
	}
	
	
	
	
	
	void Update () {
		
		//проверям, не умер ли бот
		
		if (!deaded)
			
		{
			
			//проверяем наличие цели
			
			if (target != null)
				
			{
				
				//вычисляем дистанцию до цели
				
				float _distance = Vector3.Distance(target.position, transform.position);
				
				
				
				//если дистанция больше максимально допустимой - бежим
				
				if (_distance >= MaxDistance)
					
				{
					
					//этот условный оператор на будущее,
					
					//если мы добавим анимацию ходьбы.
					
					//пока он ни на что не влияет.
					
					if (Agression)
						
					{
						
						Run();
						
					}
					
					else
						
					{
						
						Run();
						
					}
					
					
					
				}
				
				else
					
				{
					
					//подошли слишком близко, останавливаемся.
					
					Stop();
					
				}
				
				
				
			}
			
			else
				
			{
				
				//цель нулевая, останавливаемся
				
				Stop();
				
			}
			
		}
		
	}
	
	
	
	//эта функция будет вызываться извне,
	
	//тут мы устанавливаем цель
	
	public void SetTarget(Transform _target, bool agression)
		
	{
		
		Agression = agression;
		
		target = _target;
		
		
		
	}
	
	
	
	
	
	//функция бега. Запускаем анимацию бега,
	
	//и говорим нашему navMeshAgent двигаться к цели
	
	private void Run()
		
	{
		
	//	animation.CrossFade(animRun.name);
		
		_navMeshAgent.SetDestination(target.position);
		
	}
	
	
	
	//функция остановки
	
	private void Stop()
		
	{
		
//		animation.CrossFade(animIdle.name);
		
		_navMeshAgent.Stop();
		
	}
	
	
	
	
	
	//атака. Запускаем анимацию стрельбы.
	
	//обратите внимание, что анимация действует только начиная
	
	//с кости _tors, тем самым мы обеспечиваем плавную анимацию
	
	//стрельбы хоть на бегу, хоть из состояния покоя
	
	void Attack()
		
	{
		
	//	animation[animShut.name].AddMixingTransform(_tors);
		
	//	animation.CrossFade(animShut.name);
		
	}
	
	
	
	
	
	//смерть бота. Уничтожаем коллайдер, устанавливаем deaded в true
	
	//и запускаем анимацию смерти, предварительно остановив все анимации
	
	void Death()
		
	{
		
		cc.enabled = false;
		
		_navMeshAgent.Stop();
		
		deaded = true;
		
	//	animation.Stop();
		
	//	animation.Play(animDeath.name);
		
	}
	
	
	
}