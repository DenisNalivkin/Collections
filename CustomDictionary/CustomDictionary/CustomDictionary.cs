using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    /// <summary>
    /// Generic class CustomDictionary keeps pairs of key-value.
    /// </summary>
    /// <typeparam name="T">This parameter represents the type of Key.</typeparam>
    /// <typeparam name="V">This parameter represents the type of Value.</typeparam>
    public class CustomDictionary <T,V>: IEnumerable<PairKeyAndValue<T, V>>
    {      
       List<PairKeyAndValue<T,V>> keyValuePairs;
       public int Count { get; private  set; }




      
        public CustomDictionary()
        {
           keyValuePairs = new List<PairKeyAndValue<T, V>>();          
        }

        /// <summary>
        /// Indexator gets the Value by provided Key.
        /// </summary>
        /// <param name="key"> The key of the value to get or set. </param>
        /// <exception>
        /// KeyNotFoundException
        /// </exception>
        /// <returns></returns>
        public V this[T key]
        {
         get
          {        
           foreach (var pair in keyValuePairs)
           {
           if (pair.Key.Equals(key))
           {
             return pair.Value;
           }

           }
            throw new KeyNotFoundException();
           }
             
         set
         {
          bool isKeyExist = false;
          foreach (var pair in keyValuePairs)
          {
             if (pair.Key.Equals(key))
             {
               pair.Value = value;
               isKeyExist = true;
               break;                 
             }
          }
          if (!isKeyExist)
          {
             throw new KeyNotFoundException();
          }                
            }
        }

        /// <summary>
        ///  Adds new pair of key-value.
        /// </summary>
        /// <param name="key"> The key of the element to add. </param>
        /// <param name="value">The value of the element to add. </param>
        public void Add (T key, V value)
        {
            PairKeyAndValue<T,V> keyValuePairToAdd = new PairKeyAndValue<T,V>(key, value);
            keyValuePairs.Add(keyValuePairToAdd);
            Count += 1;       
        }

        /// <summary>
        /// This method searches key in CustomDictionary.
        /// </summary>
        /// <param name="Key">Key to search.</param>
        /// <returns>True if key exists, false otherwise.</returns>
        public bool ContainsKey(T Key)
        {
            bool keyWasFound = false;
            foreach(var pair in keyValuePairs)
            {
                if (pair.Key.Equals(Key))
                {
                    keyWasFound = true;
                    break;                    
                }
            }
            return keyWasFound;            
        }
        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get. </param>
        /// <param name="value">Contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. </param>
        /// <returns>Return true if CustomDictionary has pair with key which was determine in input parameter.
        /// Return false if CustomDictionary has not pair with key which was determine in input parameter. </returns>
        public bool TryGetValue(T key, out V value)
        {
            value = default(V);
            bool keyWasFound = false;
            foreach (var pair in keyValuePairs)
            {
                if (pair.Key.Equals(key))
                {
                    keyWasFound = true;
                    value = pair.Value;
                    break;             
                }
            }
            return keyWasFound;
        }

        /// <summary>
        /// Removes key-value pair.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        public void Remove (T key)
        {
            foreach (var pair in keyValuePairs)
            {
                if(pair.Key.Equals(key))
                {
                    keyValuePairs.Remove(pair);
                    this.Count -= 1;
                    break;                                  
                }
            }
        }

        /// <summary>
        ///  Removes all pairs of key-value from CustomDictionary. 
        /// </summary>
        public void Clear ()
        {       
         keyValuePairs.Clear();
         this.Count = 0;                    
        }

        /// <summary>
        /// Implementation of method for IEnumerable generic interface.
        /// </summary>
        /// <returns>Return object implement IEnumeratorT interface. </returns>
        public IEnumerator<PairKeyAndValue<T, V>> GetEnumerator()
        {
            return new CustomDictionaryIEnumeratorT_V<PairKeyAndValue<T, V>>(keyValuePairs);
        }

        /// <summary>
        /// Implementation of method for  IEnumerable interface.
        /// </summary>
        /// <returns>Return  object implement IEnumerator interface. </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }

    
}
