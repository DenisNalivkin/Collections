using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{

   public class PairKeyAndValue  <T,V>
    {
        public T Key { get; set; }
        public V Value { get; set; }
        public PairKeyAndValue( T Key, V Value)
        {
            this.Key = Key;
            this.Value = Value;        
        }

        public PairKeyAndValue ()
        {
            
        }

        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }
}
