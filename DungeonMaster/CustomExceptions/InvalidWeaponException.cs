namespace DungeonMaster.CustomExceptions
{
    public class InvalidWeaponException : Exception
    {
        //Allows for a custom message to be written when InvalidWeaponException exception is thrown.
        public InvalidWeaponException(string? message) : base(message) { }
    }
}
