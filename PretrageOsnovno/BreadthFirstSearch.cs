using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretrageOsnovno
{
    class BreadthFirstSearch
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
                front.RemoveAt(0);
                if(current.node.Equals(Program.endNode)){
                    return current;
                }
                if (obradjeno.ContainsKey(current.node)) continue;
                foreach (State i in current.children())
                {
                    front.Add(i);
                }
            }
            return null;
        
        }
    }
}
