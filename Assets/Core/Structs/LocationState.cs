namespace Core.Structs
{
    public enum LocationState 
    {
        Unloaded,
        Active,
        Completed
    }
    
    public enum LocationObjectState 
    {
        Destroyed,
        Damaged,
        Common
    }

    public enum CharacterState 
    {
        Idle,
        Dead,
        Patrol,
        Agro
    }
}