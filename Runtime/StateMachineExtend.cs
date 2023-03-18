namespace YuzeToolkit.Framework.StateMachine
{
    public static class StateMachineExtend
    {
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <typeparam name="T">继承自<see cref="State"/>的类型，并且存在空构造函数<code>new()</code></typeparam>
        public static void AddNode<T>(this IStateMachine stateMachine) where T : State, new()
        {
            AddNode(stateMachine, new T());
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <param name="state">一个实例化完成的状态</param>
        public static void AddNode(this IStateMachine stateMachine, State state)
        {
            var type = state.GetType();
            if (stateMachine.States.ContainsKey(type))
            {
                Logger.Warning($"[StateMachine.ChangeState]: {type} already in StateMachine");
                return;
            }

            state.OnAddToStateMachine(stateMachine);
            stateMachine.States.Add(type, state);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <typeparam name="T">继承自<see cref="State"/>的类型</typeparam>
        public static void ChangeState<T>(this IStateMachine stateMachine) where T : State
        {
            var type = typeof(T);
            if (!stateMachine.States.ContainsKey(type))
            {
                Logger.Warning($"[StateMachine.ChangeState]: {type} is not in StateMachine");
                return;
            }

            var beforeState = stateMachine.CurrentState;
            var afterState = stateMachine.States[type];
            beforeState.OnEnter(afterState);
            afterState.OnEnter(beforeState);
            stateMachine.CurrentState = afterState;
        }
    }
}