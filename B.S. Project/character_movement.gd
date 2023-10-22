extends CharacterBody2D

var movement_speed = 40.0
@onready var anim = get_node("AnimatedSprite2D")

func _ready():
	anim.play("Idle")

func _physics_process(delta):
	movement()


func movement():
	var x_mov = Input.get_action_strength("ui_right") - Input.get_action_strength("ui_left")
	var y_mov = Input.get_action_strength("ui_down") - Input.get_action_strength("ui_up")
	
	var result_mov = Vector2(x_mov, y_mov)
	velocity = result_mov.normalized()*movement_speed 
	move_and_slide()
