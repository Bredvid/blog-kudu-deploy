public static TOut Map<TIn, TOut>(this TIn @this, Func<TIn, TOut> map) where TIn : class
{
    if (@this == null) return default(TOut);
    return map(@this);
}