namespace GrozaGames.Kit.Signals
{
    public delegate void SignalReceivedDelegate<in TSignal>(TSignal signal);
}