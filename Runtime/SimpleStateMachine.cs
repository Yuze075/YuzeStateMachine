namespace YuzeToolkit.Framework.StateMachine
{
    public class SimpleStateMachine :StateMachine
    {
        private bool _isRunning;
        public void Update()
        {
            if (CurrentState == null) return;
            CurrentState.OnUpdate();
            CurrentState.OnCheckChange();
        }

        public void Run<T>() where T : State
        {
            if (_isRunning) return;
            var type = typeof(T);
            if (!States.ContainsKey(type))
            {
                Logger.Warning($"[StateMachine.Run]: {type} is not in StateMachine");
                return;
            }

            CurrentState = States[type];
            CurrentState.OnEnter(null);
            _isRunning = true;
        }

        public void End()
        {
            CurrentState.OnExit(null);
            CurrentState = null;
            _isRunning = false;
        }
    }
}