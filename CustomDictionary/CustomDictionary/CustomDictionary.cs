using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
  public class CustomDictionary <T,V>: IEnumerable<PairKeyAndValue<T, V>>
    {      
       List<PairKeyAndValue<T,V>> keyAndValuePairs;
       public int Count { get; private  set; }
       
        

        public CustomDictionary()
        {
           keyAndValuePairs = new List<PairKeyAndValue<T, V>>();          
        }

        public V this[T key]
        {
         get
          {        
           foreach (var pair in keyAndValuePairs)
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
          foreach (var pair in keyAndValuePairs)
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

        public void Add (T key, V value)
        {
            PairKeyAndValue<T,V> pairKeyAndValue = new PairKeyAndValue<T,V>(key, value);
            keyAndValuePairs.Add(pairKeyAndValue);
            Count += 1;       
        }

        public bool ContainsKey(T Key)
        {
            bool wantedKeyWasFound = false;
            foreach(var pair in keyAndValuePairs)
            {
                if (pair.Key.Equals(Key))
                {
                    wantedKeyWasFound = true;
                    break;                    
                }
            }
            return wantedKeyWasFound;            
        }

        public bool TryGetValue(T key, out V value)
        {
            value = default(V);
            bool wantedKeyWasFound = false;
            foreach (var pair in keyAndValuePairs)
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

        public void Remove (T key)
        {
            foreach (var pair in keyAndValuePairs)
            {
                if(pair.Key.Equals(key))
                {
                    keyAndValuePairs.Remove(pair);
                    this.Count -= 1;
                    break;                                  
                }
            }
        }

        public void Clear ()
        {       
         keyAndValuePairs.Clear();
         this.Count = 0;                    
        }

        public IEnumerator<PairKeyAndValue<T, V>> GetEnumerator()
        {
            return new CustomDictionaryIEnumeratorT_V<PairKeyAndValue<T, V>>(keyAndValuePairs);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }

    
}
