namespace WindRose.CoreCombat.EnemyBase.Goblin
{
    [UnityEngine.CreateAssetMenu(fileName = "GoblinVersion", menuName = "ScriptableObject/Inimigo/Goblin", order = 1)]
    public class GoblinValues : UnityEngine.ScriptableObject
    {
        public int Vida;
        public int AreadeAtaque;
        public int Velocidade;
        public int Velocidade_De_Ataque;
    }
}