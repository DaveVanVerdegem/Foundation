namespace Foundation.Helpers
{
	public interface IHasAliveCheck { }
	public static class UnityObjectAliveExtension
	{
		#region Static Methods
		public static bool IsAlive(this IHasAliveCheck anObject)
		{
			if (anObject is UnityEngine.Object unityObject)
				return unityObject != null;
			return anObject != null;
		}
		#endregion
	}
}