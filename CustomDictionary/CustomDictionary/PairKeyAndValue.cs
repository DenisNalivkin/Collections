using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
   public class PairKeyAndValue  <T,V>
    {
        public T  key { get; set; }
        public V  value {  get; set; }

        public PairKeyAndValue( T Key, V Value)
        {
            this.key = Key;
            this.value = Value;        
        }

        public PairKeyAndValue ()
        {
            
        }

    }
}
