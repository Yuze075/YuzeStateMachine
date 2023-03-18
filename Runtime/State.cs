namespace YuzeToolkit.Framework.StateMachine
{
    public abstract class State
    {
        private IStateMachine StateMachine { get; set; }

        /// <summary>
        /// 用于切换同一状态机中不同的变量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected void ChangeState<T>() where T : State
        {
            StateMachine.ChangeState<T>();
        }

        /// <summary>
        /// 当添加到状态机中调用，获取<see cref="IStateMachine"/>
        /// </summary>
        /// <param name="stateMachine"></param>
        internal void OnAddToStateMachine(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        /// <summary>
        /// 进入状态调用的函数
        /// </summary>
        /// <param name="beforeState">前一个状态</param>
        public virtual void OnEnter(State beforeState)
        {
        }

        /// <summary>
        /// 状态更新函数
        /// </summary>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        /// 状态检查函数，应该在状态更新函数之后调用
        /// 将更新更新和状态切换分离，方便维护
        /// </summary>
        public virtual void OnCheckChange()
        {
        }

        /// <summary>
        /// 退出状态调用的函数
        /// </summary>
        /// <param name="afterState">后一个状态</param>
        public virtual void OnExit(State afterState)
        {
        }
    }
}