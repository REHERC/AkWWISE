using System;

public static class TypeEx
{
	// htp://stackoverflow.com/a/457708
	public static bool IsSubClassOfRawGeneric(this Type toCheck, Type generic)
	{
		while (toCheck != null && toCheck != typeof(object))
		{
			Type current = toCheck.IsGenericType
				? toCheck.GetGenericTypeDefinition()
				: toCheck;
			if (current == generic)
			{
				return true;
			}
			toCheck = toCheck.BaseType;
		}
		return false;
	}
}
