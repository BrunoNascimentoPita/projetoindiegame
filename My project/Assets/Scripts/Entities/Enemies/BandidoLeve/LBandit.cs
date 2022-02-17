public sealed class LBandit : Enemy
{
    private void Start()
    {
        InitComponentsAndVariables(5);
    }
    
    private void Update()
    {
        if(DistanceToTarget < 1.3F) Attack();
        if (OnRange && DistanceToTarget > 2) {
            Move(); 
        }
        if (transform.position.x < PlayerPosition.x) {
            Flip(-1); 
        } else {
            Flip(1); 
        }
    }
    
    private void LateUpdate()
    {
        SearchPlayer();
        if (Life == 0)
        {
            Ani.SetBool("IsDead", true);
        } 
    }
}
