using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
  public class CustomDictionary <T,V>: IEnumerable<T> /*where V : new()*/
    {      
       List<PairKeyAndValue<T,V>> keyAndValuePairs;
       public int count { get; private  set; }

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
           if (pair.key.Equals(key))
           {
             return pair.value;
           }

           }
            throw new KeyNotFoundException();
           }
             
         set
         {
          bool wasSeted = false;
          foreach (var pair in keyAndValuePairs)
          {
             if (pair.key.Equals(key))
             {
               pair.value = value;
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
            count += 1;       
        }

        public bool ContainsKey(T Key)
        {
            bool wantedKeyWasFound = false;
            foreach(var pair in keyAndValuePairs)
            {
                if (pair.key.Equals(Key))
                {
                    wantedKeyWasFound = true;
                    break;                    
                }
            }
            return wantedKeyWasFound;            
        }

        //public bool TryGetValue (T key, out V value) 
        //{           
        //    value = new V();
        //    bool wantedKeyWasFound = false;
        //    foreach (var pair in KeyAndValuePairs)
        //    {
        //        if(pair.key.Equals(key))
        //        {
        //            wantedKeyWasFound = true;
        //            value = pair.value;
        //            break;
        //        }                        
        //    }
        //    return wantedKeyWasFound;           
        //}

        public void Remove (T key)
        {
            foreach (var pair in keyAndValuePairs)
            {
                if(pair.key.Equals(key))
                {
                    keyAndValuePairs.Remove(pair);
                    this.count -= 1;
                    break;                                  
                }
            }
        }

        public void Clear ()
        {       
         keyAndValuePairs.Clear();
         this.count = 0;                    
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomDictionaryIEnumeratorT_V <T,V>(keyAndValuePairs);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }



}
