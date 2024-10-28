// Inventory of extension methods to shim or replace

// ============================================
//  FluentAssertions.AssertionExtensions class
// ============================================
// IExpect.Invoking.cs         : public static Action                             Invoking<T>(this T subject, Action<T> action) => throw null!;
// IExpect.Invoking.cs         : public static Func<TResult>                      Invoking<T, TResult>(this T subject, Func<T, TResult> action) => throw null!;
// IExpect.Awaiting.cs         : public static Func<Task>                         Awaiting<T>(this T subject, Func<T, Task> action) => throw null!;
// IExpect.Awaiting.cs         : public static Func<Task<TResult>>                Awaiting<T, TResult>(this T subject, Func<T, Task<TResult>> action) => throw null!;
// IExpect.Awaiting.cs         : public static Func<Task>                         Awaiting<T>(this T subject, Func<T, ValueTask> action) => throw null!;
// IExpect.Awaiting.cs         : public static Func<Task<TResult>>                Awaiting<T, TResult>(this T subject, Func<T, ValueTask<TResult>> action) => throw null!;

public static MemberExecutionTime<T>        ExecutionTimeOf<T>(this T subject, Expression<Action<T>> action, StartTimer createTimer = null) => throw null!;
public static ExecutionTime                 ExecutionTime(this Action action, StartTimer createTimer = null) => throw null!;
public static ExecutionTime                 ExecutionTime(this Func<Task> action) => throw null!;
public static ExecutionTimeAssertions         -> Should(this ExecutionTime executionTime) => throw null!;
public static IMonitor<T>                   Monitor<T>(this T eventSource, Func<DateTime> utcNow = null) => throw null!;

public static Action                        Enumerating(this Func<IEnumerable> enumerable) => throw null!;
public static Action                        Enumerating<T>(this Func<IEnumerable<T>> enumerable) => throw null!;
public static Action                        Enumerating<T, TResult>(this T subject, Func<T, IEnumerable<TResult>> enumerable) => throw null!;

// ObjectExpectations.cs       : public static ObjectAssertions                   Should([NotNull] this object actualValue) => throw null!;
// FunctionExpectations.cs     : public static ActionAssertions                   Should([NotNull] this Action action) => throw null!;
// FunctionExpectations.cs     : public static NonGenericAsyncFunctionAssertions  Should([NotNull] this Func<Task> action) => throw null!;
// FunctionExpectations.cs     : public static GenericAsyncFunctionAssertions<T>  Should<T>([NotNull] this Func<Task<T>> action) => throw null!;
// FunctionExpectations.cs     : public static FunctionAssertions<T>              Should<T>([NotNull] this Func<T> func) => throw null!;
// FunctionExpectations.cs     : public static TaskCompletionSourceAssertions<T>  Should<T>(this TaskCompletionSource<T> tcs) => throw null!;
// FunctionExpectations.cs     : public static TaskCompletionSourceAssertions     Should(this TaskCompletionSource tcs) => throw null!;
// ReflectionExpectations.cs   : public static AssemblyAssertions                 Should([NotNull] this Assembly assembly) => throw null!;
public static XDocumentAssertions               Should([NotNull] this XDocument actualValue) => throw null!;
public static XElementAssertions                Should([NotNull] this XElement actualValue) => throw null!;
public static XAttributeAssertions              Should([NotNull] this XAttribute actualValue) => throw null!;
public static StreamAssertions                  Should([NotNull] this Stream actualValue) => throw null!;
public static BufferedStreamAssertions          Should([NotNull] this BufferedStream actualValue) => throw null!;
// BoolExpectations.cs         : public static BooleanAssertions                  Should(this bool actualValue) => throw null!;
// BoolExpectations.cs         : public static NullableBooleanAssertions          Should(this bool? actualValue) => throw null!;
// HttpResponseExpectations.cs : public static HttpResponseMessageAssertions      Should([NotNull] this HttpResponseMessage actualValue) => throw null!;
// GuidExpectations.cs         : public static GuidAssertions                     Should(this Guid actualValue) => throw null!;
// GuidExpectations.cs         : public static NullableGuidAssertions             Should(this Guid? actualValue) => throw null!;
// CollectionExpectations.cs   : public static GenericCollectionAssertions<T>     Should<T>([NotNull] this IEnumerable<T> actualValue) => throw null!;
// CollectionExpectations.cs   : public static StringCollectionAssertions         Should([NotNull] this IEnumerable<string> @this) => throw null!;
// DictionaryExpectations.cs   : public static GenericDictionaryAssertions<IDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> actualValue) => throw null!;
// DictionaryExpectations.cs   : public static GenericDictionaryAssertions<IEnumerable<KeyValuePair<TKey, TValue>>, TKey, TValue> Should<TKey, TValue>([NotNull] this IEnumerable<KeyValuePair<TKey, TValue>> actualValue) => throw null!;
// DictionaryExpectations.cs   : public static GenericDictionaryAssertions<TCollection, TKey, TValue> Should<TCollection, TKey, TValue>([NotNull] this TCollection actualValue) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>> => throw null!;
// DateTimeExpectations.cs     : public static DateTimeAssertions                 Should(this DateTime actualValue) => throw null!;
// DateTimeExpectations.cs     : public static DateTimeOffsetAssertions           Should(this DateTimeOffset actualValue) => throw null!;
// DateTimeExpectations.cs     : public static NullableDateTimeAssertions         Should(this DateTime? actualValue) => throw null!;
// DateTimeExpectations.cs     : public static NullableDateTimeOffsetAssertions   Should(this DateTimeOffset? actualValue) => throw null!;
// DateTimeExpectations.cs     : public static DateOnlyAssertions                 Should(this DateOnly actualValue) => throw null!;
// DateTimeExpectations.cs     : public static NullableDateOnlyAssertions         Should(this DateOnly? actualValue) => throw null!;
// DateTimeExpectations.cs     : public static TimeOnlyAssertions                 Should(this TimeOnly actualValue) => throw null!;
// DateTimeExpectations.cs     : public static NullableTimeOnlyAssertions         Should(this TimeOnly? actualValue) => throw null!;
// IComparableExpectations.cs  : public static ComparableTypeAssertions<T>        Should<T>([NotNull] this IComparable<T> comparableValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<int>             Should(this int actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<int>     Should(this int? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<uint>            Should(this uint actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<uint>    Should(this uint? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<decimal>         Should(this decimal actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<decimal> Should(this decimal? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<byte>            Should(this byte actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<byte>    Should(this byte? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<sbyte>           Should(this sbyte actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<sbyte>   Should(this sbyte? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<short>           Should(this short actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<short>   Should(this short? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<ushort>          Should(this ushort actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<ushort>  Should(this ushort? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<long>            Should(this long actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<long>    Should(this long? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<ulong>           Should(this ulong actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<ulong>   Should(this ulong? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<float>           Should(this float actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<float>   Should(this float? actualValue) => throw null!;
// NumericExpectations.cs      : public static NumericAssertions<double>          Should(this double actualValue) => throw null!;
// NumericExpectations.cs      : public static NullableNumericAssertions<double>  Should(this double? actualValue) => throw null!;
// StringExpectations.cs       : public static StringAssertions                   Should([NotNull] this string actualValue) => throw null!;
// DateTimeExpectations.cs     : public static SimpleTimeSpanAssertions           Should(this TimeSpan actualValue) => throw null!;
// DateTimeExpectations.cs     : public static NullableSimpleTimeSpanAssertions   Should(this TimeSpan? actualValue) => throw null!;
// ReflectionExpectations.cs   : public static TypeAssertions                     Should([NotNull] this Type subject) => throw null!;
// ReflectionExpectations.cs   : public static TypeSelectorAssertions             Should(this TypeSelector typeSelector) => throw null!;
// ReflectionExpectations.cs   : public static ConstructorInfoAssertions          Should([NotNull] this ConstructorInfo constructorInfo) => throw null!;
// ReflectionExpectations.cs   : public static MethodInfoAssertions               Should([NotNull] this MethodInfo methodInfo) => throw null!;
// ReflectionExpectations.cs   : public static MethodInfoSelectorAssertions       Should(this MethodInfoSelector methodSelector) => throw null!;
// ReflectionExpectations.cs   : public static PropertyInfoAssertions             Should([NotNull] this PropertyInfo propertyInfo) => throw null!;
// ReflectionExpectations.cs   : public static PropertyInfoSelectorAssertions     Should(this PropertyInfoSelector propertyInfoSelector) => throw null!;
