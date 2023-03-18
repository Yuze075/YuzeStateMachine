namespace YuzeToolkit.Framework.StateMachine
{
    public abstract class State<T> : State where T : IStateMachine
    {
        protected State(T stateMachineScript)
        {
            StateMachine = stateMachineScript;
        }
        protected T StateMachine { get; }
    }
}