namespace Forecast.Domain.Emuns
{
    public enum StatusBarState
    {
        /// <summary>
        /// Everything is complete
        /// </summary>
        Complete = 0,

        /// <summary>
        /// Processing something
        /// </summary>
        Waiting = 1,

        /// <summary>
        /// Something went wrong
        /// </summary>
        Error = 2,
    }
}
