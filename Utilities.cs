using System;

namespace ega_lab5;

public static class Utilities
{
	private static readonly Random Random = new();

	public static int GetRandom() => Random.Next();
	public static int GetRandom(int max) => Random.Next(max);
	public static int GetRandom(int min, int max) => Random.Next(min, max);

	public static double APSum(double first, double difference, int n)
	{
		return (2 * first + difference * (n - 1)) / 2 * n;
	}
}
