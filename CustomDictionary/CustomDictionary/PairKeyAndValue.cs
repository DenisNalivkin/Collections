using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    /// <summary>
    /// Class PairKeyAndValue generic keeps  pairs key-value.
    /// </summary>
    /// <typeparam name="T">This parameter represents the type of Key for key-value pairs. </typeparam>
    /// <typeparam name="V">This parameter represents the type of Value for key-value pairs.</typeparam>
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

        /// <summary>
        /// This method is override  virtual  method ToString.
        /// </summary>
        /// <returns>Return string</returns>
        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }
}
