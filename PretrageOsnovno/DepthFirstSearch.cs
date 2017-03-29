using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PretrageOsnovno
{
    class DepthFirstSearch
    {
        public State search(State pocetno)
        {
            List<State> stanjaZaObradu = new List<State>();
            Hashtable obradjeno = new Hashtable();

            //TODO 6: Implementirati Prvi u dubinu
            List<State> front = new List<State>();
            front.Add(pocetno);
            while(front.Count != 0){
                State current = front[0];
                obradjeno.Add(current.GetHashCode(),current.node);
                front.RemoveAt(0);
                if(current.isFinalState()){
                    return current;
                }
                if (obradjeno.ContainsKey(current.node)) continue;
                foreach (State i in current.children())
                {
                    front.Insert(0,i);
                }
            }
            return null;
        }
    }
}
