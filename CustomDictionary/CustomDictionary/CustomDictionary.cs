using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    /// <summary>
    /// Class CustomDictionary generic keeps pairs key-value.It pairs will be keep in objects PairKeyAndValue.
    /// List which are in CustomDictionary will be keep objects PairKeyAndValue.
    /// </summary>
    /// <typeparam name="T">This is first  generic parameter.It parameter will be key for pairs key-value.</typeparam>
    /// <typeparam name="V">This is second  generic parameter. It parameter will be value for pairs key-value.</typeparam>
    public class CustomDictionary <T,V>: IEnumerable<PairKeyAndValue<T, V>>
    {      
       List<PairKeyAndValue<T,V>> listPairs;
       public int Count { get; private  set; }




      
        public CustomDictionary()
        {
           listPairs = new List<PairKeyAndValue<T, V>>();          
        }

        /// <summary>
        /// This indexator gets value from pair key-value.Indexator derives value by input parameter key.
        /// </summary>
        /// <param name="key"> Key allows of indexator determine from what pair derive value. </param>
        /// <exception>
        /// KeyNotFoundException
        /// </exception>
        /// <returns></returns>
        public V this[T key]
        {
         get
          {        
           foreach (var pair in listPairs)
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
          bool wasSeted = false;
          foreach (var pair in listPairs)
          {
             if (pair.Key.Equals(key))
             {
               pair.Value = value;
               wasSeted = true;
               break;                 
             }
          }
          if (!wasSeted)
          {
             throw new KeyNotFoundException();
          }                
            }
        }

        /// <summary>
        /// This method adds new pair key-value in dictionary.
        /// </summary>
        /// <param name="key"> Parameter key parameter determine key for new pair key-value. </param>
        /// <param name="value">Parameter  value determine value for new pair key-value. </param>
        public void Add (T key, V value)
        {
            PairKeyAndValue<T,V> pairKeyAndValue = new PairKeyAndValue<T,V>(key, value);
            listPairs.Add(pairKeyAndValue);
            Count += 1;       
        }

        /// <summary>
        /// This method searches key in CustomDictionary.
        /// </summary>
        /// <param name="Key">Key determine which key will be searches this method.</param>
        /// <returns>Method returns true if method has found key.If method has not found key will be return false.</returns>
        public bool ContainsKey(T Key)
        {
            bool wantedKeyWasFound = false;
            foreach(var pair in listPairs)
            {
                if (pair.Key.Equals(Key))
                {
                    wantedKeyWasFound = true;
                    break;                    
                }
            }
            return wantedKeyWasFound;            
        }
        /// <summary>
        /// This method checks what value connect with key.
        /// </summary>
        /// <param name="key">Method uses this key for search of  pair key-value. </param>
        /// <param name="value">Value connect with key will be return. </param>
        /// <returns>Return true if CustomDictionary has pair with key which was determine in input parameter.
        /// Return false if CustomDictionary has not pair with key which was determine in input parameter. </returns>
        public bool TryGetValue(T key, out V value)
        {
            value = default(V);
            bool wantedKeyWasFound = false;
            foreach (var pair in listPairs)
            {
                if (pair.Key.Equals(key))
                {
                    wantedKeyWasFound = true;
                    value = pair.Value;
                    break;             
                }
            }
            return wantedKeyWasFound;
        }

        /// <summary>
        /// This method removes pair key-value from CustomDictionary by specified key.
        /// </summary>
        /// <param name="key">Key determine what pair will be remove.</param>
        public void Remove (T key)
        {
            foreach (var pair in listPairs)
            {
                if(pair.Key.Equals(key))
                {
                    listPairs.Remove(pair);
                    this.Count -= 1;
                    break;                                  
                }
            }
        }

        /// <summary>
        /// This method removes all pairs key-value from CustomDictionary.
        /// </summary>
        public void Clear ()
        {       
         listPairs.Clear();
         this.Count = 0;                    
        }

        /// <summary>
        /// Implementation of method for IEnumerable generic interface.
        /// </summary>
        /// <returns>Return object realize IEnumeratorT interface. </returns>
        public IEnumerator<PairKeyAndValue<T, V>> GetEnumerator()
        {
            return new CustomDictionaryIEnumeratorT_V<PairKeyAndValue<T, V>>(listPairs);
        }

        /// <summary>
        /// Implementation of method for  IEnumerable interface.
        /// </summary>
        /// <returns>Return  object realize IEnumerator interface. </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }

    
}
