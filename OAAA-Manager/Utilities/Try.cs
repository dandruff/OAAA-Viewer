using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAAA_Manager.Utilities
{
    public static class Try
    {
        #region Actions
        // None
        public static Exception Run(this Action func)
        {
            Exception error = null;
            try
            {
                func();
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 1
        public static Exception Run<T1>(this Action<T1> func, T1 t1)
        {
            Exception error = null;
            try
            {
                func(t1);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 2
        public static Exception Run<T1, T2>(this Action<T1, T2> func, T1 t1, T2 t2)
        {
            Exception error = null;
            try
            {
                func(t1, t2);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 3
        public static Exception Run<T1, T2, T3>(this Action<T1, T2, T3> func, T1 t1, T2 t2, T3 t3)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 4
        public static Exception Run<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 5
        public static Exception Run<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4, t5);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 6
        public static Exception Run<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4, t5, t6);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 7
        public static Exception Run<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4, t5, t6, t7);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 8
        public static Exception Run<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 9
        public static Exception Run<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }
        // 10
        public static Exception Run<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            Exception error = null;
            try
            {
                func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return error;
        }

        // TODO: Finish the rest

        #endregion Actions

        #region Functions
        // None
        public static Exception Run<TResult>(this Func<TResult> func, out TResult result)
        {
            Exception error = null;
            try
            {
                result = func();
            }
            catch (Exception ex)
            {
                error = ex;
                result = default(TResult);
            }
            return error;
        }
        // 1
        public static Exception Run<T1, TResult>(this Func<T1, TResult> func, T1 t1, out TResult result)
        {
            Exception error = null;
            try
            {
                result = func(t1);
            }
            catch (Exception ex)
            {
                error = ex;
                result = default(TResult);
            }
            return error;
        }
        // 2
        public static Exception Run<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 t1, T2 t2, out TResult result)
        {
            Exception error = null;
            try
            {
                result = func(t1, t2);
            }
            catch (Exception ex)
            {
                error = ex;
                result = default(TResult);
            }
            return error;
        }
        // 3
        public static Exception Run<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 t1, T2 t2, T3 t3, out TResult result)
        {
            Exception error = null;
            try
            {
                result = func(t1, t2, t3);
            }
            catch (Exception ex)
            {
                error = ex;
                result = default(TResult);
            }
            return error;
        }
        // 4
        public static Exception Run<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, out TResult result)
        {
            Exception error = null;
            try
            {
                result = func(t1, t2, t3, t4);
            }
            catch (Exception ex)
            {
                error = ex;
                result = default(TResult);
            }
            return error;
        }

        // TODO: Finish the rest
        
        #endregion Functions
    }
}
