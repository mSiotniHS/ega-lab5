using System;
using System.Collections.Generic;
using System.Linq;

namespace ega_lab5;

public static class ClosestNeighbourMethod
{
	public static (IEnumerable<int>, int) FindSolution(DistanceMatrix<int> matrix, int firstCity)
	{
		var solution = new List<int> { firstCity };

		var unvisitedCities = Enumerable.Range(0, matrix.CityCount).ToList();
		unvisitedCities.Remove(firstCity);

		var distance = 0;

		while (unvisitedCities.Count > 0)
		{
			var tmpRoute = string.Join(" -> ", solution);
			Console.WriteLine($"> Итерация №{solution.Count}  |  Текущий: {tmpRoute}");

			var currentCity = solution.Last();
			var closestCity = unvisitedCities.MinBy(x => matrix[currentCity, x]);

			var tmpDistance = matrix[currentCity, closestCity];
			Console.WriteLine($"> Отобранный город: {closestCity}, расстояние: {tmpDistance}");

			solution.Add(closestCity);
			distance += matrix[currentCity, closestCity];

			Console.WriteLine($"> Текущее расстояние: {distance}\n");

			unvisitedCities.Remove(closestCity);
		}

		distance += matrix[solution.Last(), solution.First()];

		return (solution, distance);
	}
}
