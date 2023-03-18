using System.Collections.Generic;
using System;

namespace YuzeToolkit.Framework.StateMachine
{
    /// <summary>
    /// 状态机的抽象积累
    /// </summary>
    public abstract class StateMachine
    {
        /// <summary>
        /// 储存不同的状态
        /// </summary>
        protected Dictionary<Type, State> States { get; } = new();
        /// <summary>
        /// 当前状态
        /// </summary>
        protected State CurrentState { get; set; }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <typeparam name="T">继承自<see cref="State"/>的类型，并且存在空构造函数<code>new()</code></typeparam>
        public void AddNode<T>() where T : State, new()
        {
            AddNode(new T());
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="state">一个实例化完成的状态</param>
        public void AddNode(State state)
        {
            var type = state.GetType();
            if (States.ContainsKey(type))
            {
                Logger.Warning($"[StateMachine.ChangeState]: {type} already in StateMachine");
                return;
            }

            state.OnAddToStateMachine(this);
            States.Add(type, state);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <typeparam name="T">继承自<see cref="State"/>的类型</typeparam>
        public void ChangeState<T>() where T : State
        {
            var type = typeof(T);
            if (!States.ContainsKey(type))
            {
                Logger.Warning($"[StateMachine.ChangeState]: {type} is not in StateMachine");
                return;
            }

            var beforeState = CurrentState;
            var afterState = States[type];
            beforeState.OnEnter(afterState);
            afterState.OnEnter(beforeState);
            CurrentState = afterState;
        }
    }
}