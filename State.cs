using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    //Design pattern: State

    public class StateMachine
    {
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }

    public class State : StateMachine
    {

        private State CurrentState;

        //Designated Constructor
        public State(){}


        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            // CurrentState.Enter();
        }


        public void ChangeState(State newState)
        {
            CurrentState = newState;
        }

        
        public State GetCurrentState
        {
            get
            {
                return CurrentState;
            }
        }
    }
}
