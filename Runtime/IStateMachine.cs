using System;
using System.Collections.Generic;

namespace YuzeToolkit.Framework.StateMachine
{
    /// <summary>
    /// 状态机接口
    /// </summary>
    public interface IStateMachine
    {
        /// <summary>
        /// 储存不同的状态
        /// </summary>
        public Dictionary<Type, State> States { get; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public State CurrentState { get; set; }
    }
}