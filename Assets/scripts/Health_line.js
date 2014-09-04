var UnderHeight = 0.7;
var HealthIsActive = true;
var HealthIndicator: GameObject;

function Update ()
{
	if (HealthIsActive)
	{
		Health();
	}
}

function Health ()
{
	var Camera = GameObject.Find("Main Camera");
	
	HealthIndicator.transform.localEulerAngles.x = Camera.transform.localEulerAngles.x;
	HealthIndicator.transform.localEulerAngles.y = Camera.transform.localEulerAngles.y;
	HealthIndicator.transform.localEulerAngles.z = Camera.transform.localEulerAngles.z;
}