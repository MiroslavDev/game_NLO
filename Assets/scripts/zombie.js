#pragma strict

private var Oleg  : Transform ;
private var navComponent : NavMeshAgent; 
function Start () {
navComponent = this.transform.GetComponent(NavMeshAgent);

    Oleg = GameObject.Find("Player").transform;
}

function Update () {

var _distance = Vector3.Distance(Oleg.position, Oleg.position);
				
				
				
				//если дистанция больше максимально допустимой - бежим
				

navComponent.SetDestination(Oleg.position);

		
}