namespace DungeonMaster.CustomExceptions
{
    public class InvalidArmorException : Exception
    {
        //Allows for a custom message to be written when InvalidArmorException exception is thrown.
        public InvalidArmorException(string? message) : base(message) { }
    }
}
