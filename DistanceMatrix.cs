using System;

namespace ega_lab5;

public sealed class DistanceMatrix<T>
{
	private readonly T[] _data;
	public int PointCount { get; }

	public DistanceMatrix(int pointCount)
	{
		PointCount = pointCount;
		_data = new T[PointCount * (PointCount - 1) / 2];
	}

	public DistanceMatrix(int pointCount, T[] data)
	{
		PointCount = pointCount;
		if (data.Length != PointCount * (PointCount - 1) / 2)
			throw new ArgumentException("Invalid data length");
		_data = data;
	}

	private int ConvertIndex(int i, int j)
	{
		if (i == j) return 0;

		if (i > j)
		{
			(i, j) = (j, i);
		}

		var idx = j - i - 1;
		var jump = Convert.ToInt32(Utilities.APSum(PointCount - 1, -1, i));

		return jump + idx;
	}

	public T this[int from, int to]
	{
		get => _data[ConvertIndex(from, to)];
		set => _data[ConvertIndex(from, to)] = value;
	}
}
