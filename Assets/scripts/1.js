#pragma strict

function Start () {}
function Update () {}
var height = 5;
var speed = 1.2;
private var originalPosition : Vector3;
function FixedUpdate ()
{
   var platmove =(Time.time * speed ) * height ;

transform.position = originalPosition + Vector3(0,3,platmove);
}